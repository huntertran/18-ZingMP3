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
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using ZingMp3.Data.ViewModel;
using ZingMp3.Model;
using ZingMp3.Resources;
using ZingMp3.Settings;
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

        private void SetupUI()
        {
            if (StaticData.EnableAppLink)
            {
                if (MessageBox.Show(AppResources.SplashScreen_SetupUI_New_version + StaticData.checkParameterData.latestVersion, AppResources.SplashScreen_SetupUI_Great_news, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    WebBrowserTask webBrowserTask = new WebBrowserTask();
                    webBrowserTask.Uri = new Uri(StaticData.checkParameterData.wpapplink);
                    webBrowserTask.Show();
                }
            }

            if (StaticData.openCount % 5 == 0 && ApplicationSettings.GetSetting<bool>("hasReview", false) == false)
            {
                if (MessageBox.Show(AppResources.SplashScreen_SetupUI_RateDetails, AppResources.SplashScreen_SetupUI_Rate,
                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    MarketplaceReviewTask marketPlace = new MarketplaceReviewTask();
                    marketPlace.Show();
                    ApplicationSettings.SetSetting<bool>("hasReview", true, true);
                    GoogleAnalytics.EasyTracker.GetTracker().SendSocial("MarketPlace", "rate", "MarketPlace");
                }
                else
                {
                    if (MessageBox.Show(AppResources.SplashScreen_SetupUI_FeedbackDetails, AppResources.SplashScreen_SetupUI_Feedback,
                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        EmailComposeTask email = new EmailComposeTask();
                        email.To = "cuoilennaocacban2@hotmail.com";
                        email.Subject = AppResources.SplashScreen_SetupUI__EmailHeader;
                        email.Body = AppResources.SplashScreen_SetupUI_EmailBody;
                        email.Show();

                        //ApplicationSettings.SetSetting<bool>("hasReview", true, true);
                    }
                    else
                    {
                        MessageBox.Show(AppResources.SplashScreen_SetupUI_FeedbackRemind);

                        //No, they didn't
                        //ApplicationSettings.SetSetting<bool>("hasReview", true, true);
                    }
                }
            }
        }

    }
}