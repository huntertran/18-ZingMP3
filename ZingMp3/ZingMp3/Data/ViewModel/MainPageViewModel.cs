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
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MusicItem> musicItemCollection { get; set; }

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
            musicItemCollection.Add(musicItem);
        }

        public void RemoveItem(MusicItem musicItem)
        {
            musicItemCollection.Remove(musicItem);
        }

        public void RemoveItemAt(int index)
        {
            musicItemCollection.RemoveAt(index);
        }

        public void UpdateItem(int index, MusicItem musicItem)
        {
            musicItemCollection[index] = musicItem;
        }

        public async void LoadData()
        {
            string htmlString = await StaticMethod.GetHttpAsStringGZipAware("link");
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPageViewModel()
        {
            _isLoaded = false;
            musicItemCollection = new ObservableCollection<MusicItem>();
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
