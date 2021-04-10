using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;

 
namespace WindowsFormsApplication1
{
    public partial class RichTextBoxForm : Form
    {
        public RichTextBoxForm()
        {
            InitializeComponent();
            fontComboBox1.Initialize();
            fontSizeComboBox1.Initialize();
            richTextBoxCtrl1.LeftMargin = 0;
            richTextBoxCtrl1.TopMargin = 0;
 
        }
 

     

        #region Functions...

        //AbsFileName 
        //D:\Administrator\Documents\MyProject\CSHARP_WinCtrl\WindowsFormsApplication1\bin\Debug\我的文件夹\Bugs\ToDoList.rtf
        public string AbsFileName = "";


        public void CheckFileModify()
        {
            if (File.Exists(AbsFileName))
                if (richTextBoxCtrl1.Modified)
                {
                    DialogResult b = MessageBox.Show("是否保存文件: \"" + System.IO.Path.GetFileName(AbsFileName) + "\"", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (b == DialogResult.Yes)
                    {
                        SaveFile();
                        richTextBoxCtrl1.Modified = false;
                    }
                }
        }
        public void LoadFile()
        {
            if(File.Exists(AbsFileName))
            {
                richTextBoxCtrl1.LoadFile(AbsFileName);
                richTextBoxCtrl1.Modified = false;
                btn_Save.Enabled = richTextBoxCtrl1.Modified;
                
            }
        }

        private void SaveFile()
        {
            richTextBoxCtrl1.SaveFile(AbsFileName);
            btn_Save.Enabled = false;
            richTextBoxCtrl1.Modified = false;
           
        }



        #region AddFont

        private void AddFont()
        {
            foreach (FontFamily fam in FontFamily.Families)
            {
                fontComboBox1.Items.Add(fam.Name);
                fontComboBox1.AutoCompleteCustomSource.Add(fam.Name);
            }

        }
        #endregion


        #region StatueStrip
        private void UpdateStatusStripButton()
        {
            Point pt = richTextBoxCtrl1.GetCaretPosition();

            string modify = richTextBoxCtrl1.Modified ? "Modified" : "Ready";
            string Col = "Column: " + pt.X;
            string Line = "Line: " + pt.Y;
            string SelStart = "SelStart:" + richTextBoxCtrl1.SelectionStart.ToString();
            string SelLength = "SelLength:" + richTextBoxCtrl1.SelectionLength.ToString();


            string fileName = File.Exists(richTextBoxCtrl1.AbsFileName) ? richTextBoxCtrl1.AbsFileName + "    " : "";
            toolStripStatusLabel1.Text = string.Format("{0}{1}    {2}    {3}    {4}    {5}", fileName,modify, Line, Col, SelStart, SelLength);

      
        }

        #endregion
#endregion


        #region ToolStrip 
                
        private void Form1_Load(object sender, EventArgs e)
        {
            AddFont();
            //this.BackColor = richTextBoxCtrl1.BackColor;
            customTrackBar1.BackColor = this.BackColor;
            EnabledColorPickStatus();
             
            UpdateStatusStripButton();
        }

        private void fontComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize;
            try
            {
                fontSize = richTextBoxCtrl1.SelectionFont.Size;
            }
            catch
            {
                fontSize = richTextBoxCtrl1.Font.Size;
            }
            richTextBoxCtrl1.SelectionFont = new Font(fontComboBox1.Text, fontSize);
        }

        private void fontSizeComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName;
            try
            {
                fontName = richTextBoxCtrl1.SelectionFont.Name;
            }
            catch
            {
                fontName = richTextBoxCtrl1.Font.Name;
            }

            float fontSize = Convert.ToSingle(fontSizeComboBox1.Text);
            richTextBoxCtrl1.SelectionFont = new Font(fontName, fontSize);
        }

        private void BtnUnOrderlist_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectionBullet = !richTextBoxCtrl1.SelectionBullet;
        }

        private void BtnOrderlist_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectionOrderList = !richTextBoxCtrl1.SelectionOrderList;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.NewDocument();
            UpdateCaption();
            EditMode();
            UpdateStatusStripButton();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowOpenFileDlg();
            UpdateStatusStripButton();
            UpdateCaption();
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowSaveFileDlg();
            UpdateCaption();
            UpdateStatusStripButton();
        }

        private void UpdateCaption()
        {
            if (File.Exists(richTextBoxCtrl1.AbsFileName))
            {
                Text = richTextBoxCtrl1.FileName + " - RichTextEditor";
                this.AbsFileName = richTextBoxCtrl1.AbsFileName;
            }
            else
            {
                Text = "未命名.rtf" + " - RichTextEditor";
                AbsFileName = "";
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowShowPagePriviewDlg();
        }

        private void btnPageSetUp_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowPageSetupDlg();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowPrintDlg();
        }

        private void BtnInsertPicture_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowInsertImageDlg();
        }

        private void BtnBold_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ToggleBold();
            ToolButtonCheckedState();
        }

        private void BtnItatic_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ToggleItalic();
            ToolButtonCheckedState();
        }

        private void BtnUnderLine_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ToggleUnderLine();
            ToolButtonCheckedState();
        }

        //func
        private void BtnSubSript_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectionSubScript = !richTextBoxCtrl1.SelectionSubScript;
            ToolButtonCheckedState();
        }
        //func
        private void BtnSuperScript_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectionSupperScript = !richTextBoxCtrl1.SelectionSupperScript;
            ToolButtonCheckedState();
        }

        private void BtnAlignLeft_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectionAlignment = HorizontalAlignment.Left;
            ToolButtonCheckedState();
        }

        private void BtnAlignCenter_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectionAlignment = HorizontalAlignment.Center;
            ToolButtonCheckedState();
        }

        private void BtnAlignRight_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectionAlignment = HorizontalAlignment.Right;
            ToolButtonCheckedState();
        }

        private void BtnForeColor_SelectedColorChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(BtnForeColor.Color.ToString());
            //if (!richTextBoxCtrl1.ReadOnly)
            //    if (BtnForeColor.Pressed)
            richTextBoxCtrl1.SelectionColor = BtnForeColor.Color;
        }

        private void BtnForeBackColor_SelectedColorChanged(object sender, EventArgs e)
        {
            //if (BtnForeColor.Pressed)
            //if (!richTextBoxCtrl1.ReadOnly)
            richTextBoxCtrl1.SelectionBackColor = BtnForeBackColor.Color;
        }

        private void Cut1_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.Cut();
        }

        private void Copy1_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.Copy();
        }

        private void Paste1_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.Paste();
        }

        private void Delete1_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectedText = "";
        }

        private void SelectAll1_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectAll();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Copy1.Enabled = (richTextBoxCtrl1.SelectedText != "");
            Cut1.Enabled = (richTextBoxCtrl1.SelectedText != "");
            Delete1.Enabled = (richTextBoxCtrl1.SelectedText != "") && !(richTextBoxCtrl1.ReadOnly);
            Paste1.Enabled = (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) | Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap));

            Cut1.Visible = !(richTextBoxCtrl1.ReadOnly);
            Delete1.Visible = !(richTextBoxCtrl1.ReadOnly);
            Paste1.Visible = !(richTextBoxCtrl1.ReadOnly);

            SelectAll1.Enabled = (richTextBoxCtrl1.SelectionLength != richTextBoxCtrl1.TextLength);
            //PasteTxt.Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
        }

        //SelectionChanged//为什么如何的卡
        //TextChanged

        //KeyDown input slow
        //Click
        private void ToolButtonCheckedState()
        {

            if (richTextBoxCtrl1.SelectionFont == null)
                return;

            fontComboBox1.Text = richTextBoxCtrl1.SelectionFont.Name.ToString();
            fontSizeComboBox1.Text = richTextBoxCtrl1.SelectionFont.Size.ToString();

            BtnBold.Checked = richTextBoxCtrl1.SelectionFont.Bold;
            BtnItatic.Checked = richTextBoxCtrl1.SelectionFont.Italic;
            BtnUnderLine.Checked = richTextBoxCtrl1.SelectionFont.Underline;


            cb_FontStyles.Text = richTextBoxCtrl1.GetFontFormat();
            //////选择的文本会被去除颜色 自己写一个吧
            //if (richTextBoxCtrl1.SelectedText=="")
            //{
            //    BtnForeColor.Color = richTextBoxCtrl1.SelectionColor;
            //    BtnForeBackColor.Color = richTextBoxCtrl1.SelectionBackColor;
            //}


            BtnSubSript.Checked = richTextBoxCtrl1.SelectionSubScript;
            BtnSuperScript.Checked = richTextBoxCtrl1.SelectionSupperScript;


            BtnOrderlist.Checked = richTextBoxCtrl1.SelectionOrderList;
            BtnUnOrderlist.Checked = richTextBoxCtrl1.SelectionBullet;

            BtnAlignLeft.Checked = (richTextBoxCtrl1.SelectionAlignment == HorizontalAlignment.Left);
            BtnAlignCenter.Checked = (richTextBoxCtrl1.SelectionAlignment == HorizontalAlignment.Center);
            BtnAlignRight.Checked = (richTextBoxCtrl1.SelectionAlignment == HorizontalAlignment.Right);
        }

        private void EnabledColorPickStatus()
        {
            ////选择的文本会被去除颜色 自己写一个吧
            if (richTextBoxCtrl1.SelectedText == "")
            {
                BtnForeColor.Color = richTextBoxCtrl1.SelectionColor;
                BtnForeBackColor.Color = richTextBoxCtrl1.SelectionBackColor;
            }
        }
 

        private void richTextBoxCtrl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                SaveFile();
            }

            //Text = ((float)richTextBoxCtrl1.ZoomFactor * 100).ToString() + "  " + customTrackBar1.trackBar1.Value.ToString();
            customTrackBar1.CurrentValue = ((float)richTextBoxCtrl1.ZoomFactor * 100);
        }

        private void richTextBoxCtrl1_TextChanged(object sender, EventArgs e)
        {
            btn_Save.Enabled = richTextBoxCtrl1.Modified&&File.Exists(AbsFileName);
            UpdateStatusStripButton();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }



        private void ReadMode()
        {
            richTextBoxCtrl1.ReadOnly = true;
            //read mode
            //不能编辑包括编辑的快捷键也不能用
            toolStrip_Editor.Visible = false;
            //richTextBoxCtrl1.BackColor = Color.FromArgb(255, 255, 192);
           
            this.BackColor = richTextBoxCtrl1.BackColor;
            fontComboBox1.Visible = false;
            fontSizeComboBox1.Visible = false;
           
            textRuler1.Visible = false;
 

        }
        private void EditMode()
        {
            richTextBoxCtrl1.ReadOnly = false;
            toolStrip_Editor.Visible = true;
            //richTextBoxCtrl1.BackColor = Color.White;
             
            this.BackColor = richTextBoxCtrl1.BackColor;
            fontComboBox1.Visible = true;
            fontSizeComboBox1.Visible = true;
            
            richTextBoxCtrl1.Focus();
            //Text = "编辑";
            textRuler1.Visible = true;
        }
        private void btn_ReadMode_Click(object sender, EventArgs e)
        {
            if (richTextBoxCtrl1.ReadOnly==false)
            {
                ReadMode();
            }
            else
            {
                EditMode();
            }
        }

 

        private void richTextBoxCtrl1_SelectionChanged(object sender, EventArgs e)
        {
            ToolButtonCheckedState();
            //设置后选择会出问题
            //
            UpdateStatusStripButton();
            UpdateTextRuler();

        }
     
        
        private void cb_FontStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SetFontFormat(cb_FontStyles.SelectedIndex);
        }

        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize;
            try
            {
                 fontSize = richTextBoxCtrl1.SelectionFont.Size;
            }
            catch 
            {
                fontSize = richTextBoxCtrl1.Font.Size;
            }
            richTextBoxCtrl1.SelectionFont = new Font(fontComboBox1.Text, fontSize);
        }

        private void CboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
           string fontName;
           try
           {
                fontName = richTextBoxCtrl1.SelectionFont.Name;
           }
           catch 
           {
               fontName = richTextBoxCtrl1.Font.Name;
           }

           float fontSize = Convert.ToSingle(fontSizeComboBox1.Text);
           richTextBoxCtrl1.SelectionFont = new Font(fontName, fontSize);
        }



        private void Insert_Table_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowInsertTableDlg();
        }


        private void richTextBoxCtrl1_Click(object sender, EventArgs e)
        {
            EnabledColorPickStatus();
        }

        private void RichTextBoxForm_Resize(object sender, EventArgs e)
        {
             
        }



        private void ts_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ts_Find_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowFindDlg();
        }

        private void ts_Replace_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowReplaceDlg();
        }

#endregion

        #region MenuStrip
        private void ts_Redo_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.Undo();
        }

        private void ts_Undo_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.Redo();
        }

        private void ts_DateTime_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.SelectedText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void ts_PasteAsText_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.PasteAsText();
        }

        private void ts_EditMode_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void ts_Preview_Click(object sender, EventArgs e)
        {
            ReadMode();
        }

        private void ts_HtmlSoruce_Click(object sender, EventArgs e)
        {

        }

        private void ts_Font_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowFontDlg();
        }

        private void ts_jumptoline_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ShowGoToDlg();
        }

        private void ts_File_Click(object sender, EventArgs e)
        {

        }

        private void ts_File_DropDownOpening(object sender, EventArgs e)
        {
            ts_Save.Enabled = File.Exists(AbsFileName);
        }

        private void ts_Edits_DropDownOpening(object sender, EventArgs e)
        {
            bool bReadOnly = richTextBoxCtrl1.ReadOnly == false;
            ts_Redo.Enabled = richTextBoxCtrl1.CanRedo && bReadOnly;
            ts_Undo.Enabled = richTextBoxCtrl1.CanUndo && bReadOnly;
            ts_Cut.Enabled = richTextBoxCtrl1.SelectedText != "" && bReadOnly;
            ts_Copy.Enabled = richTextBoxCtrl1.SelectedText != "" && bReadOnly;
            ts_Paste.Enabled = richTextBoxCtrl1.CanPaste() && bReadOnly;
            ts_PasteAsHTML.Enabled = richTextBoxCtrl1.CanPasteAsHtml();
            ts_PasteAsText.Enabled = richTextBoxCtrl1.CanPasteAsText();
            //ts_PasteAsUnicode.Enabled = richTextBoxCtrl1;
            ts_PasteAsBmp.Enabled = richTextBoxCtrl1.CanPasteAsBmp();
            //ts_PasteAsRtf.Enabled = richTextBoxCtrl1;
            ts_PasteSpecial.Enabled = bReadOnly;
            ts_Replace.Enabled = bReadOnly;
            ts_jumptoline.Enabled = bReadOnly;
            ts_SelectAll.Enabled = richTextBoxCtrl1.CanSelectAll();
            ts_DateTime.Enabled = bReadOnly;
        }

        private void ts_About_Click(object sender, EventArgs e)
        {
 
        }

        private void ts_PasteAsBmp_Click(object sender, EventArgs e)
        {
            richTextBoxCtrl1.PasteAsBmp();
        }


        private void ts_Insert_DropDownOpening(object sender, EventArgs e)
        {
            ts_InsertImage.Enabled = !richTextBoxCtrl1.ReadOnly;
            ts_InsertTable.Enabled = !richTextBoxCtrl1.ReadOnly;
        }



        private void ts_Format_DropDownOpening(object sender, EventArgs e)
        {
            ts_Font.Enabled = !richTextBoxCtrl1.ReadOnly;
        }

        private void ts_View_DropDownOpening(object sender, EventArgs e)
        {
            ts_EditMode.Enabled = richTextBoxCtrl1.ReadOnly;
            ts_Preview.Enabled = !richTextBoxCtrl1.ReadOnly;
            ts_HtmlSoruce.Enabled = !richTextBoxCtrl1.ReadOnly;
        }



        private void customTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            richTextBoxCtrl1.ZoomFactor = ((float)customTrackBar1.CurrentValue / 100);
        }
#endregion

        #region textRuler1


        private void textRuler1_BothLeftIndentsChanged(int LeftIndent, int HangIndent)
        {
            richTextBoxCtrl1.SelectionIndent =
             (int)(this.textRuler1.LeftIndent * this.textRuler1.DotsPerMillimeter);

            richTextBoxCtrl1.SelectionHangingIndent =
                (int)(this.textRuler1.LeftHangingIndent * this.textRuler1.DotsPerMillimeter)
                - (int)(this.textRuler1.LeftIndent * this.textRuler1.DotsPerMillimeter);


        }

        private void textRuler1_LeftHangingIndentChanging(int NewValue)
        {
            try
            {
                richTextBoxCtrl1.SelectionHangingIndent =
                (int)(this.textRuler1.LeftHangingIndent * this.textRuler1.DotsPerMillimeter) -
                 (int)(this.textRuler1.LeftIndent * this.textRuler1.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void textRuler1_LeftIndentChanging(int NewValue)
        {
            try
            {
                richTextBoxCtrl1.SelectionIndent = (int)(this.textRuler1.LeftIndent * this.textRuler1.DotsPerMillimeter);
                richTextBoxCtrl1.SelectionHangingIndent = (int)(this.textRuler1.LeftHangingIndent * this.textRuler1.DotsPerMillimeter) - (int)(this.textRuler1.LeftIndent * this.textRuler1.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void textRuler1_RightIndentChanging(int NewValue)
        {
            try
            {
                richTextBoxCtrl1.SelectionRightIndent = (int)(this.textRuler1.RightIndent * this.textRuler1.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void textRuler1_TabAdded(TextRuler.TabEventArgs args)
        {
            try
            {
                richTextBoxCtrl1.SelectionTabs = this.textRuler1.TabPositionsInPixels.ToArray();
            }
            catch (Exception)
            {
            }
        }

        private void textRuler1_TabChanged(TextRuler.TabEventArgs args)
        {
            try
            {
                richTextBoxCtrl1.SelectionTabs = this.textRuler1.TabPositionsInPixels.ToArray();
            }
            catch (Exception)
            {
            }
        }

        private void textRuler1_TabRemoved(TextRuler.TabEventArgs args)
        {
            try
            {
                richTextBoxCtrl1.SelectionTabs = this.textRuler1.TabPositionsInPixels.ToArray();
            }
            catch (Exception)
            {
            }
        }

        private void UpdateTextRuler()
        {

            this.textRuler1.SetTabPositionsInPixels(this.richTextBoxCtrl1.SelectionTabs);


            if (this.richTextBoxCtrl1.SelectionLength < this.richTextBoxCtrl1.TextLength - 1)
            {
                this.textRuler1.LeftIndent =
                    (int)(this.richTextBoxCtrl1.SelectionIndent / this.textRuler1.DotsPerMillimeter); //convert pixels to millimeter

                this.textRuler1.LeftHangingIndent =
                    (int)((float)this.richTextBoxCtrl1.SelectionHangingIndent / this.textRuler1.DotsPerMillimeter) + this.textRuler1.LeftIndent; //convert pixels to millimeters

                this.textRuler1.RightIndent = 
                    (int)(this.richTextBoxCtrl1.SelectionRightIndent / this.textRuler1.DotsPerMillimeter); //convert pixels to millimeters                
            }
        }

        private void textRuler1_LeftMarginChanging(int NewValue)
        {
            //richTextBoxCtrl1.LeftMargin = (int)(NewValue * 3.77);
            //textRuler1.LeftIndent = NewValue;
            //textRuler1.LeftHangingIndent = NewValue;
        }


        private void textRuler1_RightMarginChanging(int NewValue)
        {
            richTextBoxCtrl1.RightMargin = (int)(NewValue * 3.77);
            //textRuler1.RightIndent = NewValue;
        }

        #endregion




 

    }
}
