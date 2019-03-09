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
    public partial class DoubleGame : PhoneApplicationPage
    {
        int time = 60;
        Random rad = new Random();
        int sum;
        int leftPic1Number;
        int leftPic2Number;
        int leftPic3Number;
        int leftPicTrue;
        int rightPic1Number;
        int rightPic2Number;
        int rightPic3Number;
        int rightPicTrue;
        int isLeft;
        int isRight;
        DispatcherTimer timer;
        public DoubleGame()
        {
            InitializeComponent();
           ImageLine.Source = new BitmapImage(new Uri("Assets/UDLR/白色分割线.png", UriKind.Relative));
            sum = 0;
            leftPic1Number = 0;
            leftPic2Number = 0;
            leftPic3Number = 0;
            leftPicTrue = 0;
            rightPic1Number = 0;
            rightPic2Number = 0;
            rightPic3Number = 0;
            rightPicTrue = 0;
            isLeft = 0;
            isRight = 0;
            changeRight();
            changLeft();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            //设置可识别的手势，必须设置才能被启用
            //TouchPanel.EnabledGestures = GestureType.Hold | GestureType.Tap | GestureType.DoubleTap | GestureType.Flick | GestureType.Pinch;
        }

        #region 图片改变
        private void changLeft()
        {
            leftPic1Number = rad.Next(1, 8);
            if (leftPic1Number < 5)
            {
                leftPicTrue = leftPic1Number;
                leftPic2Number = rad.Next(5, 8);
                leftPic3Number = rad.Next(5, 8);
            }
            else
            {
                leftPic2Number = rad.Next(1, 8);
                if (leftPic2Number < 5)
                {
                    leftPicTrue = leftPic2Number;
                    leftPic3Number = rad.Next(5, 8);
                }
                else
                {
                    leftPicTrue = leftPic3Number = rad.Next(1, 4);
                }
            }
            string file1 = "Assets\\UDLR\\" + leftPic1Number.ToString() + ".png";
            string file2 = "Assets\\UDLR\\" + leftPic2Number.ToString() + ".png";
            string file3 = "Assets\\UDLR\\" + leftPic3Number.ToString() + ".png";
            ImageLeft1.Source = new BitmapImage(new Uri(file1, UriKind.Relative));
            ImageLeft2.Source = new BitmapImage(new Uri(file2, UriKind.Relative));
            ImageLeft3.Source = new BitmapImage(new Uri(file3, UriKind.Relative));
        }

        private void changeRight()
        {

            rightPic1Number = rad.Next(1, 8);
            if (rightPic1Number > 4)
            {
                rightPicTrue = rightPic1Number;
                rightPic2Number = rad.Next(1, 4);
                rightPic3Number = rad.Next(1, 4);
            }
            else
            {
                rightPic2Number = rad.Next(1, 8);
                if (rightPic2Number >4)
                {
                    rightPicTrue = rightPic2Number;
                    rightPic3Number = rad.Next(1, 4);
                }
                else
                {
                    rightPicTrue = rightPic3Number = rad.Next(5, 8);
                }
            }
            switch (rightPicTrue)
            {
                case 5: rightPicTrue = 2; break;
                case 6: rightPicTrue = 1; break;
                case 7: rightPicTrue = 4; break;
                case 8: rightPicTrue = 3; break;
            }
            string file1 = "Assets\\UDLR\\" + rightPic1Number.ToString() + ".png";
            string file2 = "Assets\\UDLR\\" + rightPic2Number.ToString() + ".png";
            string file3 = "Assets\\UDLR\\" + rightPic3Number.ToString() + ".png";
            ImageRight1.Source = new BitmapImage(new Uri(file1, UriKind.Relative));
            ImageRight2.Source = new BitmapImage(new Uri(file2, UriKind.Relative));
            ImageRight3.Source = new BitmapImage(new Uri(file3, UriKind.Relative));
        }
        #endregion


        DistanceModle leftDistance = new DistanceModle();
        DistanceModle rightDistance = new DistanceModle();

       // private void OnStrated(object sender, ManipulationStartedEventArgs e)
       // {

      //  }

        bool isRightFirst = true;
        bool isLeftFirst = true;
        private void OnDelta(object sender, ManipulationDeltaEventArgs e)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            //计算每个点的滑动距离
            string s=string .Empty ;
            foreach (var item in touchCollection)
            {
                if (item.Position.Y > 400 && isRightFirst)
                {
                    rightDistance.XStrate = item.Position.X;
                    rightDistance.YStrate = item.Position.Y;
                    rightDistance.Id = item.Id;
                    isRightFirst = false;
                }
                if (item.Position.Y < 400 && isLeftFirst )
                {
                    leftDistance.XStrate = item.Position.X;
                    leftDistance.YStrate = item.Position.Y;
                    leftDistance.Id = item.Id;
                    isLeftFirst = false;
                }
                s=s+ item.Position.ToString();
                if (item.Position.Y >400)
                {
                
                    rightDistance.XEnd = item.Position.X;
                    rightDistance.YEnd = item.Position.Y;
                }
                else
                {
                    leftDistance.XEnd = item.Position.X;
                    leftDistance.YEnd = item.Position.Y;
                }
            }
            Code .Text =s ;
        }

        private void OnCompleted(object sender, ManipulationCompletedEventArgs e)
        {
           
          
            if (Math.Abs(rightDistance.XEnd-rightDistance .XStrate  )> 8 || Math.Abs(rightDistance.YEnd-rightDistance .YStrate  ) > 8)
            {
                if (rightPicTrue == new DirectionJudge().DirectionLevel(rightDistance.XEnd-rightDistance .XStrate , rightDistance.YEnd-rightDistance .YStrate ))
                {
                    isRight = 1;
                }
                else
                {
                    if (rightDistance.Id != 0)
                    {
                        isRight = -1;
                    }
                }
               
            }
            if (Math.Abs(leftDistance.XEnd-leftDistance .XStrate ) > 8 || Math.Abs(leftDistance.YEnd-leftDistance .YStrate ) > 8)
            {
                if (leftPicTrue == new DirectionJudge().DirectionLevel(leftDistance.XEnd - leftDistance.XStrate, leftDistance.YEnd - leftDistance.YStrate))
                {
                    isLeft = 1;
                }
                else
                {
                    if (leftDistance.Id != 0)
                    {
                        isLeft = -1;
                    }
                }
            }
            //滑动成功
            if (isRight == 1 && isLeft == 1)
            {
                sum += 10;
                Code.Text = sum.ToString();
                changeRight();
                changLeft();
                initialise(); 
                
            }
            if (isRight == -1 || isLeft == -1)
            {
                leftDistance.Id = 0;
                rightDistance.Id = 0;
                isLeft = 0;
                isRight = 0;
                MessageBox.Show(sum.ToString());
                sum = 0;
                Code.Text = "0";
                this.NavigationService.Navigate(new Uri("/FailPage.xaml", UriKind.Relative));
                initialise(); 

            }
            
        }

        #region  数据初始化操作
        private void initialise()
        {
            leftDistance.Id = 0;
            leftDistance.XEnd = 0;
            leftDistance.XStrate = 0;
            leftDistance.YStrate = 0;
            leftDistance.YEnd = 0;
            rightDistance.Id = 0;
            rightDistance.YStrate = 0;
            rightDistance.XStrate = 0;
            rightDistance.XEnd = 0;
            rightDistance.YEnd = 0;
            isLeft = 0;
            isRight = 0;
            isRightFirst = true;
            isLeftFirst = true;
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
                MessageBox.Show(sum.ToString());
                sum = 0;
                Code.Text = "0";
                this.NavigationService.Navigate(new Uri("/FailPage.xaml", UriKind.Relative));
                timer.Stop();
            }

        }
        #endregion
    }
}