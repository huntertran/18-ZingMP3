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
            //LayoutRoot.DataContext = 
            hotSongsListBox.ItemsSource = StaticData._hotSongsViewModel.HotSongsCollection;
        }
    }
}