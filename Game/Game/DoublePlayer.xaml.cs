using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Game;
using Microsoft.Xna.Framework.Input.Touch;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game
{
    public partial class DoublePlayer : PhoneApplicationPage
    {
        int time;
        Random rad ;
        int sum1;
        int sum2;
        int pic1number;
        int pic2number;
        int pic3number;
        int pic4number;
        int pic5number;
        int pic6number;
        int pic1True;
        int pic2True;
        bool isFirst;


        public DoublePlayer()
        {
            InitializeComponent();
            time = 60;
            rad = new Random ();
            sum1 = 0;
            sum2 = 0;
            pic1number = 0;
            pic2number = 0;
            pic3number = 0;
            pic4number = 0;
            pic5number = 0;
            pic6number = 0;
            pic1True = 0;
            pic2True = 0;
            chang();
            isFirst = true;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            blackImage.Source = new BitmapImage(new Uri("/Assets/UDLR/Black.png", UriKind.Relative));
        }

        #region 计时器
        void timer_Tick(object sender, EventArgs e)
        {
            if (time ==0)
            {
                if (sum1 >sum2)
                {
                    MessageBox.Show("红方胜");
                }
                if (sum1 <sum2 )
                {
                    MessageBox.Show("蓝方胜");
                }
                if (sum1 ==sum2 )
                {
                    MessageBox.Show("平局");
                }
                this.NavigationService.Navigate(new Uri("", UriKind.Relative));
            }
            time = time - 1;
            this.myTextBox1.Text = Convert.ToString(time) + "s";
            this.myTextBox2.Text = Convert.ToString(time) + "s";
        }
        #endregion

        #region 图片改变
        private void chang()
        {

            //下方玩家图片变换
            pic1number = rad.Next(1, 8);
            pic2number = rad.Next(1, 8);
            //前两个为两个白色箭头
            if (pic1number < 5 && pic2number < 5)
            {
                pic3number = rad.Next(5, 8);
                switch (pic3number)
                {
                    case 5: pic1True = 2; break;
                    case 6: pic1True = 1; break;
                    case 7: pic1True = 4; break;
                    case 8: pic1True = 3; break;
                }

            }
            else
            {
                //前两个为两个红色箭头
                if (pic1number > 4 && pic2number > 4)
                {
                    pic1True = pic3number = rad.Next(1, 4);
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
                                case 5: pic1True = 2; break;
                                case 6: pic1True = 1; break;
                                case 7: pic1True = 4; break;
                                case 8: pic1True = 3; break;
                            }
                        }
                        else
                        {
                            switch (pic1number)
                            {
                                case 5: pic1True = 2; break;
                                case 6: pic1True = 1; break;
                                case 7: pic1True = 4; break;
                                case 8: pic1True = 3; break;
                            }
                        }
                    }
                    else
                    {
                        if (pic1number < 5)
                        {
                            pic1True = pic1number;
                        }
                        else
                        {
                            pic1True = pic2number;
                        }
                    }
                }
            }

            string file1 = "Assets\\UDLR\\" + pic1number.ToString() + ".png";
            string file2 = "Assets\\UDLR\\" + pic2number.ToString() + ".png";
            string file3 = "Assets\\UDLR\\" + pic3number.ToString() + ".png";
            ImageDown1.Source = new BitmapImage(new Uri(file1, UriKind.Relative));
            ImageDown2.Source = new BitmapImage(new Uri(file2, UriKind.Relative));
            ImageDown3.Source = new BitmapImage(new Uri(file3, UriKind.Relative));




            //上方玩家图片变换

            pic4number = rad.Next(1, 8);
            pic5number = rad.Next(1, 8);

            if (pic4number < 5 && pic5number < 5)
            {
                pic6number = rad.Next(5, 8);
                switch (pic6number)
                {
                    case 5: pic2True = 2; break;
                    case 6: pic2True = 1; break;
                    case 7: pic2True = 4; break;
                    case 8: pic2True = 3; break;
                }

            }
            else
            {
                //前两个为两个红色箭头
                if (pic4number > 4 && pic5number > 4)
                {
                    pic2True = pic6number = rad.Next(1, 4);
                }
                else
                {
                    //前两个一个为白色一个为红色
                    pic6number = rad.Next(1, 8);
                    if (pic6number < 5)
                    {
                        if (pic4number < 5)
                        {
                            switch (pic5number)
                            {
                                case 5: pic2True = 2; break;
                                case 6: pic2True = 1; break;
                                case 7: pic2True = 4; break;
                                case 8: pic2True = 3; break;
                            }
                        }
                        else
                        {
                            switch (pic4number)
                            {
                                case 5: pic2True = 2; break;
                                case 6: pic2True = 1; break;
                                case 7: pic2True = 4; break;
                                case 8: pic2True = 3; break;
                            }
                        }
                    }
                    else
                    {
                        if (pic4number < 5)
                        {
                            pic2True = pic4number;
                        }
                        else
                        {
                            pic2True = pic5number;
                        }
                    }
                }
            }
            string file4 = "Assets\\UDLR\\" + pic4number.ToString() + ".png";
            string file5 = "Assets\\UDLR\\" + pic5number.ToString() + ".png";
            string file6 = "Assets\\UDLR\\" + pic6number.ToString() + ".png";
            ImageUp1.Source = new BitmapImage(new Uri(file4, UriKind.Relative));
            ImageUp2.Source = new BitmapImage(new Uri(file5, UriKind.Relative));
            ImageUp3.Source = new BitmapImage(new Uri(file6, UriKind.Relative));

        }
        #endregion




        #region 记录滑屏
        double y1Distance = 0.0;
        double x1Distance = 0.0;
        double y2Distance = 0.0;
        double x2Distance = 0.0;
        private void OnManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {

            if (e.ManipulationOrigin.Y >= 400)
            {
                x1Distance = e.CumulativeManipulation.Translation.X;
                y1Distance = e.CumulativeManipulation.Translation.Y;
                base.OnManipulationDelta(e);
            }
            if (e.ManipulationOrigin.Y < 400)
            {
                x2Distance = e.CumulativeManipulation.Translation.X;
                y2Distance = e.CumulativeManipulation.Translation.Y;
                base.OnManipulationDelta(e);

            }
        }

        private void OnManipulationComPpleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            if (!isFirst )
            {
                isFirst = true;
                return;
            }
            isFirst = false;
            if (Math.Abs ( x1Distance )> 10||Math .Abs ( y1Distance) >10)
            {
                int userNum = new DirectionJudge().Direction(x1Distance, y1Distance);
                if (pic1True == userNum)
                {
                    sum1 += 10;
                    DownCode.Text = sum1.ToString();
                    chang();
                }
                else
                {
                    sum2 += 10;
                    UpCode.Text = sum2.ToString();
                    chang();
                }
            }
            if (Math .Abs ( x2Distance) >10||Math .Abs ( y2Distance)>10)
            {
                int userNum = new DirectionJudge().Direction(x2Distance, y2Distance);
                if (pic2True == userNum)
                {
                    sum2 += 10;
                    UpCode.Text = sum2.ToString();
                    chang();
                }
                else
                {
                    sum1 += 10;
                    DownCode.Text = sum1.ToString();
                    chang();
                }
            }
            x1Distance = 0;
            y1Distance = 0;
            x2Distance = 0;
            y2Distance = 0;
        }

        #endregion


    }
}