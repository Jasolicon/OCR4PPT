using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KTDictSeg;

namespace DictManage
{
    public partial class FormUnknownWords : Form
    {
        private String m_NameTableName;
        private DictManage.DictMgr m_DictManage = new DictMgr();
        private DictManage.DictMgr m_DictMgr = new DictMgr();
        private T_DictFile m_DictFile;

        public String NameTableName
        {
            get
            {
                return m_NameTableName;
            }
        }

        public void ShowDialog(String fileName, DictManage.DictMgr dictMgr)
        {
            m_NameTableName = fileName;

            m_DictMgr = dictMgr;

            try
            {
                m_DictFile = Dict.LoadFromBinFileEx(fileName);
            }
            catch (Exception e1)
            {
                MessageBox.Show(String.Format("Can not open dictionary, errmsg:{0}", e1.Message));
                return;
            }

            m_DictManage.Dict = m_DictFile;
            this.ShowDialog();

        }

        public FormUnknownWords()
        {
            InitializeComponent();
        }

        private void DisplayThreshold()
        {
            listBoxWords.Items.Clear();

            foreach (T_DictStruct word in m_DictManage.Dict.Dicts)
            {
                if (word.Frequency >= (double)numericUpDown.Value)
                {
                    bool display = false;

                    if (checkBoxDisable.Checked)
                    {
                        if (word.Pos == 0)
                        {
                            display = true;
                        }
                    }

                    if (checkBoxName.Checked)
                    {
                        if ((word.Pos & (int)T_POS.POS_A_NR) != 0)
                        {
                            display = true;
                        }
                    }

                    if (checkBoxOther.Checked)
                    {
                        if ((word.Pos & (int)T_POS.POS_A_NZ) != 0)
                        {
                            display = true;
                        }
                    }


                    if (display)
                    {
                        listBoxWords.Items.Add(word);
                    }
                }
            }
        }

        private void FormUnknownWords_Load(object sender, EventArgs e)
        {
            DisplayThreshold();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            DisplayThreshold();
        }

        private void checkBoxDisable_CheckedChanged(object sender, EventArgs e)
        {
            DisplayThreshold();
        }

        private void checkBoxOther_CheckedChanged(object sender, EventArgs e)
        {
            DisplayThreshold();
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            DisplayThreshold();
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            foreach (T_DictStruct word in listBoxWords.SelectedItems)
            {
                word.Pos = 0;
            }

            Dict.SaveToBinFileEx(NameTableName, m_DictManage.Dict);
            DisplayThreshold();
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            foreach (T_DictStruct word in listBoxWords.SelectedItems)
            {
                word.Pos = (int)T_POS.POS_A_NZ;
            }

            Dict.SaveToBinFileEx(NameTableName, m_DictManage.Dict);
            DisplayThreshold();
        }

        private void buttonBatchInsert_Click(object sender, EventArgs e)
        {
            foreach (T_DictStruct word in listBoxWords.SelectedItems)
            {
                m_DictMgr.InsertWord(word.Word, word.Frequency, word.Pos);
                word.Frequency = 0;
                word.Pos = 0;
            }

            Dict.SaveToBinFileEx(NameTableName, m_DictManage.Dict);
            MessageBox.Show("加入成功!", "信息", MessageBoxButtons.OK);
            DisplayThreshold();
        }
    }
}