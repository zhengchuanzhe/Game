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
using Game;
namespace Game
{
    public partial class NoEndnessEasyGame : PhoneApplicationPage
    {

        double  time = 2; 
        Random rad = new Random();
        int sum;
        int pic1number;
        int pic2number;
        int pic3number;
        int picTrue;
        public NoEndnessEasyGame()
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
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        #region 图片改变
        private void chang()
        {
            pic1number = rad.Next(1, 8);
            pic2number = rad.Next(1, 8);
            //前两个为两个白色箭头
            if (pic1number < 5 && pic2number < 5)
            {
                pic3number = rad.Next(5, 8);
                switch (pic3number)
                {
                    case 5: picTrue = 2; break;
                    case 6: picTrue = 1; break;
                    case 7: picTrue = 4; break;
                    case 8: picTrue = 3; break;
                }

            }
            else
            {
                //前两个为两个红色箭头
                if (pic1number > 4 && pic2number > 4)
                {
                    picTrue = pic3number = rad.Next(1, 4);
                }
                else
                {
                    //前两个一个为白色一个为红色
                    pic3number = rad.Next(1, 8);
                    if (pic3number < 5)
                    {
                        if (pic1number < 5)
                        {
                            switch (pic2number)
                            {
                                case 5: picTrue = 2; break;
                                case 6: picTrue = 1; break;
                                case 7: picTrue = 4; break;
                                case 8: picTrue = 3; break;
                            }
                        }
                        else
                        {
                            switch (pic1number)
                            {
                                case 5: picTrue = 2; break;
                                case 6: picTrue = 1; break;
                                case 7: picTrue = 4; break;
                                case 8: picTrue = 3; break;
                            }
                        }
                    }
                    else
                    {
                        if (pic1number < 5)
                        {
                            picTrue = pic1number;
                        }
                        else
                        {
                            picTrue = pic2number;
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
                time = 2;
                MyTimeBox.Text = "剩余时间：2s";
                Code.Text = sum.ToString();
                chang();
            }
            else
            {
                this.NavigationService.Navigate(new Uri("/FailPage.xaml", UriKind.Relative));
                MessageBox.Show("得分:" + sum.ToString());
            }
        }

        #endregion


        #region 计时
        private void timer_Tick(object sender, EventArgs e)
        {

            time = time - 0.1;

            this.MyTimeBox.Text = "剩余时间：" + Convert.ToString(time) + "s";

            if (time == 0)
            {
                this.NavigationService.Navigate(new Uri("/FailPage.xaml", UriKind.Relative));
                time = 2;
            }

        }
        #endregion
    }
}