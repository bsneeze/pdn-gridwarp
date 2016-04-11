using System.Runtime.InteropServices;

namespace pyrochild.effects.gridwarp
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DisplacementVector
    {
        [FieldOffset(0)]
        public float X;

        [FieldOffset(4)]
        public float Y;

        public DisplacementVector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public int SizeOf
        {
            get { return 8; }
        }

        public static DisplacementVector Zero
        {
            get
            {
                return new DisplacementVector();
            }
        }

        public static DisplacementVector Lerp(DisplacementVector lhs, DisplacementVector rhs, float factor)
        {
            return new DisplacementVector(
                lhs.X * (1 - factor) + rhs.X * factor,
                lhs.Y * (1 - factor) + rhs.Y * factor);
        }
    }
}