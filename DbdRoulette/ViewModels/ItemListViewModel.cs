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
    public class ItemListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Item> StaticItemList = new List<Item>();
        public IEnumerable<Item> EditableItemList = new List<Item>();

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
                OnPropertyChanged("ItemList");
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
                OnPropertyChanged("ItemList");
            }
        }
        public IEnumerable<Item> ItemList
        {
            get
            {
                if (FirstCheck == false)
                {
                    FirstCheck = true;

                    StaticItemList = App.DB.Item.OrderBy(x => x.Name).ToList();

                    return StaticItemList;
                }
                else
                {
                    RefreshItems();
                    return EditableItemList;
                }
            }
            set
            {

            }
        }
        public ItemListViewModel()
        {

        }
        private void RefreshItems()
        {
            EditableItemList = StaticItemList;
            if (comboBoxIndex == 0)
            {
                EditableItemList = EditableItemList.OrderBy(x => x.Name);
            }
            if (comboBoxIndex == 1)
            {
                EditableItemList = EditableItemList.OrderBy(x => x.RarityId);
            }
            if (comboBoxIndex == 2)
            {
                EditableItemList = EditableItemList.OrderByDescending(x => x.RarityId);
            }
            if (SearchText.Length > 0)
            {
                EditableItemList = EditableItemList.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
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
