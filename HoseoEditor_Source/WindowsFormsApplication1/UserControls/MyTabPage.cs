using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MainFormRichTextBox;
using static AdvancedNotepad_CSharp.RichTextBoxZ;
namespace AdvancedNotepad_CSharp
{
   public class MyTabPage : System.Windows.Forms.TabPage
    {
        //현재 주석 안에 있는것들은 소스코드에디터
        //주석 밖에 있는것은 일반 에디터이므로
        //각각에 따라 구성해야함.
        public static int Mode = 0;
        public RichTextBoxForm mainform;
        public MyRichTextBox _developerEditor;
        public System.Windows.Forms.RichTextBoxCtrl _normalEditor;
        public TextRuler _textRuler = new System.Windows.Forms.TextRuler();



        public MyTabPage(RichTextBoxForm mf,int mode)
       {
            Mode = mode;
            mainform = mf;
            _normalEditor = new System.Windows.Forms.RichTextBoxCtrl(mf);
            _developerEditor = new MyRichTextBox(mf);
            //Mode (0) : Normal
            //Mode (1) : Developer Editor
            if (Mode == 0)
            {
                this._textRuler.Dock = DockStyle.Top;
                this._textRuler.Select();
                this._textRuler.BothLeftIndentsChanged += new System.Windows.Forms.TextRuler.MultiIndentChangedEventHandler(this.tRuler_BothLeftIndentsChanged);
                this._textRuler.LeftHangingIndentChanging += new System.Windows.Forms.TextRuler.IndentChangedEventHandler(this.tRuler_LeftHangingIndentChanging);
                this._textRuler.LeftIndentChanging += new System.Windows.Forms.TextRuler.IndentChangedEventHandler(this.tRuler_LeftIndentChanging);
                this._textRuler.RightIndentChanging += new System.Windows.Forms.TextRuler.IndentChangedEventHandler(this.tRuler_RightIndentChanging);
                this._textRuler.RightMarginChanging += new System.Windows.Forms.TextRuler.MarginChangedEventHandler(this.tRuler_RightMarginChanging);
                this._textRuler.TabAdded += new System.Windows.Forms.TextRuler.TabChangedEventHandler(this.tRuler_TabAdded);
                this._textRuler.TabChanged += new System.Windows.Forms.TextRuler.TabChangedEventHandler(this.tRuler_TabChanged);
                this._textRuler.TabRemoved += new System.Windows.Forms.TextRuler.TabChangedEventHandler(this.tRuler_TabRemoved);
                this._textRuler.BaseColor = Color.FromArgb(191, 205, 219);//new Color(RGB());// "191, 205, 219";
                this._textRuler.BorderColor = Color.FromArgb(191, 205, 219);
                this._textRuler.BackColor = Color.White;
                this._textRuler.TabsEnabled = true;
                this._textRuler.RightIndent = 0;
                this._textRuler.RightMargin = -1;
                this._textRuler.LeftHangingIndent = 0;
                this._textRuler.LeftIndent = 0;
                this._textRuler.LeftMargin = 0;




                this._normalEditor.Dock = DockStyle.Fill;
                this._normalEditor.TopMargin = 20;
                this._normalEditor.Text = "";
                _normalEditor.Font = new System.Drawing.Font("굴림", 11, FontStyle.Regular);
                this._normalEditor.Select();

                _normalEditor.TextChanged += new EventHandler(this.NormalEditor_TextChanged);
                _normalEditor.CursorChanged += new EventHandler(this.CursorChange);
                _normalEditor.SelectionChanged += new EventHandler(this.richTextBox1_SelectionChanged);

                _normalEditor.LinkClicked += new LinkClickedEventHandler(this.richTextBox1_LinkClicked);
                this.Controls.Add(_textRuler);
                this.Controls.Add(_normalEditor);
                
            }
            else
            {
                this._developerEditor.Dock = DockStyle.Fill;
                this._developerEditor.richTextBox1.Text = "";
                _developerEditor.richTextBox1.Font = new System.Drawing.Font("굴림", 11, FontStyle.Regular);
                this._developerEditor.richTextBox1.Select();
                this._developerEditor.richTextBox1.ImeMode = ImeMode.Off;
                _developerEditor.richTextBox1.TextChanged += new EventHandler(this.DeveloperEditor_TextChanged);
                _developerEditor.CursorChanged += new EventHandler(this.CursorChange);
                _developerEditor.richTextBox1.SelectionChanged += new EventHandler(this.richTextBox1_SelectionChanged);
                _developerEditor.richTextBox1.KeyPress += new KeyPressEventHandler(this.DeveloperEditor_KeyEvent);
                _developerEditor.richTextBox1.LinkClicked += new LinkClickedEventHandler(this.richTextBox1_LinkClicked);

                this.Controls.Add(_developerEditor);

            }
           
            
            
        }

        private void DeveloperEditor_KeyEvent(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar < 128 && _developerEditor.richTextBox1.ImeMode==ImeMode.Hangul)
            {
                // Calculate shit here.
                _developerEditor.richTextBox1.m_nContentLength = _developerEditor.richTextBox1.TextLength;

                int nCurrentSelectionStart = _developerEditor.richTextBox1.SelectionStart;
                int nCurrentSelectionLength = _developerEditor.richTextBox1.SelectionLength;

                _developerEditor.richTextBox1.m_bPaint = false;

                // Find the start of the current line.
                _developerEditor.richTextBox1.m_nLineStart = nCurrentSelectionStart;
                while ((_developerEditor.richTextBox1.m_nLineStart > 0) && (_developerEditor.richTextBox1.Text[_developerEditor.richTextBox1.m_nLineStart - 1] != '\n'))
                    _developerEditor.richTextBox1.m_nLineStart--;
                // Find the end of the current line.
                _developerEditor.richTextBox1.m_nLineEnd = nCurrentSelectionStart;
                while ((_developerEditor.richTextBox1.m_nLineEnd < _developerEditor.richTextBox1.Text.Length) && (_developerEditor.richTextBox1.Text[_developerEditor.richTextBox1.m_nLineEnd] != '\n'))
                    _developerEditor.richTextBox1.m_nLineEnd++;
                // Calculate the length of the line.
                _developerEditor.richTextBox1.m_nLineLength = _developerEditor.richTextBox1.m_nLineEnd - _developerEditor.richTextBox1.m_nLineStart;
                // Get the current line.
                _developerEditor.richTextBox1.m_strLine = _developerEditor.richTextBox1.Text.Substring(_developerEditor.richTextBox1.m_nLineStart, _developerEditor.richTextBox1.m_nLineLength);

                // Process this line.
                _developerEditor.richTextBox1.ProcessLine();

                _developerEditor.richTextBox1.m_bPaint = true;
            }
        }

        private void tRuler_RightMarginChanging(int NewValue)
        {
         
                _normalEditor.RightMargin = (int)(NewValue * 3.77);

            //textRuler1.RightIndent = NewValue;
        }

        private void tRuler_BothLeftIndentsChanged(int LeftIndent, int HangIndent)
        {
                _normalEditor.SelectionIndent =
             (int)(_textRuler.LeftIndent * _textRuler.DotsPerMillimeter);

                _normalEditor.SelectionHangingIndent =
                    (int)(_textRuler.LeftHangingIndent * _textRuler.DotsPerMillimeter)
                    - (int)(_textRuler.LeftIndent * _textRuler.DotsPerMillimeter);




        }

        private void tRuler_LeftIndentChanging(int NewValue)
        {

                _normalEditor.SelectionIndent = (int)(_textRuler.LeftIndent * _textRuler.DotsPerMillimeter);
                _normalEditor.SelectionHangingIndent = (int)(_textRuler.LeftHangingIndent * _textRuler.DotsPerMillimeter) - (int)(_textRuler.LeftIndent * _textRuler.DotsPerMillimeter);

        }

        private void tRuler_RightIndentChanging(int NewValue)
        {

                _normalEditor.SelectionRightIndent = (int)(_textRuler.RightIndent * _textRuler.DotsPerMillimeter);

        }

        private void tRuler_TabAdded(TextRuler.TabEventArgs args)
        {
                _normalEditor.SelectionTabs = _textRuler.TabPositionsInPixels.ToArray();

        }

        private void tRuler_TabChanged(TextRuler.TabEventArgs args)
        {
                _normalEditor.SelectionTabs = _textRuler.TabPositionsInPixels.ToArray();
        }

        private void tRuler_TabRemoved(TextRuler.TabEventArgs args)
        {

                _normalEditor.SelectionTabs = _textRuler.TabPositionsInPixels.ToArray();

        }

        private void tRuler_LeftHangingIndentChanging(int NewValue)
        {
            try
            {
                _normalEditor.SelectionHangingIndent =
                (int)(this._textRuler.LeftHangingIndent * this._textRuler.DotsPerMillimeter) -
                 (int)(this._textRuler.LeftIndent * this._textRuler.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }
        private void DeveloperEditor_TextChanged(object sender, EventArgs e)
        {
            mainform.UpdateStatusStripButton();
            String str = this.Text;
            if (str.Contains("*"))
            {

            }
            else
            {
                this.Text = str + "*";
            }
            if (this._developerEditor.richTextBox1.ImeMode != ImeMode.Hangul)
            {

                // Calculate shit here.
                _developerEditor.richTextBox1.m_nContentLength = _developerEditor.richTextBox1.TextLength;

                int nCurrentSelectionStart = _developerEditor.richTextBox1.SelectionStart;
                int nCurrentSelectionLength = _developerEditor.richTextBox1.SelectionLength;

                _developerEditor.richTextBox1.m_bPaint = false;

                // Find the start of the current line.
                _developerEditor.richTextBox1.m_nLineStart = nCurrentSelectionStart;
                while ((_developerEditor.richTextBox1.m_nLineStart > 0) && (_developerEditor.richTextBox1.Text[_developerEditor.richTextBox1.m_nLineStart - 1] != '\n'))
                    _developerEditor.richTextBox1.m_nLineStart--;
                // Find the end of the current line.
                _developerEditor.richTextBox1.m_nLineEnd = nCurrentSelectionStart;
                while ((_developerEditor.richTextBox1.m_nLineEnd < _developerEditor.richTextBox1.Text.Length) && (_developerEditor.richTextBox1.Text[_developerEditor.richTextBox1.m_nLineEnd] != '\n'))
                    _developerEditor.richTextBox1.m_nLineEnd++;
                // Calculate the length of the line.
                _developerEditor.richTextBox1.m_nLineLength = _developerEditor.richTextBox1.m_nLineEnd - _developerEditor.richTextBox1.m_nLineStart;
                // Get the current line.
                _developerEditor.richTextBox1.m_strLine = _developerEditor.richTextBox1.Text.Substring(_developerEditor.richTextBox1.m_nLineStart, _developerEditor.richTextBox1.m_nLineLength);

                // Process this line.
                _developerEditor.richTextBox1.ProcessLine();

                _developerEditor.richTextBox1.m_bPaint = true;

            }
        }
        private void CursorChange(object sender, EventArgs e)
        {
            MessageBox.Show("ㅎ솣풀");
            mainform.UpdateStatusStripButton();
        }
        private void NormalEditor_TextChanged(object sender, EventArgs e)
        {
            mainform.UpdateStatusStripButton();
            String str = this.Text;
            if (str.Contains("*"))
            {

            }
            else
            {
                this.Text = str + "*";
            }
            
        }
       private void richTextBox1_SelectionChanged(object sender, EventArgs e)
       {
            
            if (Mode == 0)
            {
                int sel = _normalEditor.SelectionStart;
                int line = _normalEditor.GetLineFromCharIndex(sel) + 1;
                int col = sel - _normalEditor.GetFirstCharIndexFromLine(line - 1) + 1;
            }
            else
            {
                int sel = _developerEditor.richTextBox1.SelectionStart;
                int line = _developerEditor.richTextBox1.GetLineFromCharIndex(sel) + 1;
                int col = sel - _developerEditor.richTextBox1.GetFirstCharIndexFromLine(line - 1) + 1;

            }
           

        }



       private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {

                Process.Start(e.LinkText);
            }
            catch
            {

            }
       }

    }
}
