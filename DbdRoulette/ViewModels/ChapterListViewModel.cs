using AngleSharp;
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
    public class ChapterListViewModel : ViewModelBase
    {
        public bool IsLoading { get; private set; }
        public List<Chapter> StaticChapterList { get; private set; }
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
                OnPropertyChanged("ChapterList");
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
                OnPropertyChanged("ChapterList");
            }
        }

        public ChapterListViewModel()
        {
            StaticChapterList = new List<Chapter>();
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            IsLoading = false;
            OnPropertyChanged(nameof(IsLoading));

            await Task.Run(() => AddDataInList());

            IsLoading = true;
            OnPropertyChanged(nameof(IsLoading));

            OnPropertyChanged(nameof(ChapterList));
        }
        private void AddDataInList()
        {
            var ChapterData = App.DB.Chapter;
            foreach (var item in ChapterData)
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    StaticChapterList.Add(item);
                });
            }
        }
        public IEnumerable<Chapter> ChapterList
        {
            get
            {
                IEnumerable<Chapter> filteredChapterList = RefreshChapters();
                return filteredChapterList;
            }
            set
            {

            }
        }
        IEnumerable<Chapter> RefreshChapters()
        {
            IEnumerable<Chapter> filteredChapters = StaticChapterList;
            if (comboBoxIndex == 0)
            {
                filteredChapters = filteredChapters.OrderByDescending(x => x.CorrectDateRelease);
            }
            if (comboBoxIndex == 1)
            {
                filteredChapters = filteredChapters.OrderBy(x => x.CorrectDateRelease);
            }
            if (SearchText.Length > 0)
            {
                filteredChapters = filteredChapters.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
            }
            return filteredChapters.Where(x => x.Id != 3);

        }

    }
}
