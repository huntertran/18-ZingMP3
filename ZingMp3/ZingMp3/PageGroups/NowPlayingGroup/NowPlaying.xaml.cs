using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ZingMp3.PageGroups.NowPlayingGroup
{
    public partial class NowPlaying : PhoneApplicationPage
    {
        public NowPlaying()
        {
            InitializeComponent();
        }

        private void SetupUI()
        {
            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                PlayButton.Visibility = Visibility.Collapsed;
                PauseButton.Visibility = Visibility.Visible;
            }
        }

        private void PlayButton_OnTap(object sender, GestureEventArgs e)
        {

        }

        private void PauseButton_OnTap(object sender, GestureEventArgs e)
        {

        }

        private void SkipPreButton_OnTap(object sender, GestureEventArgs e)
        {

        }

        private void SkipNext_OnTap(object sender, GestureEventArgs e)
        {

        }
    }
}