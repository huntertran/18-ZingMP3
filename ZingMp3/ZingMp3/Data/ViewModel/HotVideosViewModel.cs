using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ZingMp3.Annotations;
using ZingMp3.Model;
using ZingMp3.Utilities;

namespace ZingMp3.Data.ViewModel
{
    public class HotVideosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<VideoItem> HotVideosCollection { get; set; }

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

        public void AddItem(VideoItem musicItem)
        {
            HotVideosCollection.Add(musicItem);
        }

        public void RemoveItem(VideoItem musicItem)
        {
            HotVideosCollection.Remove(musicItem);
        }

        public void RemoveItemAt(int index)
        {
            HotVideosCollection.RemoveAt(index);
        }

        public void UpdateItem(int index, VideoItem musicItem)
        {
            HotVideosCollection[index] = musicItem;
        }

        public async Task LoadData()
        {
            JArray resultArray = await CallAPI.GetHotContentTask("video");
            HotVideosCollection = resultArray.ToObject<ObservableCollection<VideoItem>>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public HotVideosViewModel()
        {
            _isLoaded = false;
            HotVideosCollection = new ObservableCollection<VideoItem>();
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
