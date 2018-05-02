namespace csWin2
{
    partial class Bigbang
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
            this.rtbSelected = new System.Windows.Forms.RichTextBox();
            this.clbWords = new System.Windows.Forms.CheckedListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.rtbAddKey = new System.Windows.Forms.RichTextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.btnWebSearch = new System.Windows.Forms.Button();
            this.btnSQLSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbSelected
            // 
            this.rtbSelected.Location = new System.Drawing.Point(281, 60);
            this.rtbSelected.Margin = new System.Windows.Forms.Padding(2);
            this.rtbSelected.Name = "rtbSelected";
            this.rtbSelected.Size = new System.Drawing.Size(213, 131);
            this.rtbSelected.TabIndex = 0;
            this.rtbSelected.Text = "";
            // 
            // clbWords
            // 
            this.clbWords.AllowDrop = true;
            this.clbWords.CheckOnClick = true;
            this.clbWords.FormattingEnabled = true;
            this.clbWords.Location = new System.Drawing.Point(20, 20);
            this.clbWords.Margin = new System.Windows.Forms.Padding(2);
            this.clbWords.Name = "clbWords";
            this.clbWords.Size = new System.Drawing.Size(238, 344);
            this.clbWords.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(20, 391);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(105, 30);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定并保存";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(20, 444);
            this.rtbText.Margin = new System.Windows.Forms.Padding(2);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(1005, 233);
            this.rtbText.TabIndex = 3;
            this.rtbText.Text = "";
            this.rtbText.TextChanged += new System.EventHandler(this.rtbText_TextChanged);
            // 
            // rtbAddKey
            // 
            this.rtbAddKey.Location = new System.Drawing.Point(281, 246);
            this.rtbAddKey.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAddKey.Name = "rtbAddKey";
            this.rtbAddKey.Size = new System.Drawing.Size(213, 131);
            this.rtbAddKey.TabIndex = 0;
            this.rtbAddKey.Text = "";
            this.rtbAddKey.TextChanged += new System.EventHandler(this.rtbAddKey_TextChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(281, 20);
            this.lblKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(82, 15);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "可选关键词";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(281, 205);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(82, 15);
            this.lblAdd.TabIndex = 5;
            this.lblAdd.Text = "添加关键词";
            // 
            // btnWebSearch
            // 
            this.btnWebSearch.Location = new System.Drawing.Point(281, 391);
            this.btnWebSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnWebSearch.Name = "btnWebSearch";
            this.btnWebSearch.Size = new System.Drawing.Size(91, 30);
            this.btnWebSearch.TabIndex = 6;
            this.btnWebSearch.Text = "网页搜索";
            this.btnWebSearch.UseVisualStyleBackColor = true;
            this.btnWebSearch.Click += new System.EventHandler(this.btnWebSearch_Click);
            // 
            // btnSQLSearch
            // 
            this.btnSQLSearch.Location = new System.Drawing.Point(403, 391);
            this.btnSQLSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSQLSearch.Name = "btnSQLSearch";
            this.btnSQLSearch.Size = new System.Drawing.Size(91, 30);
            this.btnSQLSearch.TabIndex = 6;
            this.btnSQLSearch.Text = "搜索库";
            this.btnSQLSearch.UseVisualStyleBackColor = true;
            this.btnSQLSearch.Click += new System.EventHandler(this.btnSQLSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 662);
            this.panel1.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(543, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(430, 317);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // Bigbang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 685);
            this.Controls.Add(this.btnSQLSearch);
            this.Controls.Add(this.btnWebSearch);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.clbWords);
            this.Controls.Add(this.rtbAddKey);
            this.Controls.Add(this.rtbSelected);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Bigbang";
            this.Text = "Bigbang";
            this.Load += new System.EventHandler(this.Bigbang_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSelected;
        private System.Windows.Forms.CheckedListBox clbWords;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.RichTextBox rtbAddKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Button btnWebSearch;
        private System.Windows.Forms.Button btnSQLSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
    }
}