using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Printing;


#region 调用示例
/*使用
//页面设置
private void btnPageSetup_Click(object sender, EventArgs e)
{
    richTextBoxPrintClass r = new richTextBoxPrintClass();
    r.richTextBox = richTextBox1;
    r.ShowPageSetupDlg();
}
//打印预览功能
private void btnPrintPreview_Click(object sender, EventArgs e)
{
    richTextBoxPrintClass r = new richTextBoxPrintClass();
    r.richTextBox = richTextBox1;
    r.ShowShowPagePriviewDlg();
}
//打印
private void btnPrint_Click(object sender, EventArgs e)
{
    richTextBoxPrintClass r = new richTextBoxPrintClass();
    r.richTextBox = richTextBox1;
    r.ShowPrintDlg();
}
*/
#endregion
//http://support.microsoft.com/kb/812425/zh-cn
namespace RichTextBoxCtrl
{
    public class richTextBoxPrintClass
    {
        public richTextBoxPrintClass()
        {
            InitializeComponent();
        }
        #region 打印功用

        //and the unit used by Win32 API calls (twips 1/1440 inch)
        private const double anInch = 14.4;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin;         //First character of range (0 for start of doc)
            public int cpMax;           //Last character of range (-1 for end of doc)
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;             //Actual DC to draw on
            public IntPtr hdcTarget;       //Target DC for determining text formatting
            public RECT rc;                //Region of the DC to draw to (in twips)
            public RECT rcPage;            //Region of the whole DC (page size) (in twips)
            public CHARRANGE chrg;         //Range of text to draw (see earlier declaration)
        }

        private const int WM_USER = 0x0400;
        private const int EM_FORMATRANGE = WM_USER + 57;

        [DllImport("USER32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        // Render the contents of the RichTextBox for printing
        //	Return the last character printed + 1 (printing start from this point for next page)
        public static int Print(RichTextBox richTextBox, int charFrom, int charTo, PrintPageEventArgs e)
        {
            //Calculate the area to render and print
            RECT rectToPrint;
            rectToPrint.Top = (int)(e.MarginBounds.Top * anInch);
            rectToPrint.Bottom = (int)(e.MarginBounds.Bottom * anInch);
            rectToPrint.Left = (int)(e.MarginBounds.Left * anInch);
            rectToPrint.Right = (int)(e.MarginBounds.Right * anInch);

            //Calculate the size of the page
            RECT rectPage;
            rectPage.Top = (int)(e.PageBounds.Top * anInch);
            rectPage.Bottom = (int)(e.PageBounds.Bottom * anInch);
            rectPage.Left = (int)(e.PageBounds.Left * anInch);
            rectPage.Right = (int)(e.PageBounds.Right * anInch);

            IntPtr hdc = e.Graphics.GetHdc();

            FORMATRANGE fmtRange;
            fmtRange.chrg.cpMax = charTo;				//Indicate character from to character to 
            fmtRange.chrg.cpMin = charFrom;
            fmtRange.hdc = hdc;                    //Use the same DC for measuring and rendering
            fmtRange.hdcTarget = hdc;              //Point at printer hDC
            fmtRange.rc = rectToPrint;             //Indicate the area on page to print
            fmtRange.rcPage = rectPage;            //Indicate size of page

            IntPtr res = IntPtr.Zero;

            IntPtr wparam = IntPtr.Zero;
            wparam = new IntPtr(1);

            //Get the pointer to the FORMATRANGE structure in memory
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, lparam, false);

            //Send the rendered data for printing 
            res = SendMessage(richTextBox.Handle, EM_FORMATRANGE, wparam, lparam);

            //Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam);

            //Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc);

            //Return last + 1 character printer
            return res.ToInt32();
        }

        #endregion


        #region 初始化
        public RichTextBox richTextBox;
        private PageSetupDialog pageSetupDialog1;
        private PrintDialog printDialog1;
        private PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;

        private void InitializeComponent()
        {
            richTextBox = new RichTextBox();
            pageSetupDialog1 = new PageSetupDialog();
            printDialog1 = new PrintDialog();
            printDocument1 = new PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();

            // 
            // pageSetupDialog1
            // 
            pageSetupDialog1.Document = printDocument1;
            // 
            // printDialog1
            // 
            printDialog1.Document = printDocument1;
            printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(printDocument1_BeginPrint);
            // 
            // printPreviewDialog1
            // 

            printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            // printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
        }


        private int checkPrint;
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            //checkPrint = richTextBoxPrintCtrl1.Print(checkPrint, richTextBoxPrintCtrl1.TextLength, e);
            checkPrint = richTextBoxPrintClass.Print(richTextBox, checkPrint, richTextBox.TextLength, e);

            // Check for more pages
            if (checkPrint < richTextBox.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }


        #endregion


        //页面设置功能
        public void ShowPageSetupDlg()
        {
            pageSetupDialog1.ShowDialog();
        }

        //打印预览功能
        public void ShowShowPagePriviewDlg()
        {
            printPreviewDialog1.ShowDialog();
        }

        //打印
        public void ShowPrintDlg()
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
    }
}
