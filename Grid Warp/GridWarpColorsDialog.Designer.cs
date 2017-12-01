using pyrochild.effects.common;

namespace pyrochild.effects.gridwarp
{
    partial class GridWarpColorsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridWarpColorsDialog));
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.backgroundLabel = new System.Windows.Forms.Label();
            this.gridLinesLabel = new System.Windows.Forms.Label();
            this.frameLabel = new System.Windows.Forms.Label();
            this.fromClipboard = new System.Windows.Forms.CheckBox();
            this.clipboardPreview = new System.Windows.Forms.PictureBox();
            this.frameColor = new pyrochild.effects.common.ColorControl();
            this.gridLineColor = new pyrochild.effects.common.ColorControl();
            this.backgroundColor = new pyrochild.effects.common.ColorControl();
            ((System.ComponentModel.ISupportInitialize)(this.clipboardPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(140, 575);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 4;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(221, 575);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundLabel.Location = new System.Drawing.Point(12, 150);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(65, 13);
            this.backgroundLabel.TabIndex = 40;
            this.backgroundLabel.Text = "Background";
            // 
            // gridLinesLabel
            // 
            this.gridLinesLabel.AutoSize = true;
            this.gridLinesLabel.Location = new System.Drawing.Point(12, 541);
            this.gridLinesLabel.Name = "gridLinesLabel";
            this.gridLinesLabel.Size = new System.Drawing.Size(50, 13);
            this.gridLinesLabel.TabIndex = 41;
            this.gridLinesLabel.Text = "Grid lines";
            // 
            // frameLabel
            // 
            this.frameLabel.AutoSize = true;
            this.frameLabel.Location = new System.Drawing.Point(12, 371);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(36, 13);
            this.frameLabel.TabIndex = 42;
            this.frameLabel.Text = "Frame";
            // 
            // fromClipboard
            // 
            this.fromClipboard.AutoSize = true;
            this.fromClipboard.Enabled = false;
            this.fromClipboard.Location = new System.Drawing.Point(15, 173);
            this.fromClipboard.Name = "fromClipboard";
            this.fromClipboard.Size = new System.Drawing.Size(95, 17);
            this.fromClipboard.TabIndex = 1;
            this.fromClipboard.Text = "From clipboard";
            this.fromClipboard.UseVisualStyleBackColor = true;
            this.fromClipboard.CheckedChanged += new System.EventHandler(this.fromClipboard_CheckedChanged);
            // 
            // clipboardPreview
            // 
            this.clipboardPreview.Location = new System.Drawing.Point(107, 157);
            this.clipboardPreview.Name = "clipboardPreview";
            this.clipboardPreview.Size = new System.Drawing.Size(33, 33);
            this.clipboardPreview.TabIndex = 44;
            this.clipboardPreview.TabStop = false;
            // 
            // frameColor
            // 
            this.frameColor.BackColor = System.Drawing.Color.White;
            this.frameColor.Color = ((PaintDotNet.ColorBgra)(resources.GetObject("frameColor.Color")));
            this.frameColor.HasAlpha = false;
            this.frameColor.Location = new System.Drawing.Point(8, 229);
            this.frameColor.Name = "frameColor";
            this.frameColor.Size = new System.Drawing.Size(294, 159);
            this.frameColor.TabIndex = 2;
            this.frameColor.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // gridLineColor
            // 
            this.gridLineColor.BackColor = System.Drawing.Color.White;
            this.gridLineColor.Color = ((PaintDotNet.ColorBgra)(resources.GetObject("gridLineColor.Color")));
            this.gridLineColor.HasAlpha = false;
            this.gridLineColor.Location = new System.Drawing.Point(8, 399);
            this.gridLineColor.Name = "gridLineColor";
            this.gridLineColor.Size = new System.Drawing.Size(294, 159);
            this.gridLineColor.TabIndex = 3;
            this.gridLineColor.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // backgroundColor
            // 
            this.backgroundColor.BackColor = System.Drawing.Color.White;
            this.backgroundColor.Color = ((PaintDotNet.ColorBgra)(resources.GetObject("backgroundColor.Color")));
            this.backgroundColor.HasAlpha = true;
            this.backgroundColor.Location = new System.Drawing.Point(8, 8);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(294, 190);
            this.backgroundColor.TabIndex = 0;
            this.backgroundColor.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // GridWarpColorsDialog
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(308, 610);
            this.Controls.Add(this.clipboardPreview);
            this.Controls.Add(this.fromClipboard);
            this.Controls.Add(this.frameLabel);
            this.Controls.Add(this.gridLinesLabel);
            this.Controls.Add(this.backgroundLabel);
            this.Controls.Add(this.frameColor);
            this.Controls.Add(this.gridLineColor);
            this.Controls.Add(this.backgroundColor);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridWarpColorsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.clipboardPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private ColorControl backgroundColor;
        private ColorControl gridLineColor;
        private ColorControl frameColor;
        private System.Windows.Forms.Label backgroundLabel;
        private System.Windows.Forms.Label gridLinesLabel;
        private System.Windows.Forms.Label frameLabel;
        private System.Windows.Forms.CheckBox fromClipboard;
        private System.Windows.Forms.PictureBox clipboardPreview;
    }
}