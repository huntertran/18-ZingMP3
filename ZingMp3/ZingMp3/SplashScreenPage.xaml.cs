using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ZingMp3.Data;
using ZingMp3.Resources;
using ZingMp3.Settings;
using ZingMp3.Utilities;

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
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    await LoadData();
                }
                catch (Exception exception)
                { }
            }
            else
            {
                IAsyncResult result = Guide.BeginShowMessageBox(
                    AppResources.SplashScreen_OnNavigatedTo_No_Network,
                    AppResources.SplashScreen_OnNavigatedTo_No_network_details,
                    new string[] { "wifi", "3G/4G-LTE" },
                    0,
                    MessageBoxIcon.Error,
                    null,
                    null
                    );
                result.AsyncWaitHandle.WaitOne();

                int? choice = Guide.EndShowMessageBox(result);
                if (choice.HasValue)
                {
                    if (choice.Value == 0)
                    {
                        ConnectionSettingsTask con = new ConnectionSettingsTask();
                        con.ConnectionSettingsType = ConnectionSettingsType.WiFi;
                        con.Show();
                    }
                    else
                    {
                        ConnectionSettingsTask con = new ConnectionSettingsTask();
                        con.ConnectionSettingsType = ConnectionSettingsType.Cellular;
                        con.Show();
                    }
                }
                else
                {
                    MessageBoxResult res = MessageBox.Show(AppResources.SplashScreen_OnNavigatedTo_OfflineModeQuestion, AppResources.SplashScreen_OnNavigatedTo_Offline_Mode,
                        MessageBoxButton.OKCancel);
                    if (res == MessageBoxResult.Cancel)
                    {
                        StaticMethod.Quit();
                    }
                    else if (res == MessageBoxResult.OK)
                    {
                        StaticData.isOffline = true;
                        //Navigate to MainPage
                        //NavigationService.Navigate(new Uri("/PageGroups/KaraokeGroup/OfflinePage.xaml", UriKind.Relative));
                    }
                }
            }
        }

        private async Task LoadData()
        {
            CountOpen();
            await CheckParameter();
            SetupUI();
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

        private void SetupPlaylist()
        {
            BackgroundAudioPlayer.Instance.PlayStateChanged += InstanceOnPlayStateChanged;
        }

        private void InstanceOnPlayStateChanged(object sender, EventArgs eventArgs)
        {
            if (BackgroundAudioPlayer.Instance.Track != null)
            {
                ApplicationSettings.SetSettingSafe("currentSong", BackgroundAudioPlayer.Instance.Track, true);
            }
        }

        private async Task CheckParameter()
        {
            string result = "";

            try
            {
                result = await StaticMethod.GetHttpAsString("https://sites.google.com/site/tuantranzingmp3/wp8");

                string[] temp = Regex.Split(result, "~~");

                string latestVersion = Regex.Split(temp[9], ":=")[1];

                StaticData.checkParameterData.latestVersion = latestVersion;
                StaticData.checkParameterData.enableSync = Regex.Split(temp[1], ":=")[1];
                StaticData.checkParameterData.wpapplink = Regex.Split(temp[3], ":=")[1];
                StaticData.checkParameterData.androidapplink = Regex.Split(temp[5], ":=")[1];
                StaticData.checkParameterData.iosapplink = Regex.Split(temp[7], ":=")[1];
                StaticData.checkParameterData.notetouser = Regex.Split(temp[11], ":=")[1];
                StaticData.checkParameterData.bloglink = Regex.Split(temp[13], ":=")[1];
                StaticData.checkParameterData.w8applink = Regex.Split(temp[15], ":=")[1];

                StaticData.checkParameterData.adMode = Regex.Split(temp[17], ":=")[1];

                StaticData.appVersion = System.Reflection.Assembly.GetExecutingAssembly().FullName.Split('=')[1].Split(',')[0];

                if (IsHaveNewerVersion(latestVersion, StaticData.appVersion))
                {
                    StaticData.EnableAppLink = true;
                }
            }
            catch
            { }
        }

        private bool IsHaveNewerVersion(string currentVersion, string appVersion)
        {
            var curVer = new Version(currentVersion);
            var appVer = new Version(appVersion);

            int re = curVer.CompareTo(appVer);

            if (re > 0)
                return true;
            return false;
        }

        private void CountOpen()
        {
            StaticData.openCount = ApplicationSettings.GetSetting<int>("openCount", 0);
            StaticData.openCount++;
            ApplicationSettings.SetSetting<int>("openCount", StaticData.openCount, true);
        }
    }
}