using AngleSharp;
using DbdRoulette.Addons;
using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.ViewModels
{
    public class PerkListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Perk> StaticPerkList = new List<Perk>();
        public IEnumerable<Perk> EditablePerkList = new List<Perk>();
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
                OnPropertyChanged("PerkList");
            }
        }
        public bool typeCharacterSelect;
        public bool TypeCharacterSelect
        {
            get
            {
                return typeCharacterSelect;
            }
            set
            {
                typeCharacterSelect = value;
                OnPropertyChanged("PerkList");
            }
        }
        public IEnumerable<Perk> PerkList
        {
            get
            {
                if (FirstCheck == false)
                {
                    FirstCheck = true;

                    StaticPerkList = App.DB.Perk.OrderBy(x => x.Name).ToList();

                    if (TypeCharacterSelect == false)
                    {
                        return StaticPerkList.Where(x => x.PerkTypeId == 1);
                    }
                    else
                    {
                        return StaticPerkList.Where(x => x.PerkTypeId == 2);
                    }
                }
                else
                {
                    RefreshPerks();
                    return EditablePerkList;
                }
            }
            set
            {

            }
        }
        public PerkListViewModel()
        {

        }
        private void RefreshPerks()
        {
            EditablePerkList = StaticPerkList;

            if (TypeCharacterSelect == false)
            {
                EditablePerkList = EditablePerkList.Where(x => x.PerkTypeId == 1);
            }
            else
            {
                EditablePerkList = EditablePerkList.Where(x => x.PerkTypeId == 2);
            }

            if (SearchText.Length > 0)
            {
                EditablePerkList = EditablePerkList.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()) || x.Description.ToLower().Contains(SearchText.ToLower()) || x.OwnerName.ToLower().Contains(SearchText.ToLower()));
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
