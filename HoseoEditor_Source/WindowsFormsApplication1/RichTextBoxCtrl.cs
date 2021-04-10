using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
//using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.ComponentModel;
using System.IO;
using RichTextBoxCtrl;
using richTextBoxTableClass;
using MainFormRichTextBox;

#region 添加引用 说明
//右键选中 引用 添加引用
//在“添加引用”对话框中，
//双击“System.Drawing.dll”和
//“System.Windows.Forms.dll”，然后单击“确定”。
#endregion


namespace System.Windows.Forms
{
    public class RichTextBoxCtrl : RichTextBox
    {

        private System.Windows.Forms.RichTextBox richTextBox1;

        RichTextBoxForm richTextBoxForm;

        public RichTextBoxCtrl()
        {
            richTextBox1 = this;
            AllowDrop = true;
            EnableAutoDragDrop = false;//DragDrop수정
            AcceptsTab = true;
            HideSelection = false;
            ScrollBars = RichTextBoxScrollBars.Vertical;
            InitialRichTextBoxCtrl();

        }
        public RichTextBoxCtrl(RichTextBoxForm rtbf)
        {
            richTextBoxForm = rtbf;
            richTextBox1 = this;
            AllowDrop = true;
            EnableAutoDragDrop = false;//DragDrop수정
            AcceptsTab = true;
            HideSelection = false;
            ScrollBars = RichTextBoxScrollBars.Vertical;
            InitialRichTextBoxCtrl();

        }

        private string fileName = "빈 문서 1.rtf";
        private string absFileName = "";

        //文件名 返回 如 abc.rtf  
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = FileName;
            }
        }

        public string AbsFileName
        {
            get
            {
                return absFileName;
            }
            set
            {
                absFileName = AbsFileName;
            }
        }

        public void NewDocument()
        {

            richTextBox1.Text = "";
            richTextBox1.Modified = false;

            absFileName = "";
            fileName = "";
        }

        public void OpenFilelist(string path)
        {
            //CheckFileSave();
            string fFormat = path.Substring(path.Length - 4);
            try
            {
                if (fFormat == ".rtf")
                {
                    LoadFile(path);
                }
                else
                {
                    LoadFile(path, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("파일을 여는데 오류가 발생했습니다.\n 오류내용" + E.Message);
            }


            Modified = false;
            absFileName = path;
            fileName = Path.GetFileName(absFileName);


        }

        public void SaveToTextFile(string TextFileName)
        {
            this.SaveFile(TextFileName, RichTextBoxStreamType.TextTextOleObjs);
        }


        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (ReadOnly)
                HideCaret(Handle);
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

        public void jumpLine(int Line)
        {
            richTextBox1.SelectionStart = SendMessage(richTextBox1.Handle, EM_LINEINDEX, Line - 1, 0);
            richTextBox1.SelectionLength = 0;
            richTextBox1.ScrollToCaret();
        }

        public void jumpColumn(int Column)
        {
            int Line = Column;

            int charIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEINDEX, Line - 1, 0);
            int lineIndex = charIndex + (int)SendMessage(richTextBox1.Handle, EM_LINEFROMCHAR, charIndex, 0);

            richTextBox1.SelectionStart = lineIndex;
        }

        public void ToggleBold()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Bold)

                style &= ~FontStyle.Bold;
            else
                style |= FontStyle.Bold;

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        public void ToggleItalic()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
                style &= ~FontStyle.Italic;
            else
                style |= FontStyle.Italic;

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        public void ToggleUnderLine()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Underline)
                style &= ~FontStyle.Underline;
            else
                style |= FontStyle.Underline;

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        public void ToggleStrikeout()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Strikeout)
                style &= ~FontStyle.Strikeout;
            else
                style |= FontStyle.Strikeout;
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }


        //제목1 ，제목2....
        public void SetFontFormat(int index)
        {
            richTextBoxFontFormatClass FontFormat1 = new richTextBoxFontFormatClass();
            FontFormat1.richTextBox = this;
            FontFormat1.SetFontFormat(index);
        }

        public string GetFontFormat()
        {
            richTextBoxFontFormatClass FontFormat1 = new richTextBoxFontFormatClass();
            FontFormat1.richTextBox = this;
            return FontFormat1.GetFontFormat();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionSupperScript
        {
            get
            {
                return (SelectionCharOffset == 4);
            }
            set
            {
                if (SelectionCharOffset == 0)
                {
                    SelectionCharOffset = 4;
                }
                else
                {
                    SelectionCharOffset = 0;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionSubScript
        {
            get
            {
                return (SelectionCharOffset == -4);
            }
            set
            {
                if (SelectionCharOffset == 0)
                {
                    SelectionCharOffset = -4;
                }
                else
                {
                    SelectionCharOffset = 0;
                }

            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionOrderList
        {
            get
            {
                richTextBoxBulletClass r = new richTextBoxBulletClass();
                r.richTextBox = this;
                return r.SelectionOrderList;
            }
            set
            {
                richTextBoxBulletClass r = new richTextBoxBulletClass();
                r.richTextBox = this;
                r.SelectionOrderList = value;
            }
        }

        ////Tab->
        public void Indent()
        {
            SelectionIndent += 8;
        }
        ////Tab <-
        public void OutIndent()
        {
            SelectionIndent -= 8;
        }

        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rect lParam);

        private const int EM_GETRECT = 0x00b2;
        private const int EM_SETRECT = 0x00b3;

        /// <summary>
        /// </summary>
        private Rect RichTextBoxMargin
        {
            get
            {
                Rect rect = new Rect();
                SendMessage(richTextBox1.Handle, EM_GETRECT, IntPtr.Zero, ref rect);
                rect.Left += 1;
                rect.Top += 1;
                rect.Right = 1 + richTextBox1.DisplayRectangle.Width - rect.Right;
                rect.Bottom = richTextBox1.DisplayRectangle.Height - rect.Bottom;
                return rect;
            }
            set
            {
                Rect rect;
                rect.Left = richTextBox1.ClientRectangle.Left + value.Left;
                rect.Top = richTextBox1.ClientRectangle.Top + value.Top;
                rect.Right = richTextBox1.ClientRectangle.Right - value.Right;
                rect.Bottom = richTextBox1.ClientRectangle.Bottom - value.Bottom;

                SendMessage(richTextBox1.Handle, EM_SETRECT, IntPtr.Zero, ref rect);
            }

        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LeftMargin
        {
            get
            {
                return RichTextBoxMargin.Left;
            }
            set
            {
                Rect rect1;
                rect1 = RichTextBoxMargin;

                Rect rect;
                rect.Left = value;
                rect.Top = 0;//rect1.Top;
                rect.Right = rect1.Right;
                rect.Bottom = rect1.Bottom;

                RichTextBoxMargin = rect;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RightMargin
        {
            get
            {
                return RichTextBoxMargin.Right;
            }
            set
            {
                Rect rect1;
                rect1 = RichTextBoxMargin;

                Rect rect;
                rect.Left = rect1.Left;
                rect.Top = rect1.Top;
                rect.Right = value;
                rect.Bottom = rect1.Bottom;

                RichTextBoxMargin = rect;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TopMargin
        {
            get
            {
                return RichTextBoxMargin.Top;
            }
            set
            {
                Rect rect1;
                rect1 = RichTextBoxMargin;

                Rect rect;
                rect.Left = rect1.Left;
                rect.Top = value;
                rect.Right = rect1.Right;
                rect.Bottom = rect1.Bottom;

                RichTextBoxMargin = rect;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BottomMargin
        {
            get
            {
                return RichTextBoxMargin.Bottom;
            }
            set
            {
                Rect rect1;
                rect1 = RichTextBoxMargin;

                Rect rect;
                rect.Left = rect1.Left;
                rect.Top = rect1.Top;
                rect.Right = rect1.Right;
                rect.Bottom = value;
                RichTextBoxMargin = rect;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int sStart, sEnd;
            int CrlfCount;
            if (!this.ReadOnly)
            {
                switch (keyData)
                {
                    //CTRL+B
                    case Keys.Control | Keys.B:
                        ToggleBold();
                        return true;

                    //CTRL+I
                    case Keys.Control | Keys.I:
                        ToggleItalic();
                        return true;

                    //CTRL+U
                    case Keys.Control | Keys.U:
                        ToggleUnderLine();
                        return true;

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

                    
                    case Keys.Control | Keys.R:
                        ShowReplaceDlg();
                        return true;

                    
                    case Keys.F5:
                        SelectedText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        return true;

                    
                    case Keys.Control | Keys.Shift | Keys.V:
                        PasteAsText();
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

            }
            return false;
        }

        public void PasteAsText()
        {
            richTextBox1.SelectedText = Clipboard.GetText(); //粘贴纯文本
        }

        public void PasteAsBmp()
        {
            if (CanPasteAsBmp())
            {
                richTextBox1.Paste();
            }
        }

        public void PasteAsHtml()
        {

        }

        public void PasteAsUnicode()
        {

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool CanPaste()
        {
            return (Clipboard.GetDataObject() != null);
        }

        public bool CanPasteAsText()
        {
            return Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
        }

        public bool CanPasteAsBmp()
        {
            return Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap);
        }

        public bool CanPasteAsHtml()
        {
            return Clipboard.GetDataObject().GetDataPresent(DataFormats.Html);
        }

        public bool CanSelectAll()
        {
            return (richTextBox1.SelectedText.Length != richTextBox1.Text.Length);
        }

        private void InitialRichTextBoxCtrl()
        {
            //ContextMenuStrip = contextMenuStrip1;
            LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(richTextBox1_LinkClicked);
        }


        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            DialogResult b = MessageBox.Show("이동하시겠습니까?\n" + e.LinkText, "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (b == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("iexplore.exe", e.LinkText);
            }
        }

        public void ShowFindDlg()
        {
            FindDialog FindDlg = new FindDialog(this);
            FindDlg.richTextBox1 = this;
            FindDlg.textBox1.Text = this.SelectedText;
            FindDlg.StartPosition = FormStartPosition.CenterParent;
            FindDlg.ShowDialog();
        }

        /// <summary>
        /// </summary>
        public void ShowReplaceDlg()
        {
            ReplaceDialog ReplaceDlg = new ReplaceDialog();
            ReplaceDlg.StartPosition = FormStartPosition.CenterParent;
            ReplaceDlg.richTextBox1 = this;
            ReplaceDlg.textBox1.Text = this.SelectedText;
            ReplaceDlg.ShowDialog();
        }

        /// <summary>
        /// </summary>
        public void ShowFontDlg()
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.Font = richTextBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;

            }
        }
        /// <summary>
        /// </summary>
        public void ShowGoToDlg()
        {
            Point pt = this.GetCaretPosition();

            frm_GOTO frm = new frm_GOTO();
            frm.label1.Text = "행 번호(1 - " + this.Lines.Length.ToString() + ")(&L)";
            frm.textBox1.Text = pt.X.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int Line = Convert.ToInt32(frm.textBox1.Text);
                if (Line >= 1)
                {
                    if (Line > this.Lines.Length + 1)
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

        //RichTextBox
        public void ShowInsertImageDlg()
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = "Select Image";
            OpenFileDialog1.Filter = "BMP File|*.BMP|JPEG File|*.JPG|GIF File|*.GIF|PNG File|*.PNG|ICO File|*.ICO|Image File|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.EMF;*.WMF;*.TIF;*.PNG;*.ICO|All File|*.*";
            OpenFileDialog1.FilterIndex = 6;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strImagePath = OpenFileDialog1.FileName;
                Image img;
                img = Image.FromFile(strImagePath);
                Clipboard.SetDataObject(img);
                DataFormats.Format df;
                df = DataFormats.GetFormat(DataFormats.Bitmap);
                if (this.CanPaste(df))
                {
                    this.Paste(df);
                }
            }
        }

        public void ShowInsertTableDlg()
        {
            richTextBoxTableDlg dlg = new richTextBoxTableDlg();
            dlg.richTextBox = this;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBoxTable r1 = new richTextBoxTable();
                r1.richTextBox = this;
                r1.cellWidth = (int)dlg.numericUpDownCellWidth.Value;
                r1.InsertTable((int)dlg.numericUpDownColumn.Value, (int)dlg.numericUpDownRow.Value, dlg.radioButtonAutoSzie.Checked);
            }
        }

        public void ShowPageSetupDlg()
        {
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = this;
            r.ShowPageSetupDlg();
        }
        
        public void ShowShowPagePriviewDlg()
        {
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = this;
            r.ShowShowPagePriviewDlg();
        }

        
        public void ShowPrintDlg()
        {
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = this;
            r.ShowPrintDlg();
        }

        // P/Invoke declarations
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibrary(string path);

        private static IntPtr moduleHandle;

        protected override CreateParams CreateParams
        {
            get
            {
                if (moduleHandle == IntPtr.Zero)
                {
                    moduleHandle = LoadLibrary("msftedit.dll");
                    if ((long)moduleHandle < 0x20)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not load Msftedit.dll");
                    }
                }

                CreateParams createParams = base.CreateParams;
                createParams.ClassName = "RichEdit50W";
                if (this.Multiline)
                {
                    if (((this.ScrollBars & RichTextBoxScrollBars.Horizontal) != RichTextBoxScrollBars.None) && !base.WordWrap)
                    {
                        createParams.Style |= 0x100000;
                        if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None)
                        {
                            createParams.Style |= 0x2000;
                        }
                    }
                    if ((this.ScrollBars & RichTextBoxScrollBars.Vertical) != RichTextBoxScrollBars.None)
                    {
                        createParams.Style |= 0x200000;
                        if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None)
                        {
                            createParams.Style |= 0x2000;
                        }
                    }
                }
                if ((BorderStyle.FixedSingle == base.BorderStyle) && ((createParams.Style & 0x800000) != 0))
                {
                    createParams.Style &= -8388609;
                    createParams.ExStyle |= 0x200;
                }
                return createParams;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RichTextBoxCtrl
            // 
            this.ResumeLayout(false);

        }


    }

}
