using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace DbdRoulette.ViewModels
{
    public class LocationListViewModel : ViewModelBase
    {
        public List<Map> StaticLocationList { get; private set; }
        public bool IsLoading { get; private set; }

        public string searchText = "";
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged("LocationList");
            }
        }
        public int comboBoxIndex;

        public int ComboBoxIndex
        {
            get
            {
                return comboBoxIndex;
            }
            set
            {
                comboBoxIndex = value;
                OnPropertyChanged("LocationList");
            }
        }
        
        public LocationListViewModel()
        {
            StaticLocationList = new List<Map>();
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            IsLoading = false;
            OnPropertyChanged(nameof(IsLoading));

            await Task.Run(() => AddDataInList());

            IsLoading = true;
            OnPropertyChanged(nameof(IsLoading));

            OnPropertyChanged(nameof(LocationList));
        }
        private void AddDataInList()
        {
            var MapData = App.DB.Map;
            foreach (var item in MapData)
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    StaticLocationList.Add(item);
                });
            }
        }
        public IEnumerable<Map> LocationList
        {
            get
            {
                IEnumerable<Map> filteredLocationList = RefreshLocations();
                return filteredLocationList;
            }
            set
            {

            }
        }
        IEnumerable<Map> RefreshLocations()
        {
            IEnumerable<Map> filteredMaps = StaticLocationList;
            if (comboBoxIndex == 0)
            {
                filteredMaps = filteredMaps.OrderByDescending(x => x.Chapter.CorrectDateRelease);
            }
            if (comboBoxIndex == 1)
            {
                filteredMaps = filteredMaps.OrderBy(x => x.Chapter.CorrectDateRelease);
            }
            if (SearchText.Length > 0)
            {
                filteredMaps = filteredMaps.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
            }
            return filteredMaps;
        }
    }
}
