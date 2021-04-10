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

        #region RichTextBox初始化属性
        /// <summary>
        /// richTextBox1 = this;
        /// </summary>
        private System.Windows.Forms.RichTextBox richTextBox1;

        public RichTextBoxCtrl()
        {
            richTextBox1 = this;
            AllowDrop = true;
            EnableAutoDragDrop = true;
            AcceptsTab = true;
            HideSelection = false;
            ScrollBars = RichTextBoxScrollBars.Vertical;
            InitialRichTextBoxCtrl();
            
        }
        #endregion

        #region RichTextBox 新建 打开 和 保存 文件对话框

        private string fileName = "빈 문서1.rtf";
        private string absFileName = "";

        //文件名 返回 如 abc.rtf  
        public string FileName
        {
            get{
                return fileName;
            }
            set
            {
                fileName = FileName;
            }
        }

        //格式 C:\windows\abc.rtf
        public string AbsFileName
        {
            get {
                return absFileName;
            }
            set
            {
                absFileName = AbsFileName;
            }
        }
        

        /// <summary>
        /// 判断文件是否保存了
        /// </summary>
        private void CheckFileSave()
        {
            if (this.Modified)
            {
                string msg = "";
                if (File.Exists(absFileName))
                    msg = "작성중인 파일을 저장하시겠습니까? :" + fileName;
                else
                    msg = "작성중인 파일을 저장하시겠습니까?";

                DialogResult Result = MessageBox.Show(msg, "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    if (File.Exists(absFileName))
                        richTextBox1.SaveFile(absFileName);
                    else
                        this.ShowSaveFileDlg();
                }
            }
        }

        /// <summary>
        /// 新空的文档
        /// </summary>
        public void NewDocument()
        {
            CheckFileSave();

            richTextBox1.Text = "";
            richTextBox1.Modified = false;

            absFileName = "";
            fileName = "";
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        public void ShowOpenFileDlg()
        {
            CheckFileSave();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = ".rtf";
            openFileDialog1.Filter = "RTF 파일(*.rtf)|*.rtf|모든 파일(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadFile(openFileDialog1.FileName);
                Modified = false;

                absFileName = openFileDialog1.FileName;
                fileName = Path.GetFileName(absFileName);
            }
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
                MessageBox.Show("오류 : \n" + E.Message);
            }


            Modified = false;
            absFileName = path;
            fileName = Path.GetFileName(absFileName);
            

        }

        //另存文件
        public void ShowSaveFileDlg()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = ".rtf";
            saveFileDialog1.Filter = "RTF 파일(*.rtf)|*.rtf|모든 파일(*.*)|*.*";
            saveFileDialog1.FileName = FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName);
                Modified = false;
             
                absFileName = saveFileDialog1.FileName;
                fileName = Path.GetFileName(absFileName);
            }
        }
     
        #endregion

        #region 把RTF文件保存为纯文本
       
        /// <summary>
        /// 把RTF文件保存为纯文本
        /// 只保存字符 转换后文本不包括RTF中的图片信息
        /// </summary>
        /// <param name="TextFileName">"C:\Users\Admin\Desktop\CurRoleBase.txt"</param>
        public void SaveToTextFile(string TextFileName)
        {
            this.SaveFile(TextFileName, RichTextBoxStreamType.TextTextOleObjs);
        }
        #endregion

        #region 设置为只读模式

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
       
       
        /// <summary>
        /// HideCaret 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (ReadOnly)
                HideCaret(Handle);
        }
        #endregion

        #region 设置 和 获得光标所在的行号和列号
        ///要在本类中初始化 richTextBox1 = this;
        private int EM_LINEINDEX = 0x00BB;
        private int EM_LINEFROMCHAR = 0x00C9;

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        
        /// <summary>
        /// 获得光标所在的行号和列号
        /// </summary>
        /// <param name="editControl"></param>
        /// <returns>p.X = 行号 p.Y =列号</returns>
        public Point GetCaretPosition()
        {
            int charIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEINDEX, -1, 0);
            int lineIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEFROMCHAR, charIndex, 0);
            Point pt=new Point();
            pt.X = richTextBox1.SelectionStart - charIndex +1;//Line
            pt.Y = lineIndex +1;//Column
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


        /// <summary>
        /// 有问题 同时设置行号和列号就出现问题了
        /// </summary>
        /// <param name="Column"></param>
        public void jumpColumn(int Column)
        {
            int Line = Column;

            int charIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEINDEX, Line - 1, 0);
            int lineIndex = charIndex + (int)SendMessage(richTextBox1.Handle, EM_LINEFROMCHAR, charIndex, 0);

            richTextBox1.SelectionStart = lineIndex;
        }
        #endregion

        #region RichTextBox 字体样式
        //格式刷


        /// richTextBox1 = this;
        
        /// <summary>
        /// 粗体
        /// </summary>
        public void ToggleBold()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Bold)

                style &= ~FontStyle.Bold;//恢复正常
            else
                style |= FontStyle.Bold;

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        /// <summary>
        /// 斜体
        /// </summary>
        public void ToggleItalic()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
                style &= ~FontStyle.Italic;//恢复正常
            else
                style |= FontStyle.Italic;

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        /// <summary>
        /// 下划线
        /// </summary>
        public void ToggleUnderLine()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Underline)
                style &= ~FontStyle.Underline;//恢复正常
            else
                style |= FontStyle.Underline;

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        /// <summary>
        /// 删除线
        /// </summary>
        public void ToggleStrikeout()
        {
            if (richTextBox1.SelectionFont == null)
                richTextBox1.SelectionFont = richTextBox1.Font;

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Strikeout)
                style &= ~FontStyle.Strikeout;//恢复正常
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

        /// <summary>
        /// 设置上标
        /// </summary>
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
                    SelectionCharOffset =  4;
                }
                else
                {
                    SelectionCharOffset = 0;
                }
            }
        }

        /// <summary>
        /// 设置下标
        /// </summary>
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
 

        /// <summary>
        ///RichTextBox  数字序列 1. 2. 3. 4. 5.  ... 
        /// </summary>
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
     
    
        //只须设置 不需要获得是否设置的返回值
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

        #endregion

        #region  RichTextBox Margin
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
        /// 当没设置的时候结果多出了L T R +2
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
        public  int RightMargin
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

#endregion
        
        #region RichTextBox 默认快捷键
        /*
            查找	CTRL+F
            替换	CTRL+R
            时间日期 	F5

            粗体	CTRL+B
            斜体	CTRL+I
            下划线	CTRL+U
         */

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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

                    //shift +tab 左缩进
                    case Keys.Shift | Keys.Tab:
                        if (SelectedText != "")
                        {
                            SelectionIndent -= 8;
                        }
                        return true;

                    //shift +tab 右缩进
                    case Keys.Tab:
                        if (SelectedText != "")
                        {
                            SelectionIndent += 8;
                          
                        }
                        return true;

                    //替换对话框
                    case Keys.Control | Keys.R:
                        ShowReplaceDlg();
                        return true;

                    //插入时间日期
                    case Keys.F5:
                        //2013-11-25 13:57:09
                        SelectedText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        return true;

                    //粘贴纯文本
                    case Keys.Control | Keys.Shift | Keys.V:
                        PasteAsText();
                        return true;

                    case Keys.Control | Keys.G:
                        ShowGoToDlg();
                return true;

                }
            }
 
            if (keyData == (Keys.Control | Keys.F))
            {
                ShowFindDlg();
            }
            return false;
        }


        #endregion

        #region RichTextBox 常用属性

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

        public void  PasteAsHtml()
        {
           
        }

        public void PasteAsUnicode()
        {

        }

        /// <summary>
        /// 剪切板是否为空
        /// </summary>
        /// <returns></returns>
        public  bool CanPaste()
        {
            return (Clipboard.GetDataObject() != null);
        }

        /// <summary>
        /// 剪切板是否有字符串
        /// </summary>
        /// <returns></returns>
        public bool CanPasteAsText()
        {
            return Clipboard.GetDataObject().GetDataPresent(DataFormats.Text); 
        }
        /// <summary>
        /// 剪切板是否有位图
        /// </summary>
        /// <returns></returns>
        public bool CanPasteAsBmp()
        {
            return Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap); 
        }
        /// <summary>
        /// 剪切板是否HTML
        /// </summary>
        /// <returns></returns>
        public bool CanPasteAsHtml()
        {
            return Clipboard.GetDataObject().GetDataPresent(DataFormats.Html); 
        }

        /// <summary>
        /// 是否可以全选
        /// </summary>
        /// <returns></returns>
        public bool CanSelectAll()
        {
            return (richTextBox1.SelectedText.Length != richTextBox1.Text.Length);
        }

        private void InitialRichTextBoxCtrl()
        {
            //ContextMenuStrip = contextMenuStrip1;
            LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(richTextBox1_LinkClicked); 
        }

        /// <summary>
        /// 自动打开超链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            DialogResult b = MessageBox.Show("你要打开此链接吗?\n" + e.LinkText, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (b == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("iexplore.exe", e.LinkText);
            }
        }


        #endregion

        #region RichTextBox 通用对话框

        //private FindDialog FindDlg = new FindDialog();
        //private ReplaceDialog ReplaceDlg=new ReplaceDialog();

        /// <summary>
        /// 查找对话框
        /// </summary>
        public void ShowFindDlg()
        {
            FindDialog FindDlg = new FindDialog();
            FindDlg.richTextBox1 = this;
            FindDlg.textBox1.Text = this.SelectedText;
            FindDlg.StartPosition = FormStartPosition.CenterParent;
            FindDlg.ShowDialog();
        }

        /// <summary>
        /// 替换 对话框
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
        /// 字体对话框
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
        /// 转到 对话框
        /// </summary>
        public void ShowGoToDlg()
        {
            Point pt = this.GetCaretPosition();

            frm_GOTO frm = new frm_GOTO();
            frm.label1.Text = "等号(1 - " + this.Lines.Length.ToString() + ")(&L)";         
            frm.textBox1.Text = pt.X.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int Line = Convert.ToInt32(frm.textBox1.Text);
                if (Line >= 1)
                {
                    if (Line > this.Lines.Length+1)
                    {
                        MessageBox.Show("行数大于现有的行数");
                    }
                    else
                    {
                        this.jumpLine(Line);
                    }
                }
            }
        }

        //RichTextBox 插入图片
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

        //插入表格对话框
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


        #endregion

        #region RichTextBox
        #endregion

        #region 实现 页面设置  打印预览 打印

        //页面设置
        public void ShowPageSetupDlg()
        {
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = this;
            r.ShowPageSetupDlg();
        }
        //打印预览功能
        public void ShowShowPagePriviewDlg()
        {
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = this;
            r.ShowShowPagePriviewDlg();
        }

        //打印
        public void ShowPrintDlg()
        {
            richTextBoxPrintClass r = new richTextBoxPrintClass();
            r.richTextBox = this;
            r.ShowPrintDlg();
        }
#endregion

        #region 支持表格正确粘贴

        
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
        #endregion
    }

}
