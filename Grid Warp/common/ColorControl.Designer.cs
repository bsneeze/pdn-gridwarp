namespace pyrochild.effects.common
{
    partial class ColorControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorControl));
            this.rupdown = new System.Windows.Forms.NumericUpDown();
            this.hex = new System.Windows.Forms.TextBox();
            this.gupdown = new System.Windows.Forms.NumericUpDown();
            this.bupdown = new System.Windows.Forms.NumericUpDown();
            this.hupdown = new System.Windows.Forms.NumericUpDown();
            this.supdown = new System.Windows.Forms.NumericUpDown();
            this.vupdown = new System.Windows.Forms.NumericUpDown();
            this.rlabel = new System.Windows.Forms.Label();
            this.glabel = new System.Windows.Forms.Label();
            this.hlabel = new System.Windows.Forms.Label();
            this.blabel = new System.Windows.Forms.Label();
            this.vlabel = new System.Windows.Forms.Label();
            this.slabel = new System.Windows.Forms.Label();
            this.alabel = new System.Windows.Forms.Label();
            this.aupdown = new System.Windows.Forms.NumericUpDown();
            this.aslider = new pyrochild.effects.common.ColorGradientControl();
            this.gslider = new pyrochild.effects.common.ColorGradientControl();
            this.bslider = new pyrochild.effects.common.ColorGradientControl();
            this.hslider = new pyrochild.effects.common.ColorGradientControl();
            this.sslider = new pyrochild.effects.common.ColorGradientControl();
            this.vslider = new pyrochild.effects.common.ColorGradientControl();
            this.rslider = new pyrochild.effects.common.ColorGradientControl();
            this.wheel = new pyrochild.effects.common.ColorWheel();
            ((System.ComponentModel.ISupportInitialize)(this.rupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aupdown)).BeginInit();
            this.SuspendLayout();
            // 
            // rupdown
            // 
            this.rupdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rupdown.Location = new System.Drawing.Point(288, 1);
            this.rupdown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.rupdown.Name = "rupdown";
            this.rupdown.Size = new System.Drawing.Size(56, 20);
            this.rupdown.TabIndex = 0;
            this.rupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hex
            // 
            this.hex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hex.Location = new System.Drawing.Point(288, 67);
            this.hex.MaxLength = 6;
            this.hex.Name = "hex";
            this.hex.Size = new System.Drawing.Size(56, 20);
            this.hex.TabIndex = 3;
            this.hex.Text = "000000";
            this.hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gupdown
            // 
            this.gupdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gupdown.Location = new System.Drawing.Point(288, 23);
            this.gupdown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.gupdown.Name = "gupdown";
            this.gupdown.Size = new System.Drawing.Size(56, 20);
            this.gupdown.TabIndex = 1;
            this.gupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bupdown
            // 
            this.bupdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bupdown.Location = new System.Drawing.Point(288, 45);
            this.bupdown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bupdown.Name = "bupdown";
            this.bupdown.Size = new System.Drawing.Size(56, 20);
            this.bupdown.TabIndex = 2;
            this.bupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hupdown
            // 
            this.hupdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hupdown.Location = new System.Drawing.Point(288, 94);
            this.hupdown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.hupdown.Name = "hupdown";
            this.hupdown.Size = new System.Drawing.Size(56, 20);
            this.hupdown.TabIndex = 4;
            this.hupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // supdown
            // 
            this.supdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.supdown.Location = new System.Drawing.Point(288, 116);
            this.supdown.Name = "supdown";
            this.supdown.Size = new System.Drawing.Size(56, 20);
            this.supdown.TabIndex = 5;
            this.supdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vupdown
            // 
            this.vupdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vupdown.Location = new System.Drawing.Point(288, 138);
            this.vupdown.Name = "vupdown";
            this.vupdown.Size = new System.Drawing.Size(56, 20);
            this.vupdown.TabIndex = 6;
            this.vupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rlabel
            // 
            this.rlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rlabel.AutoSize = true;
            this.rlabel.Location = new System.Drawing.Point(190, 5);
            this.rlabel.Name = "rlabel";
            this.rlabel.Size = new System.Drawing.Size(15, 13);
            this.rlabel.TabIndex = 30;
            this.rlabel.Text = "R";
            // 
            // glabel
            // 
            this.glabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.glabel.AutoSize = true;
            this.glabel.Location = new System.Drawing.Point(190, 27);
            this.glabel.Name = "glabel";
            this.glabel.Size = new System.Drawing.Size(15, 13);
            this.glabel.TabIndex = 31;
            this.glabel.Text = "G";
            // 
            // hlabel
            // 
            this.hlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hlabel.AutoSize = true;
            this.hlabel.Location = new System.Drawing.Point(190, 98);
            this.hlabel.Name = "hlabel";
            this.hlabel.Size = new System.Drawing.Size(15, 13);
            this.hlabel.TabIndex = 33;
            this.hlabel.Text = "H";
            // 
            // blabel
            // 
            this.blabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blabel.AutoSize = true;
            this.blabel.Location = new System.Drawing.Point(190, 49);
            this.blabel.Name = "blabel";
            this.blabel.Size = new System.Drawing.Size(14, 13);
            this.blabel.TabIndex = 32;
            this.blabel.Text = "B";
            // 
            // vlabel
            // 
            this.vlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vlabel.AutoSize = true;
            this.vlabel.Location = new System.Drawing.Point(190, 142);
            this.vlabel.Name = "vlabel";
            this.vlabel.Size = new System.Drawing.Size(14, 13);
            this.vlabel.TabIndex = 35;
            this.vlabel.Text = "V";
            // 
            // slabel
            // 
            this.slabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.slabel.AutoSize = true;
            this.slabel.Location = new System.Drawing.Point(190, 120);
            this.slabel.Name = "slabel";
            this.slabel.Size = new System.Drawing.Size(14, 13);
            this.slabel.TabIndex = 34;
            this.slabel.Text = "S";
            // 
            // alabel
            // 
            this.alabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alabel.AutoSize = true;
            this.alabel.Location = new System.Drawing.Point(190, 169);
            this.alabel.Name = "alabel";
            this.alabel.Size = new System.Drawing.Size(14, 13);
            this.alabel.TabIndex = 43;
            this.alabel.Text = "A";
            // 
            // aupdown
            // 
            this.aupdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aupdown.Location = new System.Drawing.Point(288, 165);
            this.aupdown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aupdown.Name = "aupdown";
            this.aupdown.Size = new System.Drawing.Size(56, 20);
            this.aupdown.TabIndex = 7;
            this.aupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.aupdown.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // aslider
            // 
            this.aslider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aslider.DrawFarNub = true;
            this.aslider.DrawNearNub = false;
            this.aslider.Gradient = null;
            this.aslider.Location = new System.Drawing.Point(209, 166);
            this.aslider.Name = "aslider";
            this.aslider.Size = new System.Drawing.Size(73, 19);
            this.aslider.TabIndex = 38;
            this.aslider.TabStop = false;
            this.aslider.Value = 1F;
            // 
            // gslider
            // 
            this.gslider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gslider.DrawFarNub = true;
            this.gslider.DrawNearNub = false;
            this.gslider.Gradient = null;
            this.gslider.Location = new System.Drawing.Point(209, 24);
            this.gslider.Name = "gslider";
            this.gslider.Size = new System.Drawing.Size(73, 19);
            this.gslider.TabIndex = 24;
            this.gslider.TabStop = false;
            this.gslider.Value = 0F;
            // 
            // bslider
            // 
            this.bslider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bslider.DrawFarNub = true;
            this.bslider.DrawNearNub = false;
            this.bslider.Gradient = null;
            this.bslider.Location = new System.Drawing.Point(209, 46);
            this.bslider.Name = "bslider";
            this.bslider.Size = new System.Drawing.Size(73, 19);
            this.bslider.TabIndex = 23;
            this.bslider.TabStop = false;
            this.bslider.Value = 0F;
            // 
            // hslider
            // 
            this.hslider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hslider.DrawFarNub = true;
            this.hslider.DrawNearNub = false;
            this.hslider.Gradient = null;
            this.hslider.Location = new System.Drawing.Point(209, 95);
            this.hslider.Name = "hslider";
            this.hslider.Size = new System.Drawing.Size(73, 19);
            this.hslider.TabIndex = 22;
            this.hslider.TabStop = false;
            this.hslider.Value = 0F;
            // 
            // sslider
            // 
            this.sslider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sslider.DrawFarNub = true;
            this.sslider.DrawNearNub = false;
            this.sslider.Gradient = null;
            this.sslider.Location = new System.Drawing.Point(209, 117);
            this.sslider.Name = "sslider";
            this.sslider.Size = new System.Drawing.Size(73, 19);
            this.sslider.TabIndex = 21;
            this.sslider.TabStop = false;
            this.sslider.Value = 0F;
            // 
            // vslider
            // 
            this.vslider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vslider.DrawFarNub = true;
            this.vslider.DrawNearNub = false;
            this.vslider.Gradient = null;
            this.vslider.Location = new System.Drawing.Point(209, 139);
            this.vslider.Name = "vslider";
            this.vslider.Size = new System.Drawing.Size(73, 19);
            this.vslider.TabIndex = 20;
            this.vslider.TabStop = false;
            this.vslider.Value = 0F;
            // 
            // rslider
            // 
            this.rslider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rslider.DrawFarNub = true;
            this.rslider.DrawNearNub = false;
            this.rslider.Gradient = null;
            this.rslider.Location = new System.Drawing.Point(209, 2);
            this.rslider.Name = "rslider";
            this.rslider.Size = new System.Drawing.Size(73, 19);
            this.rslider.TabIndex = 18;
            this.rslider.TabStop = false;
            this.rslider.Value = 0F;
            // 
            // wheel
            // 
            this.wheel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wheel.Color = ((PaintDotNet.ColorBgra)(resources.GetObject("wheel.Color")));
            this.wheel.Location = new System.Drawing.Point(0, 1);
            this.wheel.Name = "wheel";
            this.wheel.Size = new System.Drawing.Size(184, 186);
            this.wheel.TabIndex = 0;
            this.wheel.TabStop = false;
            // 
            // ColorControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.alabel);
            this.Controls.Add(this.aupdown);
            this.Controls.Add(this.aslider);
            this.Controls.Add(this.vlabel);
            this.Controls.Add(this.slabel);
            this.Controls.Add(this.hlabel);
            this.Controls.Add(this.blabel);
            this.Controls.Add(this.glabel);
            this.Controls.Add(this.rlabel);
            this.Controls.Add(this.vupdown);
            this.Controls.Add(this.supdown);
            this.Controls.Add(this.hupdown);
            this.Controls.Add(this.bupdown);
            this.Controls.Add(this.gupdown);
            this.Controls.Add(this.gslider);
            this.Controls.Add(this.bslider);
            this.Controls.Add(this.hslider);
            this.Controls.Add(this.sslider);
            this.Controls.Add(this.vslider);
            this.Controls.Add(this.rslider);
            this.Controls.Add(this.hex);
            this.Controls.Add(this.rupdown);
            this.Controls.Add(this.wheel);
            this.Name = "ColorControl";
            this.Size = new System.Drawing.Size(346, 187);
            ((System.ComponentModel.ISupportInitialize)(this.rupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aupdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorWheel wheel;
        private System.Windows.Forms.NumericUpDown rupdown;
        private System.Windows.Forms.TextBox hex;
        private ColorGradientControl rslider;
        private ColorGradientControl vslider;
        private ColorGradientControl sslider;
        private ColorGradientControl hslider;
        private ColorGradientControl bslider;
        private ColorGradientControl gslider;
        private System.Windows.Forms.NumericUpDown gupdown;
        private System.Windows.Forms.NumericUpDown bupdown;
        private System.Windows.Forms.NumericUpDown hupdown;
        private System.Windows.Forms.NumericUpDown supdown;
        private System.Windows.Forms.NumericUpDown vupdown;
        private System.Windows.Forms.Label rlabel;
        private System.Windows.Forms.Label glabel;
        private System.Windows.Forms.Label hlabel;
        private System.Windows.Forms.Label blabel;
        private System.Windows.Forms.Label vlabel;
        private System.Windows.Forms.Label slabel;
        private System.Windows.Forms.Label alabel;
        private System.Windows.Forms.NumericUpDown aupdown;
        private ColorGradientControl aslider;
    }
}