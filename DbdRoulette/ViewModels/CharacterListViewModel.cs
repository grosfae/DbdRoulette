using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DbdRoulette.ViewModels
{
    public class CharacterListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Killer> EditableKillerList = new List<Killer>();

        public IEnumerable<Killer> StaticKillerList = new List<Killer>();

        public IEnumerable<Survivor> EditableSurvivorList = new List<Survivor>();

        public IEnumerable<Survivor> StaticSurvivorList = new List<Survivor>();

        public bool FirstCheck;

        public IEnumerable<object> CharacterList
        {
            get
            {
                if(FirstCheck == false)
                {
                    FirstCheck = true;

                    StaticKillerList = App.DB.Killer.ToList();
                    StaticSurvivorList = App.DB.Survivor.ToList();

                    if (TypeCharacterSelect == true)
                    {
                        return StaticKillerList.OrderByDescending(x => x.Chapter.DateRelease);
                    }
                    else
                    {
                        return StaticSurvivorList;
                    }
                }
                else
                {
                    if (TypeCharacterSelect == true)
                    {
                        RefreshKillers();
                        return EditableKillerList;
                    }
                    else
                    {
                        RefreshSurvivors();
                        return EditableSurvivorList;
                    }
                }
            }
            set
            {
                
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
                OnPropertyChanged("CharacterList");
            }
        }

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
                OnPropertyChanged("CharacterList");
            }
        }

        public bool typeCharacterSelect = true;

        public bool TypeCharacterSelect
        {
            get
            {
                return typeCharacterSelect;
            }
            set
            {
                typeCharacterSelect = value;
                OnPropertyChanged("CharacterList");
            }
        }

        public CharacterListViewModel()
        {
            
        }


        private void RefreshKillers()
        {
            EditableKillerList = StaticKillerList;
            if (ComboBoxIndex == 0)
            {
                EditableKillerList = EditableKillerList.OrderByDescending(x => x.Chapter.DateRelease);
            }
            else if (ComboBoxIndex == 1)
            {
                EditableKillerList = EditableKillerList.OrderBy(x => x.Chapter.DateRelease);
            }
            else if (ComboBoxIndex == 2)
            {
                EditableKillerList = EditableKillerList.Where(x => x.DifficultyId == 1);
            }
            else if (ComboBoxIndex == 3)
            {
                EditableKillerList = EditableKillerList.Where(x => x.DifficultyId == 2);
            }
            else if (ComboBoxIndex == 4)
            {
                EditableKillerList = EditableKillerList.Where(x => x.DifficultyId == 3);
            }
            else if (ComboBoxIndex == 5)
            {
                EditableKillerList = EditableKillerList.Where(x => x.DifficultyId == 4);
            }
            if (searchText.Length > 0)
            {
                EditableKillerList = EditableKillerList.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
            }
        }

        private void RefreshSurvivors()
        {
            EditableSurvivorList = StaticSurvivorList;
            if (ComboBoxIndex == 0)
            {
                EditableSurvivorList = EditableSurvivorList.OrderByDescending(x => x.Chapter.DateRelease);
            }
            else if (ComboBoxIndex == 1)
            {
                EditableSurvivorList = EditableSurvivorList.OrderBy(x => x.Chapter.DateRelease);
            }
            if (searchText.Length > 0)
            {
                EditableSurvivorList = EditableSurvivorList.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
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
