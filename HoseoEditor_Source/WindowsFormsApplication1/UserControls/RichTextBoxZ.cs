using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AdvancedNotepad_CSharp
{
   public class RichTextBoxZ : RichTextBox
    {
        public SyntaxSettings m_settings = new SyntaxSettings();
        public bool m_bPaint = true;
        public string m_strLine = "";
        public int m_nContentLength = 0;
        public int m_nLineLength = 0;
        public int m_nLineStart = 0;
        public int m_nLineEnd = 0;
        public string m_strKeywords = "";
        public string m_strContextualKeywords = "";
        public string m_strUserDefine1 = "";
        public string m_strUserDefine2 = "";
        public string m_strUserDefine3 = "";
        
        public int m_nCurSelection = 0;
        
        /// <summary>
        /// The settings.
        /// </summary>
        public SyntaxSettings Settings
        {
            get { return m_settings; }
        }

        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x00f)
            {
                if (m_bPaint)
                    base.WndProc(ref m);
                else
                    m.Result = IntPtr.Zero;
            }
            else
                base.WndProc(ref m);
        }

        /// <summary>
        /// Process a line.
        /// </summary>
        public void ProcessLine()
        {
            // Save the position and make the whole line black
            int nPosition = SelectionStart;
            SelectionStart = m_nLineStart;
            SelectionLength = m_nLineLength;
            SelectionColor = Color.White;

            // Process the keywords
            ProcessRegex(m_strKeywords, Settings.KeywordColor);

            // Process the Contextualkeywords
            ProcessRegex(m_strContextualKeywords, Settings.ContextualColor);

            // Process UserDefine keywords
            ProcessRegex(m_strUserDefine1, Settings.UserDefine1Color);
            ProcessRegex(m_strUserDefine2, Settings.UserDefine2Color);
            ProcessRegex(m_strUserDefine3, Settings.UserDefine3Color);
            // Process numbers
            if (Settings.EnableIntegers)
                ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", Settings.IntegerColor);
            // Process strings
            if (Settings.EnableStrings)
                ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor);
            if (Settings.EnableLineComments)
            {
                ProcessRegex("\\/\\*[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\\*\\/", Settings.CommentColor);//\/\*.*\n.*\*\/
                ProcessRegex("\\/\\*.*\\r\\n.*\\*\\/", Settings.CommentColor);//여러줄 주석 문제는 ProcessLine이라서 그런듯.
            }
               
            // Process comments
            if (Settings.EnableComments && !string.IsNullOrEmpty(Settings.Comment))
                ProcessRegex(Settings.Comment + ".*$", Settings.CommentColor);

            SelectionStart = nPosition;
            SelectionLength = 0;
            SelectionColor = Color.White;

            m_nCurSelection = nPosition;
        }
        /// <summary>
        /// Process a regular expression.
        /// </summary>
        /// <param name="strRegex">The regular expression.</param>
        /// <param name="color">The color.</param>
        private void ProcessRegex(string strRegex, Color color)
        {
            Regex regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match regMatch;
            for (regMatch = regKeywords.Match(m_strLine); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                // Process the words
                int nStart = m_nLineStart + regMatch.Index;
                int nLenght = regMatch.Length;
                SelectionStart = nStart;
                SelectionLength = nLenght;
                SelectionColor = color;
            }
        }
        /// <summary>
        /// Compiles the keywords as a regular expression.
        /// </summary>
        public void CompileKeywords()
        {
            for (int i = 0; i < Settings.Keywords.Count; i++)
            {
                string strKeyword = Settings.Keywords[i];

                if (i == Settings.Keywords.Count - 1)
                    m_strKeywords += "\\b" + strKeyword + "\\b";
                else
                    m_strKeywords += "\\b" + strKeyword + "\\b|";
            }

            for (int i = 0; i < Settings.ContextualKeywords.Count; i++)
            {
                string strKeyword = Settings.ContextualKeywords[i];

                if (i == Settings.ContextualKeywords.Count - 1)
                    m_strContextualKeywords += "\\b" + strKeyword + "\\b";
                else
                    m_strContextualKeywords += "\\b" + strKeyword + "\\b|";
            }

            for (int i = 0; i < Settings.UserDefine1.Count; i++)
            {
                string strKeyword = Settings.UserDefine1[i];
                if (i == Settings.UserDefine1.Count - 1)
                    m_strUserDefine1 += "\\b" + strKeyword + "\\b";
                else
                    m_strUserDefine1 += "\\b" + strKeyword + "\\b|";
            }

            for (int i = 0; i < Settings.UserDefine2.Count; i++)
            {
                string strKeyword = Settings.UserDefine2[i];

                if (i == Settings.UserDefine2.Count - 1)
                    m_strUserDefine2 += "\\b" + strKeyword + "\\b";
                else
                    m_strUserDefine2 += "\\b" + strKeyword + "\\b|";
            }

            for (int i = 0; i < Settings.UserDefine3.Count; i++)
            {
                string strKeyword = Settings.UserDefine3[i];

                if (i == Settings.UserDefine3.Count - 1)
                    m_strUserDefine3 += "\\b" + strKeyword + "\\b";
                else
                    m_strUserDefine3 += "\\b" + strKeyword + "\\b|";
            }
        }

        public void ProcessAllLines()
        {
            m_bPaint = false;

            int nStartPos = 0;
            int i = 0;
            int nOriginalPos = SelectionStart;
            while (i < Lines.Length)
            {
                m_strLine = Lines[i];
                m_nLineStart = nStartPos;
                m_nLineEnd = m_nLineStart + m_strLine.Length;

                ProcessLine();
                i++;

                nStartPos += m_strLine.Length + 1;
            }

            m_bPaint = true;
        }
        public RichTextBoxZ()
       {

       }
       protected override void OnSelectionChanged(EventArgs e)
       {
       }
        int lineh = 15;
        const int wm_paint = 15;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RichTextBoxZ
            // 
            this.ResumeLayout(false);

        }

        
    }
    public class SyntaxList
    {
        public List<string> m_rgList = new List<string>();
        public Color m_color = new Color();
    }

    /// <summary>
    /// Settings for the keywords and colors.
    /// </summary>
    public class SyntaxSettings
    {
        SyntaxList m_rgKeywords = new SyntaxList();
        SyntaxList m_rgContextualKeywords = new SyntaxList();
        SyntaxList m_rgUserDefine1 = new SyntaxList();
        SyntaxList m_rgUserDefine2 = new SyntaxList();
        SyntaxList m_rgUserDefine3 = new SyntaxList();
        string m_strComment = "";
        Color m_colorComment = Color.Green;
        Color m_colorString = Color.Gray;
        Color m_colorInteger = Color.Red;
        bool m_bEnableComments = true;
        bool m_bEnableIntegers = true;
        bool m_bEnableLineComments = true;
        bool m_bEnableStrings = true;

        #region Properties
        /// <summary>
        /// A list containing all keywords.
        /// </summary>
        public List<string> Keywords
        {
            get { return m_rgKeywords.m_rgList; }
        }
        public List<string> ContextualKeywords
        {
            get { return m_rgContextualKeywords.m_rgList; }
        }
        public List<string> UserDefine1
        {
            get { return m_rgUserDefine1.m_rgList; }
        }
        public List<string> UserDefine2
        {
            get { return m_rgUserDefine2.m_rgList; }
        }
        public List<string> UserDefine3
        {
            get { return m_rgUserDefine3.m_rgList; }
        }
        /// <summary>
        /// The color of keywords.
        /// </summary>
        public Color KeywordColor
        {
            get { return m_rgKeywords.m_color; }
            set { m_rgKeywords.m_color = value; }
        }
        public Color ContextualColor
        {
            get { return m_rgContextualKeywords.m_color; }
            set { m_rgContextualKeywords.m_color = value; }
        }
        public Color UserDefine1Color
        {
            get { return m_rgUserDefine1.m_color; }
            set { m_rgUserDefine1.m_color = value; }
        }
        public Color UserDefine2Color
        {
            get { return m_rgUserDefine2.m_color; }
            set { m_rgUserDefine2.m_color = value; }
        }
        public Color UserDefine3Color
        {
            get { return m_rgUserDefine3.m_color; }
            set { m_rgUserDefine3.m_color = value; }
        }
        /// <summary>
        /// A string containing the comment identifier.
        /// </summary>
        public string Comment
        {
            get { return m_strComment; }
            set { m_strComment = value; }
        }
        /// <summary>
        /// The color of comments.
        /// </summary>
        public Color CommentColor
        {
            get { return m_colorComment; }
            set { m_colorComment = value; }
        }
        /// <summary>
        /// Enables processing of comments if set to true.
        /// </summary>
        public bool EnableComments
        {
            get { return m_bEnableComments; }
            set { m_bEnableComments = value; }
        }
        /// <summary>
        /// Enables processing of integers if set to true.
        /// </summary>
        public bool EnableIntegers
        {
            get { return m_bEnableIntegers; }
            set { m_bEnableIntegers = value; }
        }
        /// <summary>
        /// Enables processing of integers if set to true.
        /// </summary>
        public bool EnableLineComments
        {
            get { return m_bEnableLineComments; }
            set { m_bEnableLineComments = value; }
        }
        /// <summary>
        /// Enables processing of strings if set to true.
        /// </summary>
        public bool EnableStrings
        {
            get { return m_bEnableStrings; }
            set { m_bEnableStrings = value; }
        }
        /// <summary>
        /// The color of strings.
        /// </summary>
        public Color StringColor
        {
            get { return m_colorString; }
            set { m_colorString = value; }
        }
        /// <summary>
        /// The color of integers.
        /// </summary>
        public Color IntegerColor
        {
            get { return m_colorInteger; }
            set { m_colorInteger = value; }
        }
        #endregion
    }
}
