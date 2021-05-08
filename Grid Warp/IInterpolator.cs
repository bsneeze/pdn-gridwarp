using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrochild.effects.gridwarp
{
    public interface IInterpolator
    {
        float Interpolate(float x);

        void Add(float x, float y);

        void Clear();

        int Count { get; }
    }
}
