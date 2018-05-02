using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTDictSeg;
using FTAlgorithm;
using System.Diagnostics;
namespace csWin2
{
    public partial class Bigbang : Form
    {
        Form1 f1;
        string word;

        public static CSimpleDictSeg m_SimpleDictSeg;

        string strSelected = null;

        public Bigbang()
        {
            InitializeComponent();
        }

        private void Bigbang_Load(object sender, EventArgs e)
        {
            f1 = (Form1)this.Owner;
            word = f1.rtbString;
            rtbText.Text = word;

            
            //rtbAddKey.EnableAutoDragDrop = true;
            rtbAddKey.AllowDrop = true;
            //rtbText.EnableAutoDragDrop = true;
            rtbText.MouseDown += new MouseEventHandler(rtbText_MouseDown);
            rtbAddKey.DragEnter += new DragEventHandler(rtbAddKey_DragEnter);
            rtbAddKey.DragDrop += new DragEventHandler(rtbAddKey_DragDrop);
            

            BigBangDemo();
            //BigBangSetButton();
            //BigBangSetCheckList();
            clbWords.ItemCheck += clbWords_ItemCheck;
            clbWords.SelectedIndexChanged += clbWords_SelectedIndexChanged;
            
        }

        
        private void rtbText_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbText.SelectedText))
                if (e.Button == MouseButtons.Left)
                    //rtbAddKey.Text = rtbText.SelectedText;

                    rtbText.DoDragDrop(rtbText.SelectedText, DragDropEffects.Move);
        }

        
        private void rtbAddKey_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void rtbAddKey_DragDrop(object sender,DragEventArgs e)
        {
            if (string.IsNullOrEmpty(rtbAddKey.Text))
                rtbAddKey.Text += e.Data.GetData(DataFormats.Text).ToString();
            else
                rtbAddKey.Text += ("\n" + e.Data.GetData(DataFormats.Text).ToString());
        }
        

        private int idx;
        private CheckState checkValue;

         
        private void clbWords_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            idx = e.Index;
            checkValue = e.NewValue;
        }

        private void clbWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (checkValue)
            {
                case CheckState.Checked:
                    {
                        strSelected = BigBangMakeString();
                    }
                    break;

                case CheckState.Unchecked:
                    {
                        strSelected=BigBangMakeString();
                    }
                    break;
            }
            rtbSelected.Text = strSelected;
        }

        //private void BigBangSetButton()
        //{
        //    int i = 0;
        //    int j = 1;
        //    int posX = oriX;
        //    int posY = oriY;
        //    foreach (char x in word)
        //    { 
        //        //if (UnicodeEncoding.Equals(x, '好')||UnicodeEncoding.Equals(x,'a'))
        //        //{
        //            Button btn = new Button();
        //            btn.Visible = true;

        //            btn.Text = x.ToString();
        //            string id = ("btn" + x.ToString());
        //            btn.Name = id;
        //            posX = posX + i * btn.Height* btn.Text.Length + 10;
        //            if (posX + i * btn.Height * btn.Text.Length + 10 >= this.Size.Width)
        //            {
        //                posX = oriX;
        //                posY = posY + j * btn.Height + 10;
        //                j++;
        //            }
        //            btn.Location = new Point(posX,posY);
        //            btn.MouseClick += new MouseEventHandler(btnOperation);
        //            btn.Show();
        //        //}
        //        i++;
        //    }
        //}

        //private void BigBangSetCheckList()
        //{
        //    foreach (char x in word)
        //    {
        //        clbWords.Items.Add(x.ToString());
        //    }
            
        //}

        private string BigBangMakeString()
        {
            string strCollected = string.Empty;
            for (int i = 0; i < clbWords.Items.Count; i++)
            {
                if (clbWords.GetItemChecked(i))
                {
                    if (strCollected == string.Empty)
                    {
                        strCollected = clbWords.GetItemText(
                       clbWords.Items[i]);
                    }
                    else
                    {
                        strCollected = strCollected + clbWords.
                       GetItemText(clbWords.Items[i]);
                    }
                }
            }
            return strCollected;

        }

        private void BigBangDemo()
        {
            if (m_SimpleDictSeg == null)
            {
                m_SimpleDictSeg = new CSimpleDictSeg();
                m_SimpleDictSeg.LoadConfig("KTDictSeg.xml");
                m_SimpleDictSeg.MatchName = true;
                m_SimpleDictSeg.FreqFirst = true;
                m_SimpleDictSeg.AutoStudy = true;
                m_SimpleDictSeg.FilterStopWords = true;
                m_SimpleDictSeg.MultiSelect = false;
                m_SimpleDictSeg.Redundancy = 1;
                m_SimpleDictSeg.LoadDict();
            }
            List<T_WordInfo> words = m_SimpleDictSeg.SegmentToWordInfos(word);
            foreach (T_WordInfo x in words)
            {
                clbWords.Items.Add(x.ToString());
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (strSelected != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "保存为";
                
                sfd.AddExtension = true;
                sfd.RestoreDirectory = true;
                sfd.FileName = rtbAddKey.Text;
                sfd.Filter = "(*.txt)|*.txt|(*.*)|*.*|(*.doc)|*.doc";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = sfd.FileName.ToString();

                    FileStream fs = new FileStream(sfd.FileName,FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    try
                    {
                        sw.Write(rtbText.Text);
                        sw.Flush();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        sw.Close();
                        fs.Close();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("没有文字");
            }
        }

        private void rtbText_TextChanged(object sender, EventArgs e)
        {
            if (m_SimpleDictSeg != null)
            {
                List<T_WordInfo> words = m_SimpleDictSeg.SegmentToWordInfos(rtbText.Text);
                clbWords.Items.Clear();
                foreach (T_WordInfo x in words)
                {
                    clbWords.Items.Add(x.ToString());
                }
            }
        }

        private void rtbAddKey_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnWebSearch_Click(object sender, EventArgs e)
        {
            if(rtbAddKey.Text!=null)
                Process.Start("https://www.baidu.com/s?wd="+rtbSelected.Text+" "+rtbAddKey.Text);
            else
                Process.Start("https://www.baidu.com/s?wd=" + rtbSelected.Text);
        }
        private void search(string path)
        {
            string[] filepath;
            if (rtbAddKey.Text != null)
                filepath = Directory.GetFiles(path, "*"+rtbSelected.Text + "*" + rtbAddKey.Text + "*.*", SearchOption.AllDirectories);
            else                
                filepath = Directory.GetFiles(path, "*" + rtbSelected.Text + "*.*", SearchOption.AllDirectories);
            if (filepath.Length == 0)
            {
                MessageBox.Show("未搜索到文件");
            }
            else
            {
                listView1.BeginUpdate();
                foreach (string s in filepath)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = s;
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
            }
            //MessageBox.Show(path);
        }
        
        private void btnSQLSearch_Click(object sender, EventArgs e)
        {
            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                search(path);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start(listView1.SelectedItems[0].Text);
        }
    }
}
