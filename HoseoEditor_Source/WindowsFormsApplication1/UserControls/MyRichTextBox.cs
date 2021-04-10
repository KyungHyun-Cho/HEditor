using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using MainFormRichTextBox;
using RichTextBoxCtrl;

namespace AdvancedNotepad_CSharp
{
    public partial class MyRichTextBox : UserControl
    {
        RichTextBoxForm richTextBoxForm;
        public MyRichTextBox(RichTextBoxForm rtbf)
        {
            richTextBoxForm = rtbf;
            InitializeComponent();
        }
        private int EM_LINEINDEX = 0x00BB;
        private int EM_LINEFROMCHAR = 0x00C9;

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        
        public Point GetCaretPosition()
        {
            int charIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEINDEX, -1, 0);
            int lineIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEFROMCHAR, charIndex, 0);
            Point pt = new Point();
            pt.X = richTextBox1.SelectionStart - charIndex + 1;//Line
            pt.Y = lineIndex + 1;//Column
            return pt;
        }


        /// <summary>
        /// 转到行
        /// </summary>
        /// <param name="Line">行号</param>
        public void jumpLine(int Line)
        {
            richTextBox1.SelectionStart = SendMessage(richTextBox1.Handle, EM_LINEINDEX, Line - 1, 0);
            richTextBox1.SelectionLength = 0;
            richTextBox1.ScrollToCaret();
        }
        public void ShowFindDlg()
        {
            FindDialog FindDlg = new FindDialog(this);
            FindDlg.richTextBox1 = this.richTextBox1;
            FindDlg.textBox1.Text = this.richTextBox1.SelectedText;
            FindDlg.StartPosition = FormStartPosition.CenterParent;
            //FindDlg.ShowDialog();
            FindDlg.ShowDialog();
        }

        /// <summary>
        /// 替换 对话框
        /// </summary>
        /// 
        public void ShowReplaceDlg()
        {
            ReplaceDialog ReplaceDlg = new ReplaceDialog();
            ReplaceDlg.StartPosition = FormStartPosition.CenterParent;
            ReplaceDlg.richTextBox1 = this.richTextBox1;
            ReplaceDlg.textBox1.Text = this.richTextBox1.SelectedText;
            ReplaceDlg.ShowDialog();
        }

        public void ShowPageSetupDlg()
        {
            RichTextBox tempBox = new RichTextBox();
            tempBox.Multiline = true;
            tempBox.Text = this.richTextBox1.Text;
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = tempBox;
            r.ShowPageSetupDlg();
        }
        //打印预览功能
        public void ShowShowPagePriviewDlg()
        {
            RichTextBox tempBox = new RichTextBox();
            tempBox.Multiline = true;
            tempBox.Text = this.richTextBox1.Text;
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = tempBox;
            r.ShowShowPagePriviewDlg();
        }

        //打印
        public void ShowPrintDlg()
        {
            RichTextBox tempBox = new RichTextBox();
            tempBox.Multiline = true;
            tempBox.Text = this.richTextBox1.Text;
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = tempBox;
            r.ShowPrintDlg();
        }

        public void ShowGoToDlg()
        {
            Point pt = this.GetCaretPosition();

            frm_GOTO frm = new frm_GOTO();
            frm.label1.Text = "행 번호(1 - " + this.richTextBox1.Lines.Length.ToString() + ")(&L)";
            frm.textBox1.Text = pt.X.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int Line = Convert.ToInt32(frm.textBox1.Text);
                if (Line >= 1)
                {
                    if (Line > this.richTextBox1.Lines.Length + 1)
                    {
                        MessageBox.Show("이동하려는 행이 존재하는 행보다 큽니다.");
                    }
                    else
                    {
                        this.jumpLine(Line);
                    }
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int sStart, sEnd;
            int CrlfCount;
            switch (keyData)
            {
                case Keys.Shift | Keys.Tab:

                    CrlfCount = richTextBox1.SelectedText.Split("\n\t").Length;
                    sStart = richTextBox1.SelectionStart;
                    sEnd = richTextBox1.SelectedText.Length - CrlfCount + 1;
                    richTextBox1.SelectedText = richTextBox1.SelectedText.Replace("\n\t", "\n");
                    richTextBox1.Select(sStart, sEnd);
                    return true;

                case Keys.Tab:
                    CrlfCount = richTextBox1.SelectedText.Split('\n').Length;
                    sStart = richTextBox1.SelectionStart + 1;
                    sEnd = richTextBox1.SelectedText.Length + CrlfCount - 1;
                    richTextBox1.SelectedText = ('\t' + richTextBox1.SelectedText).Replace("\n", "\n\t");
                    richTextBox1.Select(sStart, sEnd);
                    return true;

                //替换对话框
                case Keys.Control | Keys.R:
                    ShowReplaceDlg();
                    return true;

                //插入时间日期
                case Keys.F5:
                    //2013-11-25 13:57:09
                    richTextBox1.SelectedText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    return true;

                case Keys.Control | Keys.G:
                    ShowGoToDlg();
                    return true;
                case Keys.Control | Keys.F:
                    ShowFindDlg();
                    return true;
                case Keys.Control | Keys.S:
                        richTextBoxForm.BtnSave_Click(null, null);
                    return true;

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1
            int line = richTextBox1.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTextBox1.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTextBox1.Font.Size;
            }
            else
            {
                w = 50 + (int)richTextBox1.Font.Size;
            }

            return w;
        }
        

        public void AddLineNumbers()
        {
            richTextBox1.Select();
            Point pt = new Point(0, 0);
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            int Last_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox1.GetLineFromCharIndex(Last_Index);
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            LineNumberTextBox.Text = "";
            /*int First_Line = 0;
            int Last_Line = WindowsFormsApplication1.global.Split(richTextBox1.Text, "\n").Length-2;*/
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        

        private void MyRichTextBox_Load(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            AddLineNumbers();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            Point pt = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }
        

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox1.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void MyRichTextBox_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter || e.KeyData == Keys.Clear || e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
            {
                AddLineNumbers();
            }*/
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
