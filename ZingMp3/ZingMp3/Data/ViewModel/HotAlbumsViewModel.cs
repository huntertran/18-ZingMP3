using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZingMp3.Annotations;
using ZingMp3.Model;
using ZingMp3.Utilities;

namespace ZingMp3.Data.ViewModel
{
    public class HotAlbumsViewModel
    {
        public ObservableCollection<MusicItem> HotAlbumsCollection { get; set; }

        private bool _isLoaded;

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set
            {
                if (value.Equals(_isLoaded)) return;
                _isLoaded = value;
                OnPropertyChanged();
            }
        }

        public void AddItem(MusicItem musicItem)
        {
            HotAlbumsCollection.Add(musicItem);
        }

        public void RemoveItem(MusicItem musicItem)
        {
            HotAlbumsCollection.Remove(musicItem);
        }

        public void RemoveItemAt(int index)
        {
            HotAlbumsCollection.RemoveAt(index);
        }

        public void UpdateItem(int index, MusicItem musicItem)
        {
            HotAlbumsCollection[index] = musicItem;
        }

        public async void LoadData()
        {
            string htmlString = await StaticMethod.GetHttpAsStringGZipAware("link");
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public HotAlbumsViewModel()
        {
            _isLoaded = false;
            HotAlbumsCollection = new ObservableCollection<MusicItem>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
