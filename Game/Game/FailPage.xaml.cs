using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Game
{
    public partial class FailPage : PhoneApplicationPage
    {
        public FailPage()
        {
            InitializeComponent(); try
            {
                GradeBox.Text = NavigationContext.QueryString["Code"];
            }
            catch (Exception)
            {
            }
        }

        private void RefreshGame(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ReturnToMainPage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MenuPage.xaml", UriKind.Relative));
        }
    }
}