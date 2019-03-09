using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using Microsoft.Phone;
using Game;
namespace Game
{
    public partial class TimeEasyGame : PhoneApplicationPage
    {

        int time = 60; 
        Random rad = new Random();
        int sum;
        int pic1number;
        int pic2number;
        int pic3number;
        int picTrue;
        public TimeEasyGame()
        {
            InitializeComponent();
            Code.Text = "0";
            sum = 0;
            pic1number = 0;
            pic2number = 0;
            pic3number = 0;
            picTrue = 0;
            chang();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        #region 图片改变
        private void chang()
        {
            pic1number = rad.Next(1, 16);
            pic2number = rad.Next(1, 16);
            //前两个为两个白色箭头
            if (pic1number%8 < 5&&pic1number %8>0 && pic2number%8 < 5&&pic2number %8>0)
            {
                int n=rad .Next (1,2);
                if (n == 1)
                {
                    pic3number = rad.Next(5,8);
                }
                else
                {
                    pic3number = rad.Next(13,16);
                }
                switch (pic3number%8)
                {
                    case 5: picTrue = 2; break;
                    case 6: picTrue = 1; break;
                    case 7: picTrue = 4; break;
                    case 0: picTrue = 3; break;
                }

            }
            else
            {
                //前两个为两个红色
                if ((pic1number%8 > 4||pic1number %8==0) && (pic2number%8 > 4||pic2number %8==0))
                {
                    int n=rad .Next (1,2);
                    if (n == 1)
                    {
                        picTrue = pic3number = rad.Next(1, 4);
                    }
                    else
                    {
                        pic3number = rad.Next(9,12 );
                        picTrue = pic3number -8;
                    }
                }
                else
                {
                    //前两个一个为白色一个为红色
                    pic3number = rad.Next(1, 16);
                    if (pic3number%8 < 5&&pic3number %8>0)
                    {
                        if (pic1number%8 < 5&&pic1number %8>0)
                        {
                            switch (pic2number%8)
                            {
                                case 5: picTrue = 2; break;
                                case 6: picTrue = 1; break;
                                case 7: picTrue = 4; break;
                                case 0: picTrue = 3; break;
                            }
                        }
                        else
                        {
                            switch (pic1number%8)
                            {
                                case 5: picTrue = 2; break;
                                case 6: picTrue = 1; break;
                                case 7: picTrue = 4; break;
                                case 0: picTrue = 3; break;
                            }
                        }
                    }
                    else
                    {
                        if (pic1number%8 < 5)
                        {
                            picTrue = pic1number%8;
                        }
                        else
                        {
                            picTrue = pic2number%8;
                        }
                    }
                }
            }

            //if (pic1number <5)
            //{
            //    picTrue = pic1number;
            //    picFalse1 = pic2number = rad.Next(5, 8);
            //    picFalse2 = pic3number = rad.Next(5, 8);

            //}
            //else
            //{
            //    picFalse1 = pic1number;
            //    pic2number = rad.Next(1, 8);
            //    if (pic2number <5)
            //    {
            //        picTrue = pic2number;
            //        picFalse2 = pic3number = rad.Next(5, 8);
            //    }
            //    else
            //    {
            //        picFalse1 = pic1number;
            //        picFalse2 = pic2number;
            //       picTrue = pic3number = rad.Next(1, 4);
            //    }
            //}
            string file1 = "Assets\\UDLR\\" + pic1number.ToString() + ".png";
            string file2 = "Assets\\UDLR\\" + pic2number.ToString() + ".png";
            string file3 = "Assets\\UDLR\\" + pic3number.ToString() + ".png";
            Image1.Source = new BitmapImage(new Uri(file1, UriKind.Relative));
            Iamge2.Source = new BitmapImage(new Uri(file2, UriKind.Relative));
            Iamge3.Source = new BitmapImage(new Uri(file3, UriKind.Relative));
        }
        #endregion


        #region 记录滑屏
        double yDistance = 0.0;
        double xDistance = 0.0;
        private void OnManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {

            xDistance = e.CumulativeManipulation.Translation.X;
            yDistance = e.CumulativeManipulation.Translation.Y;
            base.OnManipulationDelta(e);
        }

        private void OnManipulationComPpleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            int userNum = new DirectionJudge().Direction(xDistance, yDistance);
            if (picTrue == userNum)
            {
                sum += 10;
                Code.Text = sum.ToString();
                chang();
            }
            else
            {
                //VibrateController.Default.Start(TimeSpan.FromSeconds(1));
                MessageBox.Show("得分："+sum.ToString ());
                chang();
            }
        }

        #endregion


        #region 计时
        private void timer_Tick(object sender, EventArgs e)
        {

            time = time - 1;

            this.MyTimeBox.Text = "剩余时间：" + Convert.ToString(time) + "s";

            if (time == 0)
            {
                time = 60;
                MyTimeBox.Text = "剩余时间：60s";
                this.NavigationService.Navigate(new Uri("/FailPage.xaml?Code="+sum.ToString (), UriKind.Relative));
            }

        }
        #endregion
    }
}