
namespace DrawingForm
{
    partial class CanvasForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.UseRectangleButton = new System.Windows.Forms.Button();
            this.UseEllipseButton = new System.Windows.Forms.Button();
            this.ClearCanvasButton = new System.Windows.Forms.Button();
            this.UseLineButton = new System.Windows.Forms.Button();
            this.CanvasFormMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CanvasFormMainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // UseRectangleButton
            // 
            this.UseRectangleButton.Location = new System.Drawing.Point(185, 58);
            this.UseRectangleButton.Name = "UseRectangleButton";
            this.UseRectangleButton.Size = new System.Drawing.Size(331, 125);
            this.UseRectangleButton.TabIndex = 0;
            this.UseRectangleButton.Text = "Rectangle";
            this.UseRectangleButton.UseVisualStyleBackColor = true;
            this.UseRectangleButton.Click += new System.EventHandler(this.UseRectangleButton_Click);
            // 
            // UseEllipseButton
            // 
            this.UseEllipseButton.Location = new System.Drawing.Point(983, 58);
            this.UseEllipseButton.Name = "UseEllipseButton";
            this.UseEllipseButton.Size = new System.Drawing.Size(331, 125);
            this.UseEllipseButton.TabIndex = 0;
            this.UseEllipseButton.Text = "Ellipse";
            this.UseEllipseButton.UseVisualStyleBackColor = true;
            this.UseEllipseButton.Click += new System.EventHandler(this.UseEllipseButton_Click);
            // 
            // ClearCanvasButton
            // 
            this.ClearCanvasButton.Location = new System.Drawing.Point(1401, 58);
            this.ClearCanvasButton.Name = "ClearCanvasButton";
            this.ClearCanvasButton.Size = new System.Drawing.Size(331, 125);
            this.ClearCanvasButton.TabIndex = 0;
            this.ClearCanvasButton.Text = "Clear";
            this.ClearCanvasButton.UseVisualStyleBackColor = true;
            this.ClearCanvasButton.Click += new System.EventHandler(this.ClearCanvasButton_Click);
            // 
            // UseLineButton
            // 
            this.UseLineButton.Location = new System.Drawing.Point(580, 58);
            this.UseLineButton.Name = "UseLineButton";
            this.UseLineButton.Size = new System.Drawing.Size(331, 125);
            this.UseLineButton.TabIndex = 1;
            this.UseLineButton.Text = "Line";
            this.UseLineButton.UseVisualStyleBackColor = true;
            this.UseLineButton.Click += new System.EventHandler(this.UseLineButton_Click);
            // 
            // CanvasFormMainMenuStrip
            // 
            this.CanvasFormMainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.CanvasFormMainMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.CanvasFormMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem});
            this.CanvasFormMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.CanvasFormMainMenuStrip.Name = "CanvasFormMainMenuStrip";
            this.CanvasFormMainMenuStrip.Size = new System.Drawing.Size(1962, 42);
            this.CanvasFormMainMenuStrip.TabIndex = 2;
            this.CanvasFormMainMenuStrip.Text = "menuStrip1";
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(96, 38);
            this.UndoToolStripMenuItem.Text = "Undo";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(92, 38);
            this.RedoToolStripMenuItem.Text = "Redo";
            this.RedoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // CanvasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1962, 1298);
            this.Controls.Add(this.UseLineButton);
            this.Controls.Add(this.ClearCanvasButton);
            this.Controls.Add(this.UseEllipseButton);
            this.Controls.Add(this.UseRectangleButton);
            this.Controls.Add(this.CanvasFormMainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.CanvasFormMainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "CanvasForm";
            this.Text = "Canvas";
            this.CanvasFormMainMenuStrip.ResumeLayout(false);
            this.CanvasFormMainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UseRectangleButton;
        private System.Windows.Forms.Button UseEllipseButton;
        private System.Windows.Forms.Button ClearCanvasButton;
        private System.Windows.Forms.Button UseLineButton;
        private System.Windows.Forms.MenuStrip CanvasFormMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
    }
}

