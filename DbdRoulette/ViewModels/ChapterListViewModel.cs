using AngleSharp;
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
    public class ChapterListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Chapter> StaticChapterList = new List<Chapter>();
        public IEnumerable<Chapter> EditableChapterList = new List<Chapter>();

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
                OnPropertyChanged("ChapterList");
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
                OnPropertyChanged("ChapterList");
            }
        }
        public IEnumerable<Chapter> ChapterList
        {
            get
            {
                if (FirstCheck == false)
                {
                    FirstCheck = true;

                    StaticChapterList = App.DB.Chapter.OrderByDescending(x => x.DateRelease).ToList();

                    return StaticChapterList.Where(x => x.Id != 3);
                }
                else
                {
                    RefreshChapters();
                    return EditableChapterList;
                }
            }
            set
            {

            }
        }
        public ChapterListViewModel()
        {

        }
        private void RefreshChapters()
        {
            EditableChapterList = StaticChapterList;
            if (comboBoxIndex == 0)
            {
                EditableChapterList = EditableChapterList.OrderByDescending(x => x.DateRelease);
            }
            if (comboBoxIndex == 1)
            {
                EditableChapterList = EditableChapterList.OrderBy(x => x.DateRelease);
            }
            if (SearchText.Length > 0)
            {
                EditableChapterList = EditableChapterList.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
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
