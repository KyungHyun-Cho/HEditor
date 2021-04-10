using System;
using System.Collections.Generic;
using System.Text;
 
using System.IniFiles;

namespace System.Windows.Forms
{
    public partial class richTextBoxTableDlg : Form
    {
        public richTextBoxTableDlg()
        {
            InitializeComponent();
        }
        public RichTextBox richTextBox;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownCellWidth.Enabled = radioButtonCustomSize.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownCellWidth.Enabled = radioButtonCustomSize.Checked;
            numericUpDownCellWidth.Focus();
        }

        private void UpdateData()
        {
            numericUpDownCellWidth.Value = (decimal)((richTextBox.ClientSize.Width-3 / numericUpDownRow.Value) * 15);
        }


        //按TAB 时自动全选
        private void SelectAll(NumericUpDown numericUpDown)
        {
            numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
        }

        private void numericUpDownRow_Enter(object sender, EventArgs e)
        {
            SelectAll(numericUpDownRow);
        }

        private void numericUpDownColumn_Enter(object sender, EventArgs e)
        {
            SelectAll(numericUpDownColumn);
        }

        private void numericUpDownCellWidth_Enter(object sender, EventArgs e)
        {
            SelectAll(numericUpDownCellWidth);
        }


        private IniFileClass ini = new IniFileClass(@".\CommonDialogSetting.ini");//当前EXE的目录处

        private void richTextBoxTableDlg_Load(object sender, EventArgs e)
        {
            UpdateData();
            numericUpDownRow.Value = (decimal)ini.ReadInteger("TableDialog", "numericUpDownRow", 3);
            numericUpDownColumn.Value = (decimal)ini.ReadInteger("TableDialog", "numericUpDownColumn", 4);
        }

        private void richTextBoxTableDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            ini.WriteInteger("TableDialog", "numericUpDownRow", (int)numericUpDownRow.Value);
            ini.WriteInteger("TableDialog", "numericUpDownColumn", (int)numericUpDownColumn.Value);
        }
    }
}
