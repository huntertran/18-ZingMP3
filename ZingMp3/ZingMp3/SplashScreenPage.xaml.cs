using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using ZingMp3.Utilities;
using ZingMp3.Data;

namespace ZingMp3
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            StaticData.HtmlString = await StaticMethod.GetHttpAsStringGZipAware("http://mp3.zing.vn/");
            NavigationService.Navigate(new Uri("/PageGroups/MainGroup/MainPage.xaml", UriKind.Relative));
        }
    }
}