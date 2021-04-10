using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FindReplaceDialog : Form
    {
       public RichTextBox richTextBox1;
        public FindReplaceDialog()
        {
            InitializeComponent();
            richTextBox1 = new RichTextBox();
            richTextBox1.SelectionChanged += new System.EventHandler(richTextBox1_SelectionChanged);
        }
        private int pos = 0;
        private string FindStr;

        private bool FindNext(bool bDown)
        {
            FindStr = textBox1.Text;



            //查找↓↓↓↓↓↓↓
            if (bDown){
                pos = pos + FindStr.Length;
                if (pos > richTextBox1.TextLength)
                    pos = richTextBox1.TextLength;
                pos = richTextBox1.Find(FindStr, pos, RichTextBoxFinds.None);
            }

            //查找↑↑↑↑↑↑↑
            if (!bDown){
                pos = richTextBox1.Find(FindStr, 0, pos, RichTextBoxFinds.Reverse);
            }
            return (pos != -1); //pos == -1找不到结果
        }

        //no used
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            pos = richTextBox1.SelectionStart;
           // Text = pos.ToString();
        }


        //查找下一个
        private bool bFound;
        private void FindNextPro()
        {
            if (richTextBox1.SelectionStart > 0)
            {
                pos = richTextBox1.SelectionStart;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0://↓↓↓↓↓↓↓
                    bFound = FindNext(true);
                    break;


                case 1: //↑↑↑↑↑↑↑
                    bFound = FindNext(false);
                    break;
            }

            if (!bFound)
            {
                MessageBox.Show("无结果");
                pos = 0;
            }
        }
        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNextPro();
        }

        //替换
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (pos > 0 ) 
            {
                richTextBox1.SelectionStart = pos;
                richTextBox1.SelectionLength = textBox1.TextLength;
                richTextBox1.SelectedText = textBox2.Text;   
            }

            FindNextPro();
        }

        
        //全部替换
        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            richTextBox1.Rtf = richTextBox1.Rtf.Replace(textBox1.Text, textBox2.Text);
        }


        #region 其他... ...
        private void Close1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FindReplaceDialog_Shown(object sender, EventArgs e)
        {
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnReplace.Enabled = (textBox1.Text != "");
            btnReplaceAll.Enabled = (textBox1.Text != "");
            btnFindNext.Enabled = (textBox1.Text != "");
        }

        private void FindReplaceDialog_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            btnReplace.Enabled = (textBox1.Text != "");
            btnReplaceAll.Enabled = (textBox1.Text != "");
            btnFindNext.Enabled = (textBox1.Text != "");

            Label2.Parent = tabPage2;
            textBox2.Parent = tabPage2;
            btnReplace.Parent = tabPage2;
            btnReplaceAll.Parent = tabPage2;

         //   this.label4.Location = new System.Drawing.Point(141, 85);
         //   this.comboBox1.Location = new System.Drawing.Point(200, 81);
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                Label1.Parent = tabPage1;
                textBox1.Parent = tabPage1;

                btnFindNext.Parent = tabPage1;
                btnClose.Parent = tabPage1;
                comboBox1.Parent = tabPage1;
                // tabControl1.Size = new System.Drawing.Size(508, 236);
                //  tabControl1.Height = 236;
             
                textBox1.SelectAll();
                textBox1.Focus();
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                Label1.Parent = tabPage2;
                textBox1.Parent = tabPage2;
                btnFindNext.Parent = tabPage2;
                btnClose.Parent = tabPage2;
                comboBox1.Parent = tabPage2;
                // tabControl1.Size = new System.Drawing.Size(508, 159);
                // tabControl1.Height = 159;
                
                textBox1.SelectAll();
                textBox1.Focus();
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
               // textBox1.Parent = tabPage3;
                btnClose.Parent = tabPage3;
                textBox3.SelectAll();
                textBox3.Focus();
            }
        }

        #endregion

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
