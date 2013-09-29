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
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
    }

    public class GerneDetail
    {
        public string GerneId { get; set; }
        public string GerneName { get; set; }
    }

    public class BaseItem : INotifyPropertyChanged
    {
        private string _id;

        private string _title;

        public string _artist;

        public string Artist
        {
            get { return _artist; }
            set
            {
                if (value == _artist) return;
                _artist = value;
                OnPropertyChanged();
            }
        }

        private ArtistDetail _artistDetail;

        private string _gerne;

        public GerneDetail _gerneDetail;

        public string _ownerAcc;

        public string _pictureUrl;

        public string _createdData;

        public string _totalListen;

        public string _hit;

        public string _official;

        /// <summary>
        /// Song Id
        /// </summary>
        public string Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Song title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public ArtistDetail ArtistDetail
        {
            get { return _artistDetail; }
            set
            {
                if (Equals(value, _artistDetail)) return;
                _artistDetail = value;
                OnPropertyChanged();
            }
        }

        public string Gerne
        {
            get { return _gerne; }
            set
            {
                if (value == _gerne) return;
                _gerne = value;
                OnPropertyChanged();
            }
        }

        public GerneDetail GerneDetail
        {
            get { return _gerneDetail; }
            set
            {
                if (Equals(value, _gerneDetail)) return;
                _gerneDetail = value;
                OnPropertyChanged();
            }
        }

        public string OwnerAcc
        {
            get { return _ownerAcc; }
            set
            {
                if (value == _ownerAcc) return;
                _ownerAcc = value;
                OnPropertyChanged();
            }
        }

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set
            {
                if (value == _pictureUrl) return;
                _pictureUrl = value;
                OnPropertyChanged();
            }
        }

        public string CreatedData
        {
            get { return _createdData; }
            set
            {
                if (value == _createdData) return;
                _createdData = value;
                OnPropertyChanged();
            }
        }

        public string TotalListen
        {
            get { return _totalListen; }
            set
            {
                if (value == _totalListen) return;
                _totalListen = value;
                OnPropertyChanged();
            }
        }

        public string Hit
        {
            get { return _hit; }
            set
            {
                if (value == _hit) return;
                _hit = value;
                OnPropertyChanged();
            }
        }

        public string Official
        {
            get { return _official; }
            set
            {
                if (value == _official) return;
                _official = value;
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
        public string _artistAvatar;
        public string _mobilePath;
        public string _linkPlay24;
        public string _linkPlay128;
        public string _linkDownload128;
        public string _linkPlay320;
        public string _linkDownload320;

        public string _link;
        public string _lyric;
        public string _ringtone;

        /// <summary>
        /// Ảnh đại diện ca sỹ
        /// </summary>
        public string ArtistAvatar
        {
            get { return _artistAvatar; }
            set
            {
                if (value == _artistAvatar) return;
                _artistAvatar = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Nhạc Mobile
        /// </summary>
        public string MobilePath
        {
            get { return _mobilePath; }
            set
            {
                if (value == _mobilePath) return;
                _mobilePath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link play nhạc 24 Kbits
        /// </summary>
        public string LinkPlay24
        {
            get { return _linkPlay24; }
            set
            {
                if (value == _linkPlay24) return;
                _linkPlay24 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link play nhạc 128 Kbits
        /// </summary>
        public string LinkPlay128
        {
            get { return _linkPlay128; }
            set
            {
                if (value == _linkPlay128) return;
                _linkPlay128 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link download nhạc 128 Kbits
        /// </summary>
        public string LinkDownload128
        {
            get { return _linkDownload128; }
            set
            {
                if (value == _linkDownload128) return;
                _linkDownload128 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link play nhạc 320 Kbits
        /// </summary>
        public string LinkPlay320
        {
            get { return _linkPlay320; }
            set
            {
                if (value == _linkPlay320) return;
                _linkPlay320 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link download nhạc 320 Kbits
        /// </summary>
        public string LinkDownload320
        {
            get { return _linkDownload320; }
            set
            {
                if (value == _linkDownload320) return;
                _linkDownload320 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// link tới bài hát trên trang mp3.zing.vn
        /// </summary>
        public string Link
        {
            get { return _link; }
            set
            {
                if (value == _link) return;
                _link = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// lời bài hát
        /// </summary>
        public string Lyric
        {
            get { return _lyric; }
            set
            {
                if (value == _lyric) return;
                _lyric = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// <para>1: bài hát có nhạc chờ</para>
        /// <para>0: bài hát không có nhạc chờ</para>
        /// </summary>
        public string Ringtone
        {
            get { return _ringtone; }
            set
            {
                if (value == _ringtone) return;
                _ringtone = value;
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
}