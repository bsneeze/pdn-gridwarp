using PaintDotNet;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pyrochild.effects.gridwarp
{
    public partial class GridWarpColorsDialog : Form
    {
        private Surface clipboard;

        public GridWarpColorsDialog()
        {
            InitializeComponent();

            if (Clipboard.ContainsImage())
            {
                try
                {
                    using (Surface sfc = new Surface(clipboardPreview.Size))
                    {
                        clipboard = Surface.CopyFromBitmap((Bitmap)Clipboard.GetImage());
                        sfc.FitSurface(ResamplingAlgorithm.Fant, clipboard);
                        clipboardPreview.Image = new Bitmap(sfc.CreateAliasedBitmap());
                        fromClipboard.Enabled = true;
                    }
                }
                catch { }
            }
        }

        public ColorBgra BackgroundColor
        {
            get => backgroundColor.Color;
            set => backgroundColor.Color = value;
        }

        public ColorBgra FrameColor
        {
            get => frameColor.Color;
            set => frameColor.Color = value;
        }

        public ColorBgra GridColor
        {
            get => gridLineColor.Color;
            set => gridLineColor.Color = value;
        }

        public Surface BackgroundSurface { get; set; }

        public event EventHandler ColorChanged;

        private void OnColorChanged(object sender, EventArgs e)
        {
            ColorChanged?.Invoke(sender, e);
        }

        private void fromClipboard_CheckedChanged(object sender, EventArgs e)
        {
            if (fromClipboard.Checked)
            {
                backgroundColor.Enabled = false;
                BackgroundSurface = clipboard;
            }
            else
            {
                backgroundColor.Enabled = true;
                BackgroundSurface = null;
            }
            OnColorChanged(sender, e);
        }
    }
}
