using PaintDotNet.Effects;

namespace pyrochild.effects.gridwarp
{
    class ConfigToken : EffectConfigToken
    {
        public DisplacementGrid grid;
        public DisplacementMesh mesh;

        //these are just what were last selected in the dialog, so it can "remember" between uses
        public int width;
        public int height;

        public ConfigToken()
        {
            width = 4;
            height = 3;
        }

        public ConfigToken(ConfigToken toCopy)
        {
            this.mesh = toCopy.mesh;
            this.grid = toCopy.grid;
            this.width = toCopy.width;
            this.height = toCopy.height;
        }

        public override object Clone()
        {
            return new ConfigToken(this);
        }
    }
}