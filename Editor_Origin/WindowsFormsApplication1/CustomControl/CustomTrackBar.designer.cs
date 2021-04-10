namespace System.Windows.Forms
{
    partial class CustomTrackBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomTrackBar));
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxPlusBtn = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinBtn = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlusBtn3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlusBtn2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlusBtn1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinBtn3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinBtn2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinBtn1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "100%";
            this.toolTip1.SetToolTip(this.label2, "缩放级别");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.LargeChange = 25;
            this.trackBar1.Location = new System.Drawing.Point(55, 0);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(100, 17);
            this.trackBar1.SmallChange = 25;
            this.trackBar1.TabIndex = 18;
            this.trackBar1.TickFrequency = 25;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.trackBar1, "缩放");
            this.trackBar1.Value = 250;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBoxPlusBtn
            // 
            this.pictureBoxPlusBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlusBtn.Image")));
            this.pictureBoxPlusBtn.Location = new System.Drawing.Point(158, 1);
            this.pictureBoxPlusBtn.Name = "pictureBoxPlusBtn";
            this.pictureBoxPlusBtn.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPlusBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPlusBtn.TabIndex = 20;
            this.pictureBoxPlusBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxPlusBtn, "放大");
            this.pictureBoxPlusBtn.MouseLeave += new System.EventHandler(this.pictureBoxPlusBtn_MouseLeave);
            this.pictureBoxPlusBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPlusBtn_MouseMove);
            this.pictureBoxPlusBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPlusBtn_MouseDown);
            // 
            // pictureBoxMinBtn
            // 
            this.pictureBoxMinBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxMinBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinBtn.Image")));
            this.pictureBoxMinBtn.Location = new System.Drawing.Point(36, 1);
            this.pictureBoxMinBtn.Name = "pictureBoxMinBtn";
            this.pictureBoxMinBtn.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxMinBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMinBtn.TabIndex = 19;
            this.pictureBoxMinBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxMinBtn, "缩小");
            this.pictureBoxMinBtn.MouseLeave += new System.EventHandler(this.pictureBoxMinBtn_MouseLeave);
            this.pictureBoxMinBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMinBtn_MouseMove);
            this.pictureBoxMinBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMinBtn_MouseDown);
            // 
            // pictureBoxPlusBtn3
            // 
            this.pictureBoxPlusBtn3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlusBtn3.Image")));
            this.pictureBoxPlusBtn3.Location = new System.Drawing.Point(139, 102);
            this.pictureBoxPlusBtn3.Name = "pictureBoxPlusBtn3";
            this.pictureBoxPlusBtn3.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPlusBtn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPlusBtn3.TabIndex = 28;
            this.pictureBoxPlusBtn3.TabStop = false;
            this.pictureBoxPlusBtn3.Visible = false;
            // 
            // pictureBoxPlusBtn2
            // 
            this.pictureBoxPlusBtn2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlusBtn2.Image")));
            this.pictureBoxPlusBtn2.Location = new System.Drawing.Point(139, 80);
            this.pictureBoxPlusBtn2.Name = "pictureBoxPlusBtn2";
            this.pictureBoxPlusBtn2.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPlusBtn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPlusBtn2.TabIndex = 27;
            this.pictureBoxPlusBtn2.TabStop = false;
            this.pictureBoxPlusBtn2.Visible = false;
            // 
            // pictureBoxPlusBtn1
            // 
            this.pictureBoxPlusBtn1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlusBtn1.Image")));
            this.pictureBoxPlusBtn1.Location = new System.Drawing.Point(139, 58);
            this.pictureBoxPlusBtn1.Name = "pictureBoxPlusBtn1";
            this.pictureBoxPlusBtn1.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPlusBtn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPlusBtn1.TabIndex = 26;
            this.pictureBoxPlusBtn1.TabStop = false;
            this.pictureBoxPlusBtn1.Visible = false;
            // 
            // pictureBoxMinBtn3
            // 
            this.pictureBoxMinBtn3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinBtn3.Image")));
            this.pictureBoxMinBtn3.Location = new System.Drawing.Point(5, 102);
            this.pictureBoxMinBtn3.Name = "pictureBoxMinBtn3";
            this.pictureBoxMinBtn3.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxMinBtn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMinBtn3.TabIndex = 25;
            this.pictureBoxMinBtn3.TabStop = false;
            this.pictureBoxMinBtn3.Visible = false;
            // 
            // pictureBoxMinBtn2
            // 
            this.pictureBoxMinBtn2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinBtn2.Image")));
            this.pictureBoxMinBtn2.Location = new System.Drawing.Point(5, 80);
            this.pictureBoxMinBtn2.Name = "pictureBoxMinBtn2";
            this.pictureBoxMinBtn2.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxMinBtn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMinBtn2.TabIndex = 24;
            this.pictureBoxMinBtn2.TabStop = false;
            this.pictureBoxMinBtn2.Visible = false;
            // 
            // pictureBoxMinBtn1
            // 
            this.pictureBoxMinBtn1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinBtn1.Image")));
            this.pictureBoxMinBtn1.Location = new System.Drawing.Point(5, 58);
            this.pictureBoxMinBtn1.Name = "pictureBoxMinBtn1";
            this.pictureBoxMinBtn1.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxMinBtn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMinBtn1.TabIndex = 23;
            this.pictureBoxMinBtn1.TabStop = false;
            this.pictureBoxMinBtn1.Visible = false;
            // 
            // CustomTrackBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pictureBoxPlusBtn3);
            this.Controls.Add(this.pictureBoxPlusBtn2);
            this.Controls.Add(this.pictureBoxPlusBtn1);
            this.Controls.Add(this.pictureBoxMinBtn3);
            this.Controls.Add(this.pictureBoxMinBtn2);
            this.Controls.Add(this.pictureBoxMinBtn1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxPlusBtn);
            this.Controls.Add(this.pictureBoxMinBtn);
            this.Controls.Add(this.trackBar1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CustomTrackBar";
            this.Size = new System.Drawing.Size(179, 18);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlusBtn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinBtn1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxPlusBtn;
        private System.Windows.Forms.PictureBox pictureBoxMinBtn;
        public System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private PictureBox pictureBoxMinBtn1;
        private PictureBox pictureBoxMinBtn2;
        private PictureBox pictureBoxMinBtn3;
        private PictureBox pictureBoxPlusBtn3;
        private PictureBox pictureBoxPlusBtn2;
        private PictureBox pictureBoxPlusBtn1;
    }
}
