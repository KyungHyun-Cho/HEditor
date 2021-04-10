using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;

//private void button2_Click(object sender, EventArgs e)
//{
//    richTextBoxTableDlg dlg = new richTextBoxTableDlg();
//    dlg.richTextBox = richTextBox51;

//    if (dlg.ShowDialog() ==DialogResult.OK)
//    {
//        richTextBoxTable r1 = new richTextBoxTable();
//        r1.richTextBox = richTextBox51;
//        r1.cellWidth = (int)dlg.numericUpDownCellWidth.Value  ;
//        r1.InsertTable((int)dlg.numericUpDownColumn.Value, (int)dlg.numericUpDownRow.Value, dlg.radioButtonAutoSzie.Checked);  
//    }
//}
/*
 * 光标在表格上可以改变光标
 */

namespace richTextBoxTableClass
{
    public class richTextBoxTable 
    {
      
        public richTextBoxTable()
        {

        }

       public RichTextBox richTextBox;
       public int cellWidth;// = 1000;//default =1000

        /// <summary>
        /// 插入表格
        /// </summary>
        /// <param name="col">行</param>
        /// <param name="row">列</param>
        /// <param name="AutoSize">=TRUE:自动设置每个单元格的大小</param>
        public void InsertTable(int col, int row,bool AutoSize)
        {
            StringBuilder rtf = new StringBuilder();
            rtf.Append(@"{\rtf1 ");

            //int cellWidth = 1000;//col.1 width =1000
            if (AutoSize)
                //滚动条出现时 (richTextBox.ClientSize.Width - 滚动条的宽 /列的个数)*15
                cellWidth = ((richTextBox.ClientSize.Width-3) / row) * 15; 
            for (int i = 0; i < col; i++)
            {
                rtf.Append(@"\trowd");
                for (int j = 1; j <= row; j++)
                    rtf.Append(@"\cellx" + (j * cellWidth).ToString());
                rtf.Append(@"\intbl \cell \row"); //create row
            }
            rtf.Append(@"\pard");
            rtf.Append(@"}");
            richTextBox.SelectedRtf = rtf.ToString();
            //return rtf.ToString();
        }
    }
}