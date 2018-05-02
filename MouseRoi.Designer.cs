namespace csWin2
{
    partial class MouseRoi
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
            this.btnROIConfirm = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPreView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnROIConfirm
            // 
            this.btnROIConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnROIConfirm.AutoSize = true;
            this.btnROIConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnROIConfirm.Location = new System.Drawing.Point(1126, 96);
            this.btnROIConfirm.Name = "btnROIConfirm";
            this.btnROIConfirm.Size = new System.Drawing.Size(62, 31);
            this.btnROIConfirm.TabIndex = 0;
            this.btnROIConfirm.Text = "确认";
            this.btnROIConfirm.UseVisualStyleBackColor = true;
            this.btnROIConfirm.Click += new System.EventHandler(this.btnROIConfirm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1108, 753);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1126, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPreView
            // 
            this.btnPreView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreView.AutoSize = true;
            this.btnPreView.Location = new System.Drawing.Point(1126, 53);
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(62, 37);
            this.btnPreView.TabIndex = 3;
            this.btnPreView.Text = "预览";
            this.btnPreView.UseVisualStyleBackColor = true;
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // MouseRoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 787);
            this.Controls.Add(this.btnPreView);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnROIConfirm);
            this.Name = "MouseRoi";
            this.Text = "MouseRoi";
            this.Load += new System.EventHandler(this.MouseRoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnROIConfirm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreView;
    }
}