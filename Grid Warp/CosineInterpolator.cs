using System;
using System.Collections.Generic;

namespace pyrochild.effects.gridwarp
{
    public sealed class CosineInterpolator
    {
        private SortedList<float, float> points = new SortedList<float, float>();

        public void Add(float x, float y)
        {
            this.points[x] = y;
        }

        public void Clear()
        {
            this.points.Clear();
        }

        public float Interpolate(float x)
        {
            IList<float> xa = this.points.Keys;
            IList<float> ya = this.points.Values;

            if (x < xa[0])
                return ya[0];

            for (int i = 0; i < Count - 1; ++i)
            {
                if (xa[i + 1] > x)
                {
                    float xfactor = (x - xa[i]) / (xa[i + 1] - xa[i]);
                    float yfactor = (float)(1 - Math.Cos(xfactor * Math.PI)) / 2;
                    return yfactor * ya[i + 1] + (1 - yfactor) * ya[i];
                }
            }

            return ya[Count - 1];
        }

        public int Count
        {
            get
            {
                return this.points.Count;
            }
        }
    }
}
