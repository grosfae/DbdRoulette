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
    public class PowerListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Power> StaticPowerList = new List<Power>();
        public IEnumerable<Power> EditablePowerList = new List<Power>();

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
                OnPropertyChanged("PowerList");
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
                OnPropertyChanged("PowerList");
            }
        }
        public IEnumerable<Power> PowerList
        {
            get
            {
                if (FirstCheck == false)
                {
                    FirstCheck = true;

                    StaticPowerList = App.DB.Power.OrderBy(x => x.Name).ToList();

                    return StaticPowerList;
                }
                else
                {
                    RefreshPowers();
                    return EditablePowerList;
                }
            }
            set
            {

            }
        }
        public PowerListViewModel()
        {

        }
        private void RefreshPowers()
        {
            EditablePowerList = StaticPowerList;
            if (comboBoxIndex == 0)
            {
                EditablePowerList = EditablePowerList.OrderBy(x => x.Name);
            }
            if (comboBoxIndex == 1)
            {
                EditablePowerList = EditablePowerList.OrderBy(x => x.OwnerName);
            }
            if (SearchText.Length > 0)
            {
                EditablePowerList = EditablePowerList.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()) || x.OwnerName.ToLower().Contains(SearchText.ToLower()));
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
