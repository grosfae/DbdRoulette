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
    public class EffectListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Effect> StaticEffectList = new List<Effect>();
        public IEnumerable<Effect> EditableEffectList = new List<Effect>();

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
                OnPropertyChanged("EffectList");
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
                OnPropertyChanged("EffectList");
            }
        }
        public IEnumerable<Effect> EffectList
        {
            get
            {
                if (FirstCheck == false)
                {
                    FirstCheck = true;

                    StaticEffectList = App.DB.Effect.OrderBy(x => x.Name).ToList();

                    return StaticEffectList;
                }
                else
                {
                    RefreshEffects();
                    return EditableEffectList;
                }
            }
            set
            {

            }
        }
        public EffectListViewModel()
        {
            
        }
        private void RefreshEffects()
        {
            EditableEffectList = StaticEffectList;
            if (comboBoxIndex == 0)
            {
                EditableEffectList = EditableEffectList.OrderBy(x => x.Name);
            }
            if (comboBoxIndex == 1)
            {
                EditableEffectList = EditableEffectList.Where(x => x.IsBuff == true);
            }
            if (comboBoxIndex == 2)
            {
                EditableEffectList = EditableEffectList.Where(x => x.IsBuff == false);
            }
            if (SearchText.Length > 0)
            {
                EditableEffectList = EditableEffectList.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
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
