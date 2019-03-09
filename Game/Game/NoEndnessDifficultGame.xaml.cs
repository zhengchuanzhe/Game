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
    public partial class NoEndnessDifficultGame : PhoneApplicationPage
    {
        int time=2;
        public NoEndnessDifficultGame()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        #region 计时
        private void timer_Tick(object sender, EventArgs e)
        {

            time = time - 1;

            this.MyTimeBox.Text = "剩余时间：" + Convert.ToString(time) + "s";

            if (time == 0)
            {
                time = 2;
                MyTimeBox.Text = "剩余时间：2s";
                this.NavigationService.Navigate(new Uri("/FailPage.xaml", UriKind.Relative));
            }

        }
        #endregion
    }
    
}