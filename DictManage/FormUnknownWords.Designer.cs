namespace DictManage
{
    partial class FormUnknownWords
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnknownWords));
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxWords = new System.Windows.Forms.ListBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.checkBoxOther = new System.Windows.Forms.CheckBox();
            this.checkBoxDisable = new System.Windows.Forms.CheckBox();
            this.buttonDisable = new System.Windows.Forms.Button();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonBatchInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(78, 28);
            this.numericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(134, 21);
            this.numericUpDown.TabIndex = 0;
            this.numericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "阈值";
            // 
            // listBoxWords
            // 
            this.listBoxWords.FormattingEnabled = true;
            this.listBoxWords.ItemHeight = 12;
            this.listBoxWords.Location = new System.Drawing.Point(44, 110);
            this.listBoxWords.MultiColumn = true;
            this.listBoxWords.Name = "listBoxWords";
            this.listBoxWords.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxWords.Size = new System.Drawing.Size(694, 424);
            this.listBoxWords.TabIndex = 2;
            // 
            // checkBoxName
            // 
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Checked = true;
            this.checkBoxName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxName.Location = new System.Drawing.Point(44, 72);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(48, 16);
            this.checkBoxName.TabIndex = 3;
            this.checkBoxName.Text = "人名";
            this.checkBoxName.UseVisualStyleBackColor = true;
            this.checkBoxName.CheckedChanged += new System.EventHandler(this.checkBoxName_CheckedChanged);
            // 
            // checkBoxOther
            // 
            this.checkBoxOther.AutoSize = true;
            this.checkBoxOther.Checked = true;
            this.checkBoxOther.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOther.Location = new System.Drawing.Point(98, 72);
            this.checkBoxOther.Name = "checkBoxOther";
            this.checkBoxOther.Size = new System.Drawing.Size(48, 16);
            this.checkBoxOther.TabIndex = 4;
            this.checkBoxOther.Text = "其他";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            this.checkBoxOther.CheckedChanged += new System.EventHandler(this.checkBoxOther_CheckedChanged);
            // 
            // checkBoxDisable
            // 
            this.checkBoxDisable.AutoSize = true;
            this.checkBoxDisable.Location = new System.Drawing.Point(152, 72);
            this.checkBoxDisable.Name = "checkBoxDisable";
            this.checkBoxDisable.Size = new System.Drawing.Size(60, 16);
            this.checkBoxDisable.TabIndex = 5;
            this.checkBoxDisable.Text = "屏蔽的";
            this.checkBoxDisable.UseVisualStyleBackColor = true;
            this.checkBoxDisable.CheckedChanged += new System.EventHandler(this.checkBoxDisable_CheckedChanged);
            // 
            // buttonDisable
            // 
            this.buttonDisable.Location = new System.Drawing.Point(232, 25);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(75, 23);
            this.buttonDisable.TabIndex = 6;
            this.buttonDisable.Text = "屏蔽";
            this.buttonDisable.UseVisualStyleBackColor = true;
            this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
            // 
            // buttonEnable
            // 
            this.buttonEnable.Location = new System.Drawing.Point(323, 26);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(75, 23);
            this.buttonEnable.TabIndex = 7;
            this.buttonEnable.Text = "解屏蔽";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // buttonBatchInsert
            // 
            this.buttonBatchInsert.Location = new System.Drawing.Point(409, 26);
            this.buttonBatchInsert.Name = "buttonBatchInsert";
            this.buttonBatchInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonBatchInsert.TabIndex = 8;
            this.buttonBatchInsert.Text = "批量加入字典";
            this.buttonBatchInsert.UseVisualStyleBackColor = true;
            this.buttonBatchInsert.Click += new System.EventHandler(this.buttonBatchInsert_Click);
            // 
            // FormUnknownWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 572);
            this.Controls.Add(this.buttonBatchInsert);
            this.Controls.Add(this.buttonEnable);
            this.Controls.Add(this.buttonDisable);
            this.Controls.Add(this.checkBoxDisable);
            this.Controls.Add(this.checkBoxOther);
            this.Controls.Add(this.checkBoxName);
            this.Controls.Add(this.listBoxWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUnknownWords";
            this.Text = "FormUnknownWords";
            this.Load += new System.EventHandler(this.FormUnknownWords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxWords;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.CheckBox checkBoxOther;
        private System.Windows.Forms.CheckBox checkBoxDisable;
        private System.Windows.Forms.Button buttonDisable;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Button buttonBatchInsert;
    }
}