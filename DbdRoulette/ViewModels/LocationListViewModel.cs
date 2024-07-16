using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.ViewModels
{
    public class LocationListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Map> StaticLocationList = new List<Map>();
        public IEnumerable<Map> EditableLocationList = new List<Map>();

        public bool FirstCheck;

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
        public IEnumerable<Map> LocationList
        {
            get
            {
                if (FirstCheck == false)
                {
                    FirstCheck = true;

                    StaticLocationList = App.DB.Map.OrderByDescending(x => x.Chapter.DateRelease).ToList();

                    return StaticLocationList;
                }
                else
                {
                    RefreshLocations();
                    return EditableLocationList;
                }
            }
            set
            {

            }
        }
        public LocationListViewModel()
        {

        }
        private void RefreshLocations()
        {
            EditableLocationList = StaticLocationList;
            if (comboBoxIndex == 0)
            {
                EditableLocationList = EditableLocationList.OrderByDescending(x => x.Chapter.DateRelease);
            }
            if (comboBoxIndex == 1)
            {
                EditableLocationList = EditableLocationList.OrderBy(x => x.Chapter.DateRelease);
            }
            if (SearchText.Length > 0)
            {
                EditableLocationList = EditableLocationList.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
