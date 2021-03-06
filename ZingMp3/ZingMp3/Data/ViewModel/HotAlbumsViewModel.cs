﻿using System;
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
    public class HotAlbumsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AlbumItem> HotAlbumsCollection { get; set; }

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

        public void AddItem(AlbumItem albumItem)
        {
            HotAlbumsCollection.Add(albumItem);
        }

        public void RemoveItem(AlbumItem albumItem)
        {
            HotAlbumsCollection.Remove(albumItem);
        }

        public void RemoveItemAt(int index)
        {
            HotAlbumsCollection.RemoveAt(index);
        }

        public void UpdateItem(int index, AlbumItem albumItem)
        {
            HotAlbumsCollection[index] = albumItem;
        }

        public async Task LoadData()
        {
            JArray resultArray = await CallAPI.GetHotContentTask("album");
            HotAlbumsCollection = resultArray.ToObject<ObservableCollection<AlbumItem>>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public HotAlbumsViewModel()
        {
            _isLoaded = false;
            HotAlbumsCollection = new ObservableCollection<AlbumItem>();
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
