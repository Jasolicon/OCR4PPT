namespace csWin2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pBxOgn = new System.Windows.Forms.PictureBox();
            this.pBxCanny = new System.Windows.Forms.PictureBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rtbOCR = new System.Windows.Forms.RichTextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnMouseRoi = new System.Windows.Forms.Button();
            this.btnBigBang = new System.Windows.Forms.Button();
            this.pbx = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBxOgn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBxCanny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // pBxOgn
            // 
            this.pBxOgn.Location = new System.Drawing.Point(25, 62);
            this.pBxOgn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBxOgn.Name = "pBxOgn";
            this.pBxOgn.Size = new System.Drawing.Size(410, 386);
            this.pBxOgn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBxOgn.TabIndex = 0;
            this.pBxOgn.TabStop = false;
            this.pBxOgn.Click += new System.EventHandler(this.pBxOgn_Click);
            // 
            // pBxCanny
            // 
            this.pBxCanny.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBxCanny.Location = new System.Drawing.Point(447, 62);
            this.pBxCanny.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBxCanny.Name = "pBxCanny";
            this.pBxCanny.Size = new System.Drawing.Size(430, 386);
            this.pBxCanny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBxCanny.TabIndex = 1;
            this.pBxCanny.TabStop = false;
            this.pBxCanny.Click += new System.EventHandler(this.pBxCanny_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(25, 26);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(516, 25);
            this.txtPath.TabIndex = 3;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(575, 26);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(95, 26);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(701, 26);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(89, 26);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "图片处理";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // rtbOCR
            // 
            this.rtbOCR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOCR.Location = new System.Drawing.Point(25, 543);
            this.rtbOCR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbOCR.Name = "rtbOCR";
            this.rtbOCR.Size = new System.Drawing.Size(1306, 200);
            this.rtbOCR.TabIndex = 6;
            this.rtbOCR.Text = "";
            this.rtbOCR.TextChanged += new System.EventHandler(this.rtbOCR_TextChanged);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLast.Location = new System.Drawing.Point(25, 486);
            this.btnLast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(95, 31);
            this.btnLast.TabIndex = 7;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNext.Location = new System.Drawing.Point(316, 486);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(92, 31);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnMouseRoi
            // 
            this.btnMouseRoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMouseRoi.Location = new System.Drawing.Point(172, 486);
            this.btnMouseRoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnMouseRoi.Name = "btnMouseRoi";
            this.btnMouseRoi.Size = new System.Drawing.Size(99, 31);
            this.btnMouseRoi.TabIndex = 8;
            this.btnMouseRoi.Text = "截图";
            this.btnMouseRoi.UseVisualStyleBackColor = true;
            this.btnMouseRoi.Click += new System.EventHandler(this.btnMouseRoi_Click);
            // 
            // btnBigBang
            // 
            this.btnBigBang.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBigBang.Location = new System.Drawing.Point(1187, 486);
            this.btnBigBang.Margin = new System.Windows.Forms.Padding(2);
            this.btnBigBang.Name = "btnBigBang";
            this.btnBigBang.Size = new System.Drawing.Size(144, 31);
            this.btnBigBang.TabIndex = 9;
            this.btnBigBang.Text = "文字结果处理";
            this.btnBigBang.UseVisualStyleBackColor = true;
            this.btnBigBang.Click += new System.EventHandler(this.btnBigBang_Click);
            // 
            // pbx
            // 
            this.pbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbx.Location = new System.Drawing.Point(901, 62);
            this.pbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(430, 386);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx.TabIndex = 1;
            this.pbx.TabStop = false;
            this.pbx.Click += new System.EventHandler(this.pBxCanny_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 486);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "文字提取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1466, 754);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBigBang);
            this.Controls.Add(this.btnMouseRoi);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.rtbOCR);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.pbx);
            this.Controls.Add(this.pBxCanny);
            this.Controls.Add(this.pBxOgn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBxOgn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBxCanny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBxOgn;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnMouseRoi;
        public System.Windows.Forms.PictureBox pBxCanny;
        public System.Windows.Forms.RichTextBox rtbOCR;
        private System.Windows.Forms.Button btnBigBang;
        public System.Windows.Forms.PictureBox pbx;
        private System.Windows.Forms.Button button1;
    }
}

