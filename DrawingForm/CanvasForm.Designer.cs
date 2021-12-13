
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
            this.SuspendLayout();
            // 
            // UseRectangleButton
            // 
            this.UseRectangleButton.Location = new System.Drawing.Point(337, 12);
            this.UseRectangleButton.Name = "UseRectangleButton";
            this.UseRectangleButton.Size = new System.Drawing.Size(331, 125);
            this.UseRectangleButton.TabIndex = 0;
            this.UseRectangleButton.Text = "Rectangle";
            this.UseRectangleButton.UseVisualStyleBackColor = true;
            this.UseRectangleButton.Click += new System.EventHandler(this.UseRectangleButton_Click);
            // 
            // UseEllipseButton
            // 
            this.UseEllipseButton.Location = new System.Drawing.Point(821, 12);
            this.UseEllipseButton.Name = "UseEllipseButton";
            this.UseEllipseButton.Size = new System.Drawing.Size(331, 125);
            this.UseEllipseButton.TabIndex = 0;
            this.UseEllipseButton.Text = "Ellipse";
            this.UseEllipseButton.UseVisualStyleBackColor = true;
            this.UseEllipseButton.Click += new System.EventHandler(this.UseEllipseButton_Click);
            // 
            // ClearCanvasButton
            // 
            this.ClearCanvasButton.Location = new System.Drawing.Point(1311, 12);
            this.ClearCanvasButton.Name = "ClearCanvasButton";
            this.ClearCanvasButton.Size = new System.Drawing.Size(331, 125);
            this.ClearCanvasButton.TabIndex = 0;
            this.ClearCanvasButton.Text = "Clear";
            this.ClearCanvasButton.UseVisualStyleBackColor = true;
            this.ClearCanvasButton.Click += new System.EventHandler(this.ClearCanvasButton_Click);
            // 
            // CanvasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1962, 1298);
            this.Controls.Add(this.ClearCanvasButton);
            this.Controls.Add(this.UseEllipseButton);
            this.Controls.Add(this.UseRectangleButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CanvasForm";
            this.Text = "Canvas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UseRectangleButton;
        private System.Windows.Forms.Button UseEllipseButton;
        private System.Windows.Forms.Button ClearCanvasButton;
    }
}

