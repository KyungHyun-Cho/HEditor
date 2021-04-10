using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


//2013-11-27 02:00:13
////清除样式
//richTextBoxBulletClass r = new richTextBoxBulletClass();
//r.richTextBox = richTextBox1;
//r.RemoveSelectionParaFormat2();


////属性获得

//richTextBoxBulletClass r = new richTextBoxBulletClass();
//r.richTextBox = richTextBox1;
//btn.Checked = r.SelectionOrderList;


////设置样式
//richTextBoxBulletClass r = new richTextBoxBulletClass();
//r.richTextBox = richTextBox1;
//r.SelectionOrderList = !r.SelectionOrderList;

namespace RichTextBoxCtrl
{
    public class richTextBoxBulletClass
    {
        public RichTextBox richTextBox;
        public richTextBoxBulletClass()
        {
            richTextBox = new RichTextBox();
        }

        #region PARAFORMAT2
        [StructLayout(LayoutKind.Sequential)]
        private class PARAFORMAT2
        {
            public int cbSize;
            public int dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
            public int[] rgxTabs;

            public int dySpaceBefore; 	// Vertical spacing before para
            public int dySpaceAfter; 	// Vertical spacing after para
            public int dyLineSpacing; 	// Line spacing depending on Rule
            public short sStyle; 		// Style handle
            public byte bLineSpacingRule; 	// Rule for line spacing (see tom.doc)
            public byte bOutlineLevel; 	// Outline Level
            public short wShadingWeight; 	// Shading in hundredths of a per cent
            public short wShadingStyle; 	// Byte 0: style, nib 2: cfpat, 3: cbpat
            public short wNumberingStart; 	// Starting value for numbering
            public short wNumberingStyle; 	// Alignment, Roman/Arabic, (), ), ., etc.
            public short wNumberingTab; 	// Space bet 1st indent and 1st-line text
            public short wBorderSpace; 	// Border-text spaces (nbl/bdr in pts)
            public short wBorderWidth; 	// Pen widths (nbl/bdr in half twips)
            public short wBorders; 		// Border styles (nibble/border)

            public PARAFORMAT2()
            {
                this.cbSize = Marshal.SizeOf(typeof(PARAFORMAT2));
            }
        }
        #endregion

        #region PARAFORMAT MASK VALUES



        public const uint WM_USER = 0x0400;
        // RichEdit messages 
        public const uint EM_GETPARAFORMAT = (WM_USER + 61);
        public const uint EM_SETPARAFORMAT = (WM_USER + 71);

        // PARAFORMAT mask values
        public const uint PFM_OFFSET = 0x00000004;
        public const uint PFM_NUMBERING = 0x00000020;

        // PARAFORMAT 2.0 masks and effects
        public const uint PFM_NUMBERINGSTYLE = 0x00002000;//设置项目编号的样式
        public const uint PFM_NUMBERINGTAB = 0x00004000;//设置项目编号按下Tab键的信息
        public const uint PFM_NUMBERINGSTART = 0x00008000;//设置项目编号的开始标识



        //wNumbering
        //Options used for bulleted or numbered paragraphs. 
        //To use this member, set the PFM_NUMBERING flag in the dwMask member. 
        //This member can be one of the following values.
        public enum Paraformat2Numbering
        {
            zero = 0,
            Normal = 1,             //No paragraph numbering or bullets.
            ArabicNumbers = 2,      //Uses Arabic numbers (1, 2, 3, ...). 
            LowerCaseLetter = 3,    //Uses lowercase letters (a, b, c, ...). 
            UpperCaseLetter = 4,    //Uses uppercase letters (A, B, C, ...). 
            LowerCaseRoman = 5,     //Uses lowercase Roman numerals (i, ii, iii, ...). 
            UpperCaseRoman = 6      //Uses uppercase Roman numerals (I, II, III, ...). 
        }

        //wNumberingStyle
        //Numbering style used with numbered paragraphs. 
        //Use this member in conjunction with the wNumbering member. 
        //This member is included only for compatibility with TOM interfaces;
        //the rich edit control stores the value but rich edit versions earlier than 3.0 do not use it to display the text or bullets.
        //To use this member, set the PFM_NUMBERINGSTYLE flag in the dwMask member. 
        //This member can be one of the following values. 
        public enum Paraformat2NumberingStyle
        {
            RightParenthesis = 0x000,//Follows the number with a right parenthesis.
            DoubleParenthesis = 0x100,//Encloses the number in parentheses.
            Period = 0x200,//Follows the number with a period.
            Plain = 0x300,//Displays only the number.
            zero = 0x400//Continues a numbered list without applying the next number or bullet. 
        }

        #endregion

        #region SetSelectionParaFormat2

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] PARAFORMAT2 lParam);

        public void SetSelectionParaFormat2(Paraformat2NumberingStyle style, Paraformat2Numbering Number)
        {
            PARAFORMAT2 p = new PARAFORMAT2();
            p.dwMask = (int)(PFM_NUMBERING | PFM_OFFSET | PFM_NUMBERINGSTART | PFM_NUMBERINGSTYLE | PFM_NUMBERINGTAB);

            p.wNumbering = (short)Number;
            //p.dxOffset = BulletIndent;
            p.wNumberingStyle = (short)style;
            p.wNumberingStart = 1;
            p.wNumberingTab = 500;

            SendMessage(richTextBox.Handle, EM_SETPARAFORMAT, 0, p);
        }
        #endregion


        //获得 wNumbering的返回值
        public Paraformat2Numbering GetSelectionParaformat2wNumbering()
        {
            PARAFORMAT2 p = new PARAFORMAT2();
            SendMessage(richTextBox.Handle, EM_GETPARAFORMAT, 0, p);
            return (Paraformat2Numbering)p.wNumbering;
        }

        //获得wNumberingStyleg的返回值
        public Paraformat2NumberingStyle GetSelectionParaformat2wNumberingStyle()
        {
            PARAFORMAT2 p = new PARAFORMAT2();
            SendMessage(richTextBox.Handle, EM_GETPARAFORMAT, 0, p);
            return (Paraformat2NumberingStyle)p.wNumberingStyle;
        }

        #region 更多样式... ...

        private void test()
        {
            //●●●●
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Period, Paraformat2Numbering.Normal);
            //1 2 3 4 5 ...
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Plain, Paraformat2Numbering.ArabicNumbers);
            //1. 2. 3. 4. 5.  ...
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Period, Paraformat2Numbering.ArabicNumbers);
            //1) 2) 3) 4) ...
            SetSelectionParaFormat2(Paraformat2NumberingStyle.RightParenthesis, Paraformat2Numbering.ArabicNumbers);
            //(1) (2) (3) (4) ...
            SetSelectionParaFormat2(Paraformat2NumberingStyle.DoubleParenthesis, Paraformat2Numbering.ArabicNumbers);
            //////////////////////////////////////////////////////////////////////////

            //a b c d e 
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Plain, Paraformat2Numbering.LowerCaseLetter);
            //a. b. c. d. e.
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Period, Paraformat2Numbering.LowerCaseLetter);
            //a) b) c) d) e)
            SetSelectionParaFormat2(Paraformat2NumberingStyle.RightParenthesis, Paraformat2Numbering.LowerCaseLetter);
            //(a) (b) (c) (d) (e)
            SetSelectionParaFormat2(Paraformat2NumberingStyle.DoubleParenthesis, Paraformat2Numbering.LowerCaseLetter);
            //////////////////////////////////////////////////////////////////////////

            //A B C D E 
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Plain, Paraformat2Numbering.UpperCaseLetter);
            //A. B. C. D. E.
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Period, Paraformat2Numbering.UpperCaseLetter);
            //A) B) C) D) E)
            SetSelectionParaFormat2(Paraformat2NumberingStyle.RightParenthesis, Paraformat2Numbering.UpperCaseLetter);
            //(A) (B) (C) (D) (E)
            SetSelectionParaFormat2(Paraformat2NumberingStyle.DoubleParenthesis, Paraformat2Numbering.UpperCaseLetter);
            //////////////////////////////////////////////////////////////////////////

            //I II III IIII IV 
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Plain, Paraformat2Numbering.LowerCaseRoman);
            //I. II. III. IIII. IV. 
            SetSelectionParaFormat2(Paraformat2NumberingStyle.Period, Paraformat2Numbering.LowerCaseRoman);
            //I) II) III) IIII) IV) 
            SetSelectionParaFormat2(Paraformat2NumberingStyle.RightParenthesis, Paraformat2Numbering.LowerCaseRoman);
            //(I) (II) (III) (IIII) (IV) 
            SetSelectionParaFormat2(Paraformat2NumberingStyle.DoubleParenthesis, Paraformat2Numbering.LowerCaseRoman);
            //////////////////////////////////////////////////////////////////////////

        }
        #endregion



        //清除选中的样式
        public void RemoveSelectionParaFormat2()
        {
            SetSelectionParaFormat2(0, 0);
        }



        #region  数字序列 1. 2. 3. 4. 5.  ...
        private bool bOrder = false;
        public bool SelectionOrderList
        {
            get
            {
                return (
                       (GetSelectionParaformat2wNumbering() == Paraformat2Numbering.ArabicNumbers) &&
                       (GetSelectionParaformat2wNumberingStyle() == Paraformat2NumberingStyle.Period)
                       );

            }
            set
            {
                bOrder = value;

                if (value == true)
                    SetSelectionParaFormat2(Paraformat2NumberingStyle.Period, Paraformat2Numbering.ArabicNumbers);
                else
                    RemoveSelectionParaFormat2();
            }
        }
        #endregion

    }
}
