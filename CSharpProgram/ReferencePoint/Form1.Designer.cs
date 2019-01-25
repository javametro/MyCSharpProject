namespace ReferencePoint
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pb_Target = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Target
            // 
            this.pb_Target.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Target.BackgroundImage")));
            this.pb_Target.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_Target.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Target.Image = ((System.Drawing.Image)(resources.GetObject("pb_Target.Image")));
            this.pb_Target.Location = new System.Drawing.Point(137, 50);
            this.pb_Target.Name = "pb_Target";
            this.pb_Target.Size = new System.Drawing.Size(100, 50);
            this.pb_Target.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Target.TabIndex = 0;
            this.pb_Target.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 258);
            this.Controls.Add(this.pb_Target);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Target;
    }
}

