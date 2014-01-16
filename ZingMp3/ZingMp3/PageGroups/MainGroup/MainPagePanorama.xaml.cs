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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using ZingMp3.Data;
using ZingMp3.Utilities;

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
            //hotSongsListBox.ItemsSource = null;
            //hotSongsListBox.ItemsSource = StaticData._hotSongsViewModel.HotSongsCollection;
            hotSongsListBox.StopPullToRefreshLoading(true, true);
        }

        private async void HotAlbumListBox_OnRefreshRequested(object sender, EventArgs e)
        {
            await StaticData.HotAlbumsViewModel.LoadData();
            HotAlbumListBox.StopPullToRefreshLoading(true, true);
        }

        private async void HotVideoListBox_OnRefreshRequested(object sender, EventArgs e)
        {
            await StaticData.HotVideosViewModel.LoadData();
            HotVideoListBox.StopPullToRefreshLoading(true, true);
        }
    }
}