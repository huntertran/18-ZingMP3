using System.Windows.Input;
using Microsoft.Phone.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ZingMp3.Data;
using ZingMp3.Model;
using ZingMp3.Utilities;
using Microsoft.Phone.BackgroundAudio;

namespace ZingMp3.PageGroups.MainGroup
{
    public partial class MainPagePanorama : PhoneApplicationPage
    {

        public MainPagePanorama()
        {
            InitializeComponent();
            this.Loaded += MainPagePanorama_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetupFlow();
        }

        private void SetupFlow()
        {
            if (NavigationService.BackStack.Count() == 1)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                StaticMethod.Quit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        void MainPagePanorama_Loaded(object sender, RoutedEventArgs e)
        {
            hotSongsListBox.ItemsSource = StaticData._hotSongsViewModel.HotSongsCollection;
        }

        private async void MainPanorama_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainPanorama.SelectedIndex)
            {
                case -1:
                    break;
                case 0:
                    if (StaticData._hotSongsViewModel.HotSongsCollection.Count == 0)
                    {
                        await StaticData._hotSongsViewModel.LoadData();
                    }
                    hotSongsListBox.ItemsSource = StaticData._hotSongsViewModel.HotSongsCollection;
                    break;
                case 1:
                    //hot album
                    if (StaticData.HotAlbumsViewModel.HotAlbumsCollection.Count == 0)
                    {
                        await StaticData.HotAlbumsViewModel.LoadData();
                    }
                    HotAlbumListBox.ItemsSource = StaticData.HotAlbumsViewModel.HotAlbumsCollection;
                    break;
                case 2:
                    //hot video
                    if (StaticData.HotVideosViewModel.HotVideosCollection.Count == 0)
                    {
                        await StaticData.HotVideosViewModel.LoadData();
                    }
                    HotVideoListBox.ItemsSource = StaticData.HotVideosViewModel.HotVideosCollection;
                    break;
            }
        }

        private async void HotSongsListBox_OnRefreshRequested(object sender, EventArgs e)
        {
            await StaticData._hotSongsViewModel.LoadData();
            //hotSongsListBox.StopPullToRefreshLoading(true, true);
        }

        private async void HotAlbumListBox_OnRefreshRequested(object sender, EventArgs e)
        {
            await StaticData.HotAlbumsViewModel.LoadData();
            //HotAlbumListBox.StopPullToRefreshLoading(true, true);
        }

        private async void HotVideoListBox_OnRefreshRequested(object sender, EventArgs e)
        {
            await StaticData.HotVideosViewModel.LoadData();
            //HotVideoListBox.StopPullToRefreshLoading(true, true);
        }

        private void HotSongGrid_OnTap(object sender, GestureEventArgs e)
        {
            StaticData._hotSongsViewModel.SetPlayingIndex(hotSongsListBox.SelectedIndex);

            MusicItem selectedSong = ((Grid) sender).Tag as MusicItem;
            AudioTrack newAudioTrack = new AudioTrack(new Uri(selectedSong.LinkPlay320, UriKind.Absolute),
                selectedSong.Title, selectedSong.Artist,
                "", new Uri(selectedSong.ArtistAvatar, UriKind.Absolute));
            BackgroundAudioPlayer.Instance.Track = newAudioTrack;
            BackgroundAudioPlayer.Instance.Play();

            //if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            //{
            //    BackgroundAudioPlayer.Instance.Pause();
            //}
            //else
            //{
            //    BackgroundAudioPlayer.Instance.Play();
            //}
        }

        private void ApplicationBar_StateChanged(object sender, Microsoft.Phone.Shell.ApplicationBarStateChangedEventArgs e)
        {
            if (e.IsMenuVisible)
            {
                ApplicationBar.Opacity = 0.7;
            }
            else
            {
                ApplicationBar.Opacity = 1;
            }
        }

        private void NowPlayingApplicationBarIconButton_OnClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageGroups/NowPlayingGroup/NowPlaying.xaml", UriKind.Relative));
        }
    }
}