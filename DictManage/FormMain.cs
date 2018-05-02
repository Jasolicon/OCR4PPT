using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KTDictSeg;
using FTAlgorithm.General;

namespace DictManage
{
    public partial class FormMain : Form
    {
        T_DictFile m_DictFile = null;
        DictMgr m_DictManage = new DictMgr();
        String m_DictFileName;

        private int Count
        {
            get
            {
                if (m_DictManage.Dict != null)
                {
                    return m_DictManage.Dict.Dicts.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void ShowCount()
        {
            labelCount.Text = Count.ToString();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    m_DictFile = Dict.LoadFromTextDict(openFileDialogDict.FileName);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(String.Format("Can not open dictionary, errmsg:{0}", e1.Message));
                    return;
                }

                panelMain.Enabled = true;
                m_DictManage.Dict = m_DictFile;
                m_DictFileName = openFileDialogDict.FileName;
                this.Text = openFileDialogDict.FileName;
                ShowCount();
            }
        }

        private void saveToTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_DictFile == null)
            {
                return;
            }

            if (saveFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                Dict.SaveToTextFile(saveFileDialogDict.FileName, m_DictFile);
            }
        }

        private void loadFromBinFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DateTime old = DateTime.Now;

                    m_DictFile = Dict.LoadFromBinFile(openFileDialogDict.FileName);

                    TimeSpan s = DateTime.Now - old;
                    statusStrip.Items[0].Text = s.TotalMilliseconds.ToString() + "ms";
                }
                catch (Exception e1)
                {
                    MessageBox.Show(String.Format("Can not open dictionary, errmsg:{0}", e1.Message));
                    return;
                }

                panelMain.Enabled = true;
                m_DictManage.Dict = m_DictFile;
                m_DictFileName = openFileDialogDict.FileName;
                this.Text = openFileDialogDict.FileName;
                ShowCount();
            }
        }

        private void saveToBinFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_DictFile == null)
            {
                return;
            }

            if (saveFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                Dict.SaveToBinFile(saveFileDialogDict.FileName, m_DictFile);
            }
        }

        private void openBinDictFile13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DateTime old = DateTime.Now;
                    m_DictFile = Dict.LoadFromBinFileEx(openFileDialogDict.FileName);

                    TimeSpan s = DateTime.Now - old;
                    statusStrip.Items[0].Text = s.TotalMilliseconds.ToString() + "ms";
                }
                catch (Exception e1)
                {
                    MessageBox.Show(String.Format("Can not open dictionary, errmsg:{0}", e1.Message));
                    return;
                }

                panelMain.Enabled = true;
                m_DictManage.Dict = m_DictFile;
                m_DictFileName = openFileDialogDict.FileName;
                this.Text = openFileDialogDict.FileName;
                ShowCount();
            }

        }

        private void saveBinDictFile13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_DictFile == null)
            {
                return;
            }

            if (saveFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                Dict.SaveToBinFileEx(saveFileDialogDict.FileName, m_DictFile);
            }

        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Trim() == "")
            {
                return;
            }

            List<SearchWordResult> result = m_DictManage.Search(textBoxSearch.Text.Trim());

            result.Sort();

            listBoxList.Items.Clear();

            foreach (SearchWordResult word in result)
            {
                listBoxList.Items.Add(word);
            }

            label.Text = "符合条件的记录数:" + result.Count.ToString();
        }

        private void listBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxList.SelectedIndex;

            if (index < 0)
            {
                return;
            }

            object obj = listBoxList.Items[index];
            SearchWordResult word = (SearchWordResult)obj;

            textBoxWord.Text = word.Word.Word;
            numericUpDownFrequency.Value = (decimal)word.Word.Frequency;
            posCtrl.Pos = (int)word.Word.Pos;
        }

        private void textBoxWord_TextChanged(object sender, EventArgs e)
        {
            String word = textBoxWord.Text.Trim();
            if (word == "")
            {
                buttonUpdate.Enabled = false;
                buttonInsert.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            T_DictStruct selWord = m_DictManage.GetWord(word);
            if (selWord != null)
            {
                buttonUpdate.Enabled = true;
                buttonInsert.Enabled = false;
                buttonDelete.Enabled = true;
                numericUpDownFrequency.Value = (decimal)selWord.Frequency;
                posCtrl.Pos = selWord.Pos;
            }
            else
            {
                buttonUpdate.Enabled = false;
                buttonInsert.Enabled = true;
                buttonDelete.Enabled = false;
                numericUpDownFrequency.Value = 0;
                posCtrl.Pos = 0;

            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            m_DictManage.InsertWord(textBoxWord.Text.Trim(), (double)numericUpDownFrequency.Value, posCtrl.Pos);
            MessageBox.Show("增加成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowCount();
            textBoxWord_TextChanged(sender, e);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            m_DictManage.UpdateWord(textBoxWord.Text.Trim(), (double)numericUpDownFrequency.Value, posCtrl.Pos);
            MessageBox.Show("修改成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowCount();
            textBoxWord_TextChanged(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除改单词?", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                m_DictManage.DeleteWord(textBoxWord.Text.Trim());
                MessageBox.Show("删除成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ShowCount();
            textBoxWord_TextChanged(sender, e);
        }

        private void BatchInsert(String fileName, String encoder)
        {
            String content = CFile.ReadFileToString(fileName, encoder);

            String[] words = CRegex.Split(content, @"\r\n");

            bool allUse = false;
            T_DictStruct lstWord = null;

            foreach (String word in words)
            {
                if (word == null)
                {
                    continue;
                }

                if (word.Trim() == "")
                {
                    continue;
                }

                FormBatchInsert frmBatchInsert = new FormBatchInsert();

                if (!allUse || lstWord == null)
                {
                    frmBatchInsert.Word.Word = word.Trim();

                    if (frmBatchInsert.ShowDialog() == DialogResult.OK)
                    {
                        lstWord = frmBatchInsert.Word;
                        allUse = frmBatchInsert.AllUse;
                        m_DictManage.InsertWord(lstWord.Word, lstWord.Frequency, lstWord.Pos);
                    }
                }
                else
                {
                    lstWord.Word = word.Trim();
                    m_DictManage.InsertWord(lstWord.Word, lstWord.Frequency, lstWord.Pos);
                }
            }
        }


        private void buttonBatchInsert_Click(object sender, EventArgs e)
        {
            if (openFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FormEncoder frmEncoder = new FormEncoder();
                    if (frmEncoder.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    BatchInsert(openFileDialogDict.FileName, frmEncoder.Encoding);
                    MessageBox.Show("批量增加成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowCount();
                }
                catch(Exception e1)
                {
                    MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonInsertFromUnknownWords_Click(object sender, EventArgs e)
        {
            if (openFileDialogName.ShowDialog() == DialogResult.OK)
            {
                FormUnknownWords frmUnknownWords = new FormUnknownWords();
                frmUnknownWords.ShowDialog(openFileDialogName.FileName, m_DictManage);
            }
        }

        private void ListWordsByPos(int pos)
        {
            List<SearchWordResult> result = m_DictManage.SearchByPos(pos);

            result.Sort();

            listBoxList.Items.Clear();

            foreach (SearchWordResult word in result)
            {
                listBoxList.Items.Add(word);
            }

            label.Text = "符合条件的记录数:" + result.Count.ToString();

        }

        private void ListWordsByLength(int length)
        {
            List<SearchWordResult> result = m_DictManage.SearchByLength(length);

            result.Sort();

            listBoxList.Items.Clear();

            foreach (SearchWordResult word in result)
            {
                listBoxList.Items.Add(word);
            }

            label.Text = "符合条件的记录数:" + result.Count.ToString();

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFind frmFind = new FormFind();

            frmFind.ShowDialog();

            switch (frmFind.Mode)
            {
                case FormFind.SearchMode.None:
                    listBoxList.Items.Clear();
                    break;

                case FormFind.SearchMode.ByPos:
                    ListWordsByPos(frmFind.POS);
                    break;

                case FormFind.SearchMode.ByLength:
                    ListWordsByLength(frmFind.Length);
                    break;
            }

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogText.ShowDialog() == DialogResult.OK)
            {
                StringBuilder str = new StringBuilder();

                foreach (object text in listBoxList.Items)
                {
                    str.AppendLine(text.ToString());
                }

                FTAlgorithm.General.CFile.WriteString(saveFileDialogText.FileName, str.ToString(), "UTF-8");
                MessageBox.Show("Save OK!");
            }
        }
    }
}