using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace pyrochild.effects.gridwarp
{
    /// <summary>
    /// Keeps track of the control points of the displacement grid.
    /// Generates the DisplacementMesh on a background thread.
    /// </summary>
    public class DisplacementGrid
    {
        private Queue<Point> updateQueue;
        private Thread updateThreadv;
        int width;
        int height;
        int handlesx;
        int handlesy;
        float xspacing;
        float yspacing;
        float delx;
        float dely;
        private DisplacementVector[,] points;
        private DisplacementMesh mesh;
        private bool useLinearInterpolation = false;

        public DisplacementGrid(Size size, DisplacementMesh mesh, bool useLinearInterpolation = false)
            : this(size.Width, size.Height, mesh, useLinearInterpolation)
        { }

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public bool UseLinearInterpolation 
        { 
            get { return useLinearInterpolation; } 
            set { 
                useLinearInterpolation = value; 
                this.UpdateMesh(); 
            } 
        }

        public DisplacementGrid(int width, int height, DisplacementMesh mesh, bool useLinearInterpolation = false)
        {
            this.mesh = mesh;
            this.useLinearInterpolation = useLinearInterpolation;
            SetSize(width, height);
        }

        public DisplacementGrid(Stream s, DisplacementMesh mesh)
        {
            using (BinaryReader br = new BinaryReader(s))
            {
                handlesx = br.ReadInt32();
                handlesy = br.ReadInt32();
                this.mesh = mesh;
                SetSize(handlesx - 1, handlesy - 1);

                for (int j = 0; j < handlesy; ++j)
                {
                    for (int i = 0; i < handlesx; ++i)
                    {
                        points[i, j].X = br.ReadSingle();
                        points[i, j].Y = br.ReadSingle();
                    }
                }
            }
        }

        public void SetSize(int width, int height)
        {
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                handlesx = width + 1;
                handlesy = height + 1;
                xspacing = (mesh.Width - 1) / (float)width;
                yspacing = (mesh.Height - 1) / (float)height;
                delx = 1 / xspacing;
                dely = 1 / yspacing;
                points = new DisplacementVector[handlesx, handlesy];
                updateQueue = new Queue<Point>();
            }
        }

        public Rectangle SetPoint(int pi, int pj, float nx, float ny)
        {
            int istart = pi - 1,
                iend = pi + 2,
                jstart = pj - 1,
                jend = pj + 2;

            if (istart < 0) istart = 0;
            else if (iend > handlesx) iend = handlesx;
            if (jstart < 0) jstart = 0;
            else if (jend > handlesy) jend = handlesy;
            
            int l = mesh.Width,
                t = mesh.Height,
                r = 0,
                b = 0;

            for (int j = jstart; j < jend; ++j)
            {
                for (int i = istart; i < iend; ++i)
                {
                    float bx = i + points[i, j].X;
                    float by = j + points[i, j].Y;

                    int x = (int)(bx * xspacing);
                    int y = (int)(by * yspacing);

                    if (x < l) l = x;
                    if (x > r) r = x;

                    if (y < t) t = y;
                    if (y > b) b = y;

                    if (i > pi && nx + pi > bx) nx = bx - pi - delx;
                    else if (i < pi && nx + pi < bx) nx = bx - pi + delx;

                    if (j > pj && ny + pj > by) ny = by - pj - dely;
                    else if (j < pj && ny + pj < by) ny = by - pj + dely;
                }
            }

            if (l < 0) l = 0;
            if (r > mesh.Width) r = mesh.Width;
            if (t < 0) t = 0;
            if (b > mesh.Height) b = mesh.Height;

            if (nx + pi < 0) nx = -pi;
            else if (nx + pi > width) nx = width - pi;
            if (ny + pj < 0) ny = -pj;
            else if (ny + pj > height) ny = height - pj;

            points[pi, pj] = new DisplacementVector(nx, ny);

            QueuePointUpdate(pi, pj);

            return Rectangle.FromLTRB(l, t, r, b);
        }

        private void QueuePointUpdate(int i, int j)
        {
            lock (updateQueue)
            {
                Point p = new Point(i, j);
                if (!updateQueue.Contains(p))
                    updateQueue.Enqueue(p);
            }
            OnUpdateQueued();
        }

        private void OnUpdateQueued()
        {
            if (updateThreadv == null || !updateThreadv.IsAlive)
            {
                updateThreadv = new Thread(new ThreadStart(UpdateLoop));
                updateThreadv.Start();
            }
        }

        public int GetQueueSize()
        {
            lock (updateQueue)
            {
                return updateQueue.Count;
            }
        }

        private void UpdateLoop()
        {
            bool didsomething = false;
            while (GetQueueSize() > 0)
            {
                didsomething = true;
                Point point;
                lock (updateQueue)
                {
                    point = updateQueue.Dequeue();
                }
                if (point.X == -1)
                    QueuedAbort();
                else
                    UpdatePoint(point.X, point.Y);
            }
            if (didsomething)
            {
                OnQueueEmptied();
                didsomething = false;
            }
        }

        private void QueuedAbort()
        {
            lock (updateQueue)
            {
                updateQueue.Clear();
            }
            OnAborted();
            aborted = false;
        }

        public event EventHandler Aborted;
        private void OnAborted()
        {
            if (Aborted != null)
            {
                Aborted(this, EventArgs.Empty);
                aborted = false;
            }
        }

        public event EventHandler QueueEmptied;
        private void OnQueueEmptied()
        {
            if (QueueEmptied != null)
                QueueEmptied(this, EventArgs.Empty);
        }

        private void UpdatePoint(int px, int py)
        {
            int istart = px - 1,
                iend = px + 2,
                jstart = py - 1,
                jend = py + 2;

            if (istart < 0) istart = 0;
            else if (iend > handlesx) iend = handlesx;
            if (jstart < 0) jstart = 0;
            else if (jend > handlesy) jend = handlesy;

            int xstart = (int)(istart * xspacing),
                xend = (int)((iend - 1) * xspacing),
                ystart = (int)(jstart * yspacing),
                yend = (int)((jend - 1) * yspacing);

            //find the invalidated area
            int l = mesh.Width,
                t = mesh.Height,
                r = 0,
                b = 0;

            if (px == 0) l = 0;
            else if (px == width) r = mesh.Width;
            if (py == 0) t = 0;
            else if (py == height) b = mesh.Height;

            for (int j = jstart; j < jend; ++j)
            {
                for (int i = istart; i < iend; ++i)
                {
                    int x = (int)((i + points[i, j].X) * xspacing);
                    int y = (int)((j + points[i, j].Y) * yspacing);

                    if (x < l) l = x;
                    if (x > r) r = x;

                    if (y < t) t = y;
                    if (y > b) b = y;
                }
            }

            if (l < 0) l = 0;
            if (r > mesh.Width) r = mesh.Width;
            if (t < 0) t = 0;
            if (b > mesh.Height) b = mesh.Height;

            UpdatePointVertical(py, jstart, l, r);
            UpdatePointHorizontal(px, istart, t, b);

            OnInvalidated(Rectangle.FromLTRB(l, t, r, b));
        }

        unsafe private void UpdatePointHorizontal(int px, int istart, int ystart, int yend)
        {
            IInterpolator left;
            if (useLinearInterpolation)
                left = new LinearInterpolator();
            else
                left = new CosineInterpolator();

            IInterpolator right;
            if (useLinearInterpolation)
                right = new LinearInterpolator();
            else
                right = new CosineInterpolator();

            for (int j = 0; j < handlesy; ++j)
            {
                left.Add((j + points[istart, j].Y) * yspacing, points[istart, j].X * xspacing);
                right.Add((j + points[istart, j].Y) * yspacing, points[istart, j].X * xspacing);
            }

            for (int i = px - 1; i < px + 1; ++i)
            {
                if (i >= -1 && i < width)
                {
                    if (useLinearInterpolation)
                        right = new LinearInterpolator();
                    else
                        right = new CosineInterpolator();

                    for (int j = 0; j < handlesy; ++j)
                    {
                        right.Add((j + points[i + 1, j].Y) * yspacing, points[i + 1, j].X * xspacing);
                    }
                }

                float itoxleft = i * xspacing;
                float itoxright = (i + 1) * xspacing;

                for (int y = ystart; y < yend; ++y)
                {
                    float
                        leftval = -(float)(left.Interpolate(y)),
                        rightval = -(float)(right.Interpolate(y));

                    int x1 = (int)(itoxleft - leftval);
                    int x2 = (int)(itoxright - rightval) + 1;

                    float xdif = x2 - x1;

                    if (x1 < 0) x1 = 0;
                    if (x2 > mesh.Width) x2 = mesh.Width;

                    DisplacementVector* ptr = mesh.GetPointAddressUnchecked(x1, y);

                    for (int x = x1; x < x2; ++x)
                    {
                        float
                            lerp = (x - x1) / xdif,
                            val = lerp * rightval + (1 - lerp) * leftval;

                        ptr->X = val;
                        ++ptr;
                    }
                }

                left = right;
            }
        }

        unsafe private void UpdatePointVertical(int py, int jstart, int xstart, int xend)
        {
            int stride = mesh.Stride / sizeof(DisplacementVector);

            IInterpolator top;
            if (useLinearInterpolation)
                top = new LinearInterpolator();
            else
                top = new CosineInterpolator();

            IInterpolator bot;
            if (useLinearInterpolation)
                bot = new LinearInterpolator();
            else
                bot = new CosineInterpolator();

            for (int i = 0; i < handlesx; ++i)
            {
                top.Add((i + points[i, jstart].X) * xspacing, points[i, jstart].Y * yspacing);
                bot.Add((i + points[i, jstart].X) * xspacing, points[i, jstart].Y * yspacing);
            }

            for (int j = py - 1; j < py + 1; ++j)
            {
                if (j >= -1 && j < height)
                {
                    if (useLinearInterpolation)
                        bot = new LinearInterpolator();
                    else
                        bot = new CosineInterpolator();

                    for (int i = 0; i < handlesx; ++i)
                    {
                        bot.Add((i + points[i, j + 1].X) * xspacing, points[i, j + 1].Y * yspacing);
                    }
                }

                float jtoytop = j * yspacing;
                float jtoybot = (j + 1) * yspacing;

                for (int x = xstart; x < xend; ++x)
                {
                    float
                        topval = -(float)(top.Interpolate(x)),
                        bottomval = -(float)(bot.Interpolate(x));

                    int y1 = (int)(jtoytop - topval);
                    int y2 = (int)(jtoybot - bottomval) + 1;

                    float ydif = y2 - y1;

                    if (y1 < 0) y1 = 0;
                    if (y2 > mesh.Height) y2 = mesh.Height;

                    DisplacementVector* ptr = mesh.GetPointAddressUnchecked(x, y1);

                    for (int y = y1; y < y2; ++y)
                    {
                        float
                            lerp = (y - y1) / ydif,
                            val = lerp * bottomval + (1 - lerp) * topval;

                        ptr->Y = val;
                        ptr += stride;
                    }
                }
                top = bot;
            }
        }

        public event InvalidateEventHandler Invalidated;
        private void OnInvalidated(Rectangle r)
        {
            InvalidateEventHandler e = Invalidated;
            if (!aborted && e != null)
            {
                e(this, new InvalidateEventArgs(r));
            }
        }

        public DisplacementVector GetPoint(int x, int y)
        {
            return points[x, y];
        }

        bool aborted = false;
        public void Abort()
        {
            aborted = true;
            lock (updateQueue)
            {
                if (updateQueue.Count > 0)
                {
                    updateQueue.Clear();
                    updateQueue.Enqueue(new Point(-1, -1));
                }
            }
            OnUpdateQueued();
            aborted = false;
        }

        public bool IsAborted { get { return aborted; } }

        public void Save(Stream s)
        {
            using (BinaryWriter bw = new BinaryWriter(s))
            {
                bw.Write(handlesx);
                bw.Write(handlesy);

                for (int j = 0; j < handlesy; ++j)
                {
                    for (int i = 0; i < handlesx; ++i)
                    {
                        bw.Write(points[i, j].X);
                        bw.Write(points[i, j].Y);
                    }
                }
            }
        }

        public void UpdateMesh()
        {
            for (int j = 0; j < handlesy; ++j)
            {
                for (int i = 0; i < handlesx; ++i)
                {
                    QueuePointUpdate(i, j);
                }
            }
        }

        public DisplacementGrid Clone()
        {
            DisplacementGrid n = new DisplacementGrid(width, height, mesh, useLinearInterpolation);
            n.points = (DisplacementVector[,])points.Clone();
            return n;
        }
    }
}