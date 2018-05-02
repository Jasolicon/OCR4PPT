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
    public partial class FormBatchInsert : Form
    {
        T_DictStruct m_Word = new T_DictStruct();
        bool m_Ok;

        public T_DictStruct Word
        {
            get
            {
                return m_Word;
            }

            set
            {
                m_Word = value;
            }
        }

        public bool AllUse
        {
            get
            {
                return checkBoxAllUse.Checked;
            }
        }

        public FormBatchInsert()
        {
            InitializeComponent();
        }

        new public DialogResult ShowDialog()
        {
            m_Ok = false;
            textBoxWord.Text = m_Word.Word;
            numericUpDownFrequency.Value = (decimal)m_Word.Frequency;
            posCtrl.Pos = m_Word.Pos;

            base.ShowDialog();

            if (m_Ok)
            {
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.Cancel;
            }
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            m_Ok = true;
            m_Word.Frequency = (int)numericUpDownFrequency.Value;
            m_Word.Pos = posCtrl.Pos;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}