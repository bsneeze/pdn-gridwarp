using PaintDotNet;
using PaintDotNet.Effects;
using pyrochild.effects.common;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace pyrochild.effects.gridwarp
{
    public partial class ConfigDialog : EffectConfigDialog
    {
        private const char undoShortcut = (char)26;
        private const char redoShortcut = (char)25;
        private Surface surface;
        private const int minGridSize = 1;
        private const int maxGridSize = 100;
        private int[] gridSizes =
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 13, 14, 15, 20, 25, 30,
                35, 40, 45, 50, 60, 70, 80, 90, 100
            };
        private DisplacementGrid grid;
        private DisplacementMesh mesh;
        bool gridvisible = true;

        PointF mouselocation;
        Point tracking = new Point(-1, -1);
        Point hovering = new Point(-1, -1);

        private void canvas_CanvasMouseMove(object sender, CanvasMouseEventArgs e)
        {
            Rectangle invalidrect = new Rectangle(
                (int)(mouselocation.X - 20 / canvas.ZoomFactor),
                (int)(mouselocation.Y - 20 / canvas.ZoomFactor),
                (int)(40 / canvas.ZoomFactor),
                (int)(40 / canvas.ZoomFactor));

            mouselocation = e.Location;

            if (tracking.X > -1)
            {
                int i = tracking.X;
                int j = tracking.Y;
                float xspacing = (EffectSourceSurface.Width - 1) / (float)(grid.Width);
                float yspacing = (EffectSourceSurface.Height - 1) / (float)(grid.Height);

                float x = mouselocation.X;
                float y = mouselocation.Y;

                invalidrect = grid.SetPoint(i, j, x / xspacing - i, y / yspacing - j);

                invalidrect.Inflate(10, 10);
            }

            canvas.InvalidateCanvas(invalidrect);
        }

        private void canvas_CanvasMouseDown(object sender, CanvasMouseEventArgs e)
        {
            tracking = hovering;
        }

        private void canvas_CanvasMouseUp(object sender, CanvasMouseEventArgs e)
        {
            tracking = new Point(-1, -1);
        }

        void canvas_CanvasPaint(object sender, PaintEventArgs e)
        {
            if (grid != null && gridvisible)
            {
                float xspacing = canvas.ZoomFactor * (EffectSourceSurface.Width - 1) / (float)grid.Width;
                float yspacing = canvas.ZoomFactor * (EffectSourceSurface.Height - 1) / (float)grid.Height;
                float handleradius = 3;

                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                //draw horizontal guidelines
                for (int j = 0; j <= grid.Height; ++j)
                {
                    CosineInterpolator si = new CosineInterpolator();

                    for (int i = 0; i <= grid.Width; ++i)
                    {
                        si.Add(i + grid.GetPoint(i, j).X, j + grid.GetPoint(i, j).Y);
                    }

                    int linestart = Math.Max(
                        e.ClipRectangle.Left,
                        (int)(grid.GetPoint(0, j).X * xspacing));

                    int lineend = Math.Min(
                        e.ClipRectangle.Right + 1,
                        (int)((grid.Width + grid.GetPoint(grid.Width, j).X) * xspacing));

                    int len = lineend - linestart;
                    if (len > 1)
                    {
                        PointF[] line = new PointF[len];
                        for (int x = linestart; x < lineend; ++x)
                        {
                            line[x - linestart] = new PointF(x, (float)(si.Interpolate(x / xspacing) * yspacing + 1));
                        }
                        e.Graphics.DrawLines(gridPen, line);
                    }
                }

                //vertical guidelines
                for (int i = 0; i <= grid.Width; ++i)
                {
                    CosineInterpolator si = new CosineInterpolator();

                    for (int j = 0; j <= grid.Height; ++j)
                    {
                        si.Add(j + grid.GetPoint(i, j).Y, i + grid.GetPoint(i, j).X);
                    }

                    int linestart = Math.Max(
                        e.ClipRectangle.Top,
                        (int)(grid.GetPoint(i, 0).Y * yspacing));

                    int lineend = Math.Min(
                        e.ClipRectangle.Bottom + 1,
                        (int)((grid.Height + grid.GetPoint(i, grid.Height).Y) * yspacing));

                    int len = lineend - linestart;
                    if (len > 1)
                    {
                        PointF[] line = new PointF[len];
                        for (int y = linestart; y < lineend; ++y)
                        {
                            line[y - linestart] = new PointF((float)(si.Interpolate(y / yspacing) * xspacing + 1), y);
                        }
                        e.Graphics.DrawLines(gridPen, line);
                    }
                }

                //draw control handles and check if the mouse is hovering over one while we're at it
                hovering = tracking;
                for (int j = 0; j <= grid.Height; ++j)
                {
                    for (int i = 0; i <= grid.Width; ++i)
                    {
                        PointF point = new PointF(
                            (i + grid.GetPoint(i, j).X) * xspacing + 1,
                            (j + grid.GetPoint(i, j).Y) * yspacing + 1);

                        RectangleF dotdrawrect = new RectangleF(point.X - handleradius, point.Y - handleradius, 2 * handleradius, 2 * handleradius);
                        RectangleF hitrect = RectangleF.Inflate(dotdrawrect, 5, 5);
                        if ((tracking.X == i && tracking.Y == j)
                            || (tracking.X == -1 && hitrect.Contains(mouselocation.X * canvas.ZoomFactor, mouselocation.Y * canvas.ZoomFactor)))
                        {
                            e.Graphics.FillEllipse(Brushes.Black, RectangleF.Inflate(dotdrawrect, 1, 1));
                            e.Graphics.FillEllipse(Brushes.White, RectangleF.Inflate(dotdrawrect, -1, -1));
                            hovering = new Point(i, j);
                        }
                        else
                            e.Graphics.FillEllipse(Brushes.Black, dotdrawrect);
                    }
                }
            }
        }

        public ConfigDialog()
        {
            InitializeComponent();

            gridPen = new Pen(Color.Black);

            this.gridWidth.ComboBox.SuspendLayout();
            this.gridHeight.ComboBox.SuspendLayout();
            this.zoom.ComboBox.SuspendLayout();

            for (int i = 0; i < this.gridSizes.Length; ++i)
            {
                this.gridWidth.Items.Add(this.gridSizes[i].ToString());
            }
            for (int i = 0; i < this.gridSizes.Length; ++i)
            {
                this.gridHeight.Items.Add(this.gridSizes[i].ToString());
            }

            string percent100 = null;
            for (int i = 0; i < CanvasPanel.ZoomFactors.Length; i++)
            {
                string zoomValueString = (CanvasPanel.ZoomFactors[i] * 100).ToString();
                string zoomItemString = string.Format("{0}%", zoomValueString);

                if (CanvasPanel.ZoomFactors[i] == 1.0)
                {
                    percent100 = zoomItemString;
                }
                this.zoom.Items.Add(zoomItemString);
            }

            this.gridWidth.ComboBox.ResumeLayout(false);
            this.gridHeight.ComboBox.ResumeLayout(false);
            this.zoom.ComboBox.ResumeLayout(false);
            this.zoom.Text = percent100;

            InitializeUIImages();
            InitializeTooltips();
        }

        private void InitializeUIImages()
        {
            Type t = typeof(GridWarp);

            load.Image = new Bitmap(t, "images.open.png");
            save.Image = new Bitmap(t, "images.save.png");
            colors.Image = new Bitmap(t, "images.colorwheel.png");
            gridSizeIncrement.Image = new Bitmap(t, "images.gridlarge.png");
            gridSizeDecrement.Image = new Bitmap(t, "images.gridsmall.png");
            undo.Image = new Bitmap(t, "images.undo.png");
            redo.Image = new Bitmap(t, "images.redo.png");
            zoomIn.Image = new Bitmap(t, "images.zoomin.png");
            zoomOut.Image = new Bitmap(t, "images.zoomout.png");
            visibility.Image = new Bitmap(t, "images.eye.png");
        }

        private void InitializeTooltips()
        {
            tooltip.SetToolTip(save, "Save grid");
            tooltip.SetToolTip(load, "Load grid");
            tooltip.SetToolTip(colors, "Change interface colors");
            undo.ToolTipText = "Undo";
            redo.ToolTipText = "Redo";
            gridSizeIncrement.ToolTipText = "Increase grid size";
            gridSizeDecrement.ToolTipText = "Decrease grid size";
            zoomIn.ToolTipText = "Zoom in";
            zoomOut.ToolTipText = "Zoom out";
            tooltip.SetToolTip(visibility, "Toggle grid lines");
        }

        private void InitializeRenderer()
        {
            grid.Invalidated += grid_Invalidated;
        }

        void grid_Invalidated(object sender, InvalidateEventArgs e)
        {
            if (!surface.IsDisposed)
            {
                mesh.Render(surface, EffectSourceSurface, e.InvalidRect);
            }

            canvas.InvalidateCanvas(e.InvalidRect);
        }

        private void canvas_ZoomFactorChanged(object sender, EventArgs e)
        {
            zoom.SelectedItem = string.Format("{0}%", canvas.ZoomFactor * 100);
        }

        private void gridSize_Validating(object sender, EventArgs e)
        {
            float gridSize;
            bool valid = float.TryParse(this.gridWidth.Text, out gridSize);

            if (!valid)
            {
                this.gridWidth.BackColor = Color.Red;
            }
            else
            {
                if (gridSize < minGridSize)
                {
                    this.gridWidth.BackColor = Color.Red;
                }
                else if (gridSize > maxGridSize)
                {
                    this.gridWidth.BackColor = Color.Red;
                }
                else
                {
                    this.gridWidth.BackColor = SystemColors.Window;
                    OnGridChanged();
                }
            }

            valid = float.TryParse(this.gridHeight.Text, out gridSize);

            if (!valid)
            {
                this.gridHeight.BackColor = Color.Red;
            }
            else
            {
                if (gridSize < minGridSize)
                {
                    this.gridHeight.BackColor = Color.Red;
                }
                else if (gridSize > maxGridSize)
                {
                    this.gridHeight.BackColor = Color.Red;
                }
                else
                {
                    this.gridHeight.BackColor = SystemColors.Window;
                    OnGridChanged();
                }
            }
        }

        private void OnGridChanged()
        {
            if (grid != null)
            {
                if (grid.Width != GridWidth || grid.Height != GridHeight)
                {
                    grid.Abort();
                    grid.SetSize(GridWidth, GridHeight);

                    if (mesh != null) mesh.Clear();
                    if (surface != null) surface.CopySurface(EffectSourceSurface);
                }
            }
            else if (mesh != null)
            {
                grid = new DisplacementGrid(GridWidth, GridHeight, mesh);
                InitializeRenderer();
            }

            canvas.InvalidateCanvas();
        }

        private void donate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Services.GetService<PaintDotNet.AppModel.IShellService>().LaunchUrl(this, "http://forums.getpaint.net/index.php?showtopic=7291");
        }

        private void ConfigDialog_Load(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            this.Text = GridWarp.StaticDialogName;
            this.DesktopLocation = Owner.PointToScreen(new Point(0, 30));
            this.Size = new Size(Owner.ClientSize.Width, Owner.ClientSize.Height - 30);
            this.WindowState = Owner.WindowState;

            surface = new Surface(EffectSourceSurface.Size);
            mesh = new DisplacementMesh(surface.Size);
            canvas.Surface = surface;
            canvas.Selection = Selection;
            mesh.Render(surface, EffectSourceSurface, EffectSourceSurface.Bounds);
        }

        private void gridSizeDecrement_Click(object sender, EventArgs e)
        {
            int amount = -1;

            if ((Control.ModifierKeys & Keys.Control) != 0)
            {
                amount *= 5;
            }
            AddToGridSize(amount);
        }

        private void gridSizeIncrement_Click(object sender, EventArgs e)
        {
            int amount = 1;

            if ((Control.ModifierKeys & Keys.Control) != 0)
            {
                amount *= 5;
            }
            AddToGridSize(amount);
        }

        public void AddToGridSize(int delta)
        {
            int newWidth = Int32Util.Clamp(GridWidth + delta, minGridSize, maxGridSize);
            GridWidth = newWidth;

            int newHeight = Int32Util.Clamp(GridHeight + delta, minGridSize, maxGridSize);
            GridHeight = newHeight;
        }

        protected override void InitialInitToken()
        {
            theEffectToken = new ConfigToken();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            canvas.PerformMouseWheel(e);
        }

        public int GridWidth
        {
            get
            {
                int width;

                try
                {
                    width = (int)float.Parse(this.gridWidth.Text);
                }

                catch (FormatException)
                {
                    width = 10;
                }

                return width;
            }
            set
            {
                this.gridWidth.Text = value.ToString();
                OnGridChanged();
            }
        }

        public int GridHeight
        {
            get
            {
                int height;

                try
                {
                    height = (int)float.Parse(this.gridHeight.Text);
                }

                catch (FormatException)
                {
                    height = 5;
                }

                return height;
            }
            set
            {
                this.gridHeight.Text = value.ToString();
                OnGridChanged();
            }
        }

        private void zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zoom.SelectedIndex >= 0)
                canvas.ZoomFactor = CanvasPanel.ZoomFactors[zoom.SelectedIndex];
        }

        protected override void InitDialogFromToken(EffectConfigToken effectTokenCopy)
        {
            ConfigToken token = effectTokenCopy as ConfigToken;
            GridWidth = token.width;
            GridHeight = token.height;
        }

        protected override void InitTokenFromDialog()
        {
            ConfigToken token = EffectToken as ConfigToken;
            token.width = GridWidth;
            token.height = GridHeight;
            token.grid = grid;
            token.mesh = mesh;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        const string dialogFilter = "Warp Grid (*.WARPGRID)|*.warpgrid";
        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = dialogFilter;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                if (grid != null)
                    grid.Abort();

                try
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open);

                    DisplacementGrid g = new DisplacementGrid(fs, mesh);
                    GridWidth = g.Width;
                    GridHeight = g.Height;
                    grid = g;

                    InitializeRenderer();

                    grid.UpdateMesh();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this,
                        "Error loading warp grid:\n\n" + exc.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = dialogFilter;
            sfd.FileName = "Grid Warp.warpgrid";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                    grid.Save(fs);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this,
                        "Error saving warp grid:\n\n" + exc.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private Pen gridPen;

        public ColorBgra GridColor
        {
            get => gridPen.Color;
            set
            {
                gridPen.Color = value;
                canvas.Invalidate();
            }
        }

        private void colors_Click(object sender, EventArgs e)
        {
            ColorBgra oldFrameColor = canvas.BackColor;
            ColorBgra oldBackgroundColor = canvas.CanvasBackColor;
            ColorBgra oldGridLineColor = GridColor;

            var cd = new GridWarpColorsDialog()
            {
                FrameColor = oldFrameColor,
                BackgroundColor = oldBackgroundColor,
                GridColor = oldGridLineColor
            };

            cd.ColorChanged += (s, a) =>
            {
                canvas.BackColor = cd.FrameColor;
                canvas.CanvasBackColor = cd.BackgroundColor;
                
                if (cd.BackgroundSurface != null)
                {
                    if (canvas.CanvasBackgroundImage == null)
                    {
                        canvas.CanvasBackgroundImage = new Bitmap(cd.BackgroundSurface.CreateAliasedBitmap());
                    }
                }
                else
                {
                    canvas.CanvasBackgroundImage?.Dispose();
                    canvas.CanvasBackgroundImage = null;
                }
                GridColor = cd.GridColor;
            };

            if (cd.ShowDialog(this) != DialogResult.OK)
            {
                canvas.BackColor = oldFrameColor;
                canvas.CanvasBackColor = oldBackgroundColor;
                GridColor = oldGridLineColor;
            }
        }

        private void undo_Click(object sender, EventArgs e)
        { }

        private void redo_Click(object sender, EventArgs e)
        { }

        private void cancel_Click(object sender, EventArgs e)
        {
            grid.Abort();
        }

        private void zoomOut_Click(object sender, EventArgs e)
        {
            canvas.ZoomOut();
        }

        private void zoomIn_Click(object sender, EventArgs e)
        {
            canvas.ZoomIn();
        }

        private void visbility_Click(object sender, EventArgs e)
        {
            gridvisible ^= true;
            canvas.InvalidateCanvas();
        }
    }
}
