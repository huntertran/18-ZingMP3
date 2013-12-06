using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ZingMp3.Annotations;
using ZingMp3.Model;
using ZingMp3.Utilities;

namespace ZingMp3.Data.ViewModel
{
    public class HotSongsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MusicItem> HotSongsCollection
        {
            get;
            set;
        }

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
            HotSongsCollection.Add(musicItem);
        }

        public void RemoveItem(MusicItem musicItem)
        {
            HotSongsCollection.Remove(musicItem);
        }

        public void RemoveItemAt(int index)
        {
            HotSongsCollection.RemoveAt(index);
        }

        public void UpdateItem(int index, MusicItem musicItem)
        {
            HotSongsCollection[index] = musicItem;
        }

        public async Task LoadData()
        {
            JArray resultArray = await CallAPI.GetHotContentTask("song");
            HotSongsCollection = resultArray.ToObject<ObservableCollection<MusicItem>>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public HotSongsViewModel()
        {
            _isLoaded = false;
            HotSongsCollection = new ObservableCollection<MusicItem>();
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
