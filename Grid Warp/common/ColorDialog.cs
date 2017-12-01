using PaintDotNet;
using System;
using System.Windows.Forms;

namespace pyrochild.effects.common
{
    public partial class ColorDialog : Form
    {
        public ColorDialog()
        {
            InitializeComponent();
        }

        public ColorBgra Color
        {
            get => colorControl.Color;
            set => colorControl.Color = value;
        }

        public bool HasAlpha
        {
            get => colorControl.HasAlpha;
            set => colorControl.HasAlpha = value;
        }

        public Surface BackgroundSurface { get; set; }

        public event EventHandler ColorChanged;

        private void OnColorChanged(object sender, EventArgs e)
        {
            ColorChanged?.Invoke(sender, e);
        }
    }
}
