using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using pyrochild.effects.common;

namespace pyrochild.effects.gridwarp
{
    partial class ConfigDialog
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
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
                //if (historystack != null)
                //    historystack.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.toolPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.visibility = new System.Windows.Forms.Button();
            this.settingStrip = new System.Windows.Forms.ToolStrip();
            this.gridSizeSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.gridSizeDecrement = new System.Windows.Forms.ToolStripButton();
            this.gridWidth = new System.Windows.Forms.ToolStripComboBox();
            this.gridSizeLabel = new System.Windows.Forms.ToolStripLabel();
            this.gridHeight = new System.Windows.Forms.ToolStripComboBox();
            this.gridSizeIncrement = new System.Windows.Forms.ToolStripButton();
            this.gridSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomOut = new System.Windows.Forms.ToolStripButton();
            this.zoom = new System.Windows.Forms.ToolStripComboBox();
            this.zoomIn = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.donate = new System.Windows.Forms.LinkLabel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.canvas = new pyrochild.effects.common.CanvasPanel();
            this.toolPanel.SuspendLayout();
            this.settingStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolPanel
            // 
            this.toolPanel.Controls.Add(this.load);
            this.toolPanel.Controls.Add(this.save);
            this.toolPanel.Controls.Add(this.visibility);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolPanel.Location = new System.Drawing.Point(0, 25);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(30, 417);
            this.toolPanel.TabIndex = 0;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(2, 2);
            this.load.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(26, 26);
            this.load.TabIndex = 4;
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(2, 28);
            this.save.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(26, 26);
            this.save.TabIndex = 5;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // visibility
            // 
            this.visibility.Location = new System.Drawing.Point(2, 68);
            this.visibility.Margin = new System.Windows.Forms.Padding(2, 14, 2, 0);
            this.visibility.Name = "visibility";
            this.visibility.Size = new System.Drawing.Size(26, 26);
            this.visibility.TabIndex = 6;
            this.visibility.UseVisualStyleBackColor = true;
            this.visibility.Click += new System.EventHandler(this.visbility_Click);
            // 
            // settingStrip
            // 
            this.settingStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.settingStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeSeparator,
            this.toolStripLabel1,
            this.gridSizeDecrement,
            this.gridWidth,
            this.gridSizeLabel,
            this.gridHeight,
            this.gridSizeIncrement,
            this.gridSeparator,
            this.undo,
            this.redo,
            this.toolStripSeparator2,
            this.zoomOut,
            this.zoom,
            this.zoomIn});
            this.settingStrip.Location = new System.Drawing.Point(0, 0);
            this.settingStrip.Name = "settingStrip";
            this.settingStrip.Size = new System.Drawing.Size(624, 25);
            this.settingStrip.TabIndex = 1;
            this.settingStrip.Text = "toolStrip1";
            // 
            // gridSizeSeparator
            // 
            this.gridSizeSeparator.Name = "gridSizeSeparator";
            this.gridSizeSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Grid Size:";
            // 
            // gridSizeDecrement
            // 
            this.gridSizeDecrement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gridSizeDecrement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gridSizeDecrement.Name = "gridSizeDecrement";
            this.gridSizeDecrement.Size = new System.Drawing.Size(23, 22);
            this.gridSizeDecrement.Click += new System.EventHandler(this.gridSizeDecrement_Click);
            // 
            // gridWidth
            // 
            this.gridWidth.AutoSize = false;
            this.gridWidth.Name = "gridWidth";
            this.gridWidth.Size = new System.Drawing.Size(44, 23);
            this.gridWidth.Validating += new System.ComponentModel.CancelEventHandler(this.gridSize_Validating);
            this.gridWidth.TextChanged += new System.EventHandler(this.gridSize_Validating);
            // 
            // gridSizeLabel
            // 
            this.gridSizeLabel.Name = "gridSizeLabel";
            this.gridSizeLabel.Size = new System.Drawing.Size(12, 22);
            this.gridSizeLabel.Text = "x";
            // 
            // gridHeight
            // 
            this.gridHeight.AutoSize = false;
            this.gridHeight.Name = "gridHeight";
            this.gridHeight.Size = new System.Drawing.Size(44, 23);
            this.gridHeight.Validating += new System.ComponentModel.CancelEventHandler(this.gridSize_Validating);
            this.gridHeight.TextChanged += new System.EventHandler(this.gridSize_Validating);
            // 
            // gridSizeIncrement
            // 
            this.gridSizeIncrement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gridSizeIncrement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gridSizeIncrement.Name = "gridSizeIncrement";
            this.gridSizeIncrement.Size = new System.Drawing.Size(23, 22);
            this.gridSizeIncrement.Click += new System.EventHandler(this.gridSizeIncrement_Click);
            // 
            // gridSeparator
            // 
            this.gridSeparator.Name = "gridSeparator";
            this.gridSeparator.Size = new System.Drawing.Size(6, 25);
            this.gridSeparator.Visible = false;
            // 
            // undo
            // 
            this.undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undo.Enabled = false;
            this.undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 22);
            this.undo.Visible = false;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redo.Enabled = false;
            this.redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(23, 22);
            this.redo.Visible = false;
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomOut
            // 
            this.zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(23, 22);
            this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // zoom
            // 
            this.zoom.AutoSize = false;
            this.zoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(58, 23);
            this.zoom.SelectedIndexChanged += new System.EventHandler(this.zoom_SelectedIndexChanged);
            // 
            // zoomIn
            // 
            this.zoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(23, 22);
            this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ok);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.donate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(30, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 30);
            this.panel1.TabIndex = 1;
            // 
            // ok
            // 
            this.ok.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(435, 4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 3;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(516, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // donate
            // 
            this.donate.AutoSize = true;
            this.donate.Location = new System.Drawing.Point(6, 10);
            this.donate.Name = "donate";
            this.donate.Size = new System.Drawing.Size(45, 13);
            this.donate.TabIndex = 5;
            this.donate.TabStop = true;
            this.donate.Text = "Donate!";
            this.donate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.donate_LinkClicked);
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.AutoScroll = true;
            this.canvas.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.canvas.BrushSize = 0;
            this.canvas.BrushVisible = false;
            this.canvas.CanvasBackColor = System.Drawing.Color.Transparent;
            this.canvas.Location = new System.Drawing.Point(30, 25);
            this.canvas.MouseHoldInterval = 100;
            this.canvas.Name = "canvas";
            this.canvas.Selection = null;
            this.canvas.Size = new System.Drawing.Size(594, 387);
            this.canvas.Surface = null;
            this.canvas.TabIndex = 2;
            this.canvas.ZoomFactor = 1F;
            this.canvas.CanvasPaint += new System.Windows.Forms.PaintEventHandler(this.canvas_CanvasPaint);
            this.canvas.CanvasMouseDown += new System.EventHandler<pyrochild.effects.common.CanvasMouseEventArgs>(this.canvas_CanvasMouseDown);
            this.canvas.CanvasMouseMove += new System.EventHandler<pyrochild.effects.common.CanvasMouseEventArgs>(this.canvas_CanvasMouseMove);
            this.canvas.CanvasMouseUp += new System.EventHandler<pyrochild.effects.common.CanvasMouseEventArgs>(this.canvas_CanvasMouseUp);
            this.canvas.ZoomFactorChanged += new System.EventHandler(this.canvas_ZoomFactorChanged);
            // 
            // ConfigDialog
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.settingStrip);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "ConfigDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Auto;
            this.Load += new System.EventHandler(this.ConfigDialog_Load);
            this.toolPanel.ResumeLayout(false);
            this.settingStrip.ResumeLayout(false);
            this.settingStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private FlowLayoutPanel toolPanel;
        private ToolStrip settingStrip;
        private Panel panel1;
        private Button ok;
        private Button cancel;
        private LinkLabel donate;
        private ToolStripSeparator gridSizeSeparator;
        private ToolStripLabel  gridSizeLabel;
        private ToolStripButton gridSizeDecrement;
        private ToolStripComboBox gridWidth;
        private ToolStripButton gridSizeIncrement;
        private ToolStripSeparator gridSeparator;
        private CanvasPanel canvas;
        private Button load;
        private Button save;
        private ToolTip tooltip;
        private ToolStripButton undo;
        private ToolStripButton redo;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton zoomOut;
        private ToolStripComboBox zoom;
        private ToolStripButton zoomIn;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox gridHeight;
        private Button visibility;
    }
}