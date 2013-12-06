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
using ZingMp3.Data.ViewModel;
using ZingMp3.Model;
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
            //StaticData.HtmlString = await StaticMethod.GetHttpAsStringGZipAware("http://mp3.zing.vn/");
            //JsonData2 jsonData = new JsonData2();

            //jsonData.id = "ZWZ987CC";

            //jsonData.t = "song";

            //StaticData.requestData = StaticMethod.GenerateData(jsonData);
            //StaticData.signature = StaticMethod.Hash_hmac(StaticData.requestData);

            //mainPageViewModel.musicItemCollection = await CallAPI.GetHotContentTask();

            //StaticData.mainPageViewModel.LoadData();
            //StaticData._hotSongsViewModel = new HotSongsViewModel();
            await StaticData._hotSongsViewModel.LoadData();

            NavigationService.Navigate(new Uri("/PageGroups/MainGroup/MainPagePanorama.xaml", UriKind.Relative));
        }
    }
}