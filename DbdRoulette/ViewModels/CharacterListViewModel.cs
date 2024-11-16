using DbdRoulette.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DbdRoulette.ViewModels
{
    public class CharacterListViewModel : ViewModelBase
    {
        public bool IsLoading { get; private set; }
        public List<Killer> StaticKillerList {get; private set;}
        public List<Survivor> StaticSurvivorList { get; private set; }

        public int comboBoxIndex { get; set; }

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

        public string searchText = string.Empty;

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
            StaticKillerList = new List<Killer>();
            StaticSurvivorList = new List<Survivor>();

            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            IsLoading = false;
            OnPropertyChanged(nameof(IsLoading));

            await Task.Run(() => AddDataInList());

            IsLoading = true;
            OnPropertyChanged(nameof(IsLoading));

            OnPropertyChanged(nameof(CharacterList));
        }
        private void AddDataInList()
        {
            var KillerData = App.DB.Killer;
            foreach (var item in KillerData)
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    StaticKillerList.Add(item);
                });   
            }
            var SurvivorData = App.DB.Survivor;
            foreach (var item in SurvivorData)
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    StaticSurvivorList.Add(item);
                });
            }
        }
        public IEnumerable<object> CharacterList
        {
            get
            {
                IEnumerable<object> filteredCharacterList;
                if (TypeCharacterSelect == true)
                {
                    filteredCharacterList = RefreshKillers();
                }
                else
                {
                    filteredCharacterList = RefreshSurvivors();
                }
                return filteredCharacterList;
            }
            set
            {

            }
        }
        IEnumerable<Killer> RefreshKillers()
        {
            IEnumerable<Killer> filteredKillerList = StaticKillerList;

            if (ComboBoxIndex == 0)
            {
                filteredKillerList = filteredKillerList.OrderByDescending(x => x.Chapter.CorrectDateRelease);
            }
            else if (ComboBoxIndex == 1)
            {
                filteredKillerList = filteredKillerList.OrderBy(x => x.Chapter.CorrectDateRelease);
            }
            else if (ComboBoxIndex == 2)
            {
                filteredKillerList = filteredKillerList.Where(x => x.DifficultyId == 1);
            }
            else if (ComboBoxIndex == 3)
            {
                filteredKillerList = filteredKillerList.Where(x => x.DifficultyId == 2);
            }
            else if (ComboBoxIndex == 4)
            {
                filteredKillerList = filteredKillerList.Where(x => x.DifficultyId == 3);
            }
            else if (ComboBoxIndex == 5)
            {
                filteredKillerList = filteredKillerList.Where(x => x.DifficultyId == 4);
            }
            if (searchText.Length > 0)
            {
                filteredKillerList = filteredKillerList.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
            }
            return filteredKillerList;
        }

        IEnumerable<Survivor> RefreshSurvivors()
        {
            IEnumerable<Survivor> filteredSurvivorList = StaticSurvivorList;
            if (ComboBoxIndex == 0)
            {
                filteredSurvivorList = filteredSurvivorList.OrderByDescending(x => x.Chapter.CorrectDateRelease);
            }
            else if (ComboBoxIndex == 1)
            {
                filteredSurvivorList = filteredSurvivorList.OrderBy(x => x.Chapter.CorrectDateRelease);
            }
            if (searchText.Length > 0)
            {
                filteredSurvivorList = filteredSurvivorList.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
            }
            return filteredSurvivorList;
        }

    }

}
