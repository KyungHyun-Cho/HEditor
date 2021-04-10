using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public partial class CustomTrackBar : UserControl
    {
        public CustomTrackBar()
        {
            InitializeComponent();
            trackBar1.BackColor = this.BackColor;
        }

        public float CurrentValue
        {
            get { return tmpValue; }
            set
            {
                //ZoomFactor = value;
                //10----------- 250-----------500            
                //1 value  10--250  max
                //2 value  250-500  max
                //3 value <10
                //4 value >500

                //(1)
                if (value >= 10)
                {
                    if (value < 100)
                    {
                        //(6)
                        if ((value * 2.5) > 500)
                        {
                            trackBar1.Value = 500;
                            label2.Text = "500%";
                        }
                        else
                        {
                            trackBar1.Value = (int)(value * 2.5);
                            label2.Text = value.ToString() + "%";
                        }
                    }
                }


                //(2)
                //(3)
                //////////////////////////////////
                //>`1--
                //////////////////////////////////////
                if (value > 250)
                {
                    if (value <= 500)
                    {
                        trackBar1.Value = (int)(value);
                        label2.Text = value.ToString() + "%";
                    }
                }

                //(4)

                //(5)
                if (value <= 10)
                {
                    trackBar1.Value = 10;//min value =10
                    label2.Text = "10%";
                }

                if (value > 500)
                {
                    trackBar1.Value = 500;//min value =10
                    label2.Text = "500%";
                }


            }
        }
        private int tmpValue = 100;

        //定义委托为
        public delegate void customTrackBar_Scroll(object sender, EventArgs e);
        //定义事件
        public event customTrackBar_Scroll ValueChanged;
        //当主窗体中没有 private void customTrackBar1_ValueChanged(object sender, EventArgs e) 引起错误
        // private void UpdataValue(object sender, EventArgs e)


        private void pictureBoxMinBtn_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxMinBtn.Image = pictureBoxMinBtn2.Image;// System.Windows.Forms.CustomTrackbar.Resource1.BtnMinus2;
        }

        private void pictureBoxMinBtn_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxMinBtn.Image = pictureBoxMinBtn1.Image;
        }

        private void pictureBoxMinBtn_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxMinBtn.Image = pictureBoxMinBtn3.Image;
            pictureBoxMinBtn.Focus();

            //-
            //1 10-----------250====== <trackBar1.Value<= ====500 	
            //-=25

            //2 10==== <trackBar1.Value<=  =======250-----------500
            //-=10 

            //3  trackBar1.Value<  ====10-----------250-----------500        
            //=10


            //1)
            if (trackBar1.Value > 250)
            {
                if (trackBar1.Value <= 500)
                {
                    trackBar1.Value -= 25;
                }
            }

            ////2)
            if (trackBar1.Value > 10)
            {
                if (trackBar1.Value <= 250)
                {
                    //3)
                    if (trackBar1.Value - 10 < 10)
                    {
                        trackBar1.Value = 10;
                    }
                    else
                    {
                        trackBar1.Value -= 10;
                    }

                }
            }

            label2.Text = trackBar1.Value.ToString() + "%";
            tmpValue = trackBar1.Value;
            ValueChanged(sender, e);
        }

        private void pictureBoxPlusBtn_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPlusBtn.Image = pictureBoxPlusBtn2.Image;
        }

        private void pictureBoxPlusBtn_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxPlusBtn.Image = pictureBoxPlusBtn1.Image;
        }

        private void pictureBoxPlusBtn_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxPlusBtn.Image = pictureBoxPlusBtn3.Image;
            pictureBoxPlusBtn.Focus();

            //++++

            //1 10-----------250======>>>> ====500 	
            //-=25

            //2 10====>>>>========250-----------500
            //-=10 

            //3 >>>> ====10-----------250-----------500        
            //=10


            //1)
            if (trackBar1.Value > 250)
            {
                if (trackBar1.Value <= 500)
                {
                    //3)
                    if ((trackBar1.Value + 25) > 500)
                    {
                        trackBar1.Value = 500;
                    }
                    else
                    {
                        trackBar1.Value += 25;
                    }
                }
            }

            ////2)
            if (trackBar1.Value >= 10)
            {
                if (trackBar1.Value <= 250)
                {
                    trackBar1.Value += 10;
                }
            }

            label2.Text = trackBar1.Value.ToString() + "%";
            tmpValue = trackBar1.Value;
            ValueChanged(sender, e);

        }
        private object objectSender;
        private EventArgs eventArgsE;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            objectSender = sender;
            eventArgsE = e;
            //取得当前值

            //1 10-----------250======<<<<>>>>====500 	
            //tmpValue = trackBar1.Value

            //2 10====<<<<>>>>=======250-----------500
            //  10====,,.,,,=========100
            //tmpValue = trackBar1.Value  / 25

            //3 <<<<>>>>===10-----------250-----------500        
            //tmpValue = 10 xxxx

            //4 10-----------250-----------500===<<<<>>>>
            //tmpValue=500  xxxx



            //1
            
                    tmpValue = trackBar1.Value;
            label2.Text = tmpValue.ToString() + "%";
            ValueChanged(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 250;
            tmpValue = 100;
            label2.Text = "100%";
            ValueChanged(sender, e);
        }
    }
}
