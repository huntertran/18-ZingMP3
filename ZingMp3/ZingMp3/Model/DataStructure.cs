using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZingMp3.Annotations;
using ZingMp3.Model;

namespace ZingMp3.Model
{
    public class ArtistDetail
    {
        public string ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistAvatar { get; set; }
    }

    public class GenreDetail
    {
        public string GenreID { get; set; }
        public string GenreName { get; set; }
    }

    public class BaseItem : INotifyPropertyChanged
    {
        private string _ID;
        private string _Title;
        private string _Artist;
        private List<ArtistDetail> _ArtistDetail;
        private string _Composer;
        private string _Genre;
        private List<GenreDetail> _GenreDetail;
        private object _OwnerAcc;
        private string _CreatedDate;
        private int _TotalListen;
        private int _Hit;
        private int _Official;

        public string ID
        {
            get { return _ID; }
            set
            {
                if (value == _ID) return;
                _ID = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (value == _Title) return;
                _Title = value;
                OnPropertyChanged();
            }
        }

        public string Artist
        {
            get { return _Artist; }
            set
            {
                if (value == _Artist) return;
                _Artist = value;
                OnPropertyChanged();
            }
        }

        public List<ArtistDetail> ArtistDetail
        {
            get { return _ArtistDetail; }
            set
            {
                if (Equals(value, _ArtistDetail)) return;
                _ArtistDetail = value;
                OnPropertyChanged();
            }
        }

        public string Composer
        {
            get { return _Composer; }
            set
            {
                if (value == _Composer) return;
                _Composer = value;
                OnPropertyChanged();
            }
        }

        public string Genre
        {
            get { return _Genre; }
            set
            {
                if (value == _Genre) return;
                _Genre = value;
                OnPropertyChanged();
            }
        }

        public List<GenreDetail> GenreDetail
        {
            get { return _GenreDetail; }
            set
            {
                if (Equals(value, _GenreDetail)) return;
                _GenreDetail = value;
                OnPropertyChanged();
            }
        }

        public object OwnerAcc
        {
            get { return _OwnerAcc; }
            set
            {
                if (Equals(value, _OwnerAcc)) return;
                _OwnerAcc = value;
                OnPropertyChanged();
            }
        }

        public string CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                if (value == _CreatedDate) return;
                _CreatedDate = value;
                OnPropertyChanged();
            }
        }

        public int TotalListen
        {
            get { return _TotalListen; }
            set
            {
                if (value == _TotalListen) return;
                _TotalListen = value;
                OnPropertyChanged();
            }
        }

        public int Hit
        {
            get { return _Hit; }
            set
            {
                if (value == _Hit) return;
                _Hit = value;
                OnPropertyChanged();
            }
        }

        public int Official
        {
            get { return _Official; }
            set
            {
                if (value == _Official) return;
                _Official = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MusicItem : BaseItem
    {
        private string _ArtistAvatar;
        private string _MobilePath;
        private string _LinkPlay24;
        private string _LinkPlay320;
        private string _LinkDownload320;
        private string _LinkPlay128;
        private string _LinkPlayEmbed;
        private string _LinkDownload128;
        private string _Link;
        private string _LinkHtml5;
        private string _Lyric;
        private string _RingTone;
        private bool _IsPlaying;

        public bool IsPlaying
        {
            get { return _IsPlaying; }
            set
            {
                if (value.Equals(_IsPlaying)) return;
                _IsPlaying = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ảnh đại diện ca sỹ
        /// </summary>
        public string ArtistAvatar
        {
            get { return _ArtistAvatar; }
            set
            {
                if (value == _ArtistAvatar) return;
                _ArtistAvatar = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Nhạc Mobile
        /// </summary>
        public string MobilePath
        {
            get { return _MobilePath; }
            set
            {
                if (value == _MobilePath) return;
                _MobilePath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link play nhạc 24 Kbits
        /// </summary>
        public string LinkPlay24
        {
            get { return _LinkPlay24; }
            set
            {
                if (value == _LinkPlay24) return;
                _LinkPlay24 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link play nhạc 128 Kbits
        /// </summary>
        public string LinkPlay128
        {
            get { return _LinkPlay128; }
            set
            {
                if (value == _LinkPlay128) return;
                _LinkPlay128 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link download nhạc 128 Kbits
        /// </summary>
        public string LinkDownload128
        {
            get { return _LinkDownload128; }
            set
            {
                if (value == _LinkDownload128) return;
                _LinkDownload128 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link play nhạc 320 Kbits
        /// </summary>
        public string LinkPlay320
        {
            get { return _LinkPlay320; }
            set
            {
                if (value == _LinkPlay320) return;
                _LinkPlay320 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link download nhạc 320 Kbits
        /// </summary>
        public string LinkDownload320
        {
            get { return _LinkDownload320; }
            set
            {
                if (value == _LinkDownload320) return;
                _LinkDownload320 = value;
                OnPropertyChanged();
            }
        }

        public string LinkPlayEmbed
        {
            get { return _LinkPlayEmbed; }
            set
            {
                if (value == _LinkPlayEmbed) return;
                _LinkPlayEmbed = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link tới bài hát trên trang mp3.zing.vn
        /// </summary>
        public string Link
        {
            get { return _Link; }
            set
            {
                if (value == _Link) return;
                _Link = value;
                OnPropertyChanged();
            }
        }

        public string LinkHtml5
        {
            get { return _LinkHtml5; }
            set
            {
                if (value == _LinkHtml5) return;
                _LinkHtml5 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// lời bài hát
        /// </summary>
        public string Lyric
        {
            get { return _Lyric; }
            set
            {
                if (value == _Lyric) return;
                _Lyric = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// <para>1: bài hát có nhạc chờ</para>
        /// <para>0: bài hát không có nhạc chờ</para>
        /// </summary>
        public string Ringtone
        {
            get { return _RingTone; }
            set
            {
                if (value == _RingTone) return;
                _RingTone = value;
                OnPropertyChanged();
            }
        }
    }

    public class AlbumItem : BaseItem
    {
        public string _PictureURL;

        public string PictureUrl
        {
            get { return _PictureURL; }
            set
            {
                if (value == _PictureURL) return;
                _PictureURL = value;
                OnPropertyChanged();
            }
        }
    }

    public class VideoItem : BaseItem
    {
        private string _TotalView;
        private string _LinkDownload;
        public string _PictureURL;

        public string TotalView
        {
            get { return _TotalView; }
            set
            {
                if (value == _TotalView) return;
                _TotalView = value;
                OnPropertyChanged();
            }
        }

        public string LinkDownload
        {
            get { return _LinkDownload; }
            set
            {
                if (value == _LinkDownload) return;
                _LinkDownload = value;
                OnPropertyChanged();
            }
        }

        public string PictureUrl
        {
            get { return _PictureURL; }
            set
            {
                if (value == _PictureURL) return;
                _PictureURL = value;
                OnPropertyChanged();
            }
        }
    }

    #region Json Data

    public class JsonData1
    {
        public string t { get; set; }
    }

    public class JsonData2
    {
        public string t { get; set; }
        public string id { get; set; }
    }

    #endregion

    public class CheckParameterData
    {
        public string enableSync { get; set; }
        public string wpapplink { get; set; }
        public string androidapplink { get; set; }
        public string iosapplink { get; set; }
        public string notetouser { get; set; }
        public string bloglink { get; set; }
        public string w8applink { get; set; }
        public string latestVersion { get; set; }
        public string adMode { get; set; }
    }
}