using DbdRoulette.Addons;
using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChapterListPage.xaml
    /// </summary>
    public partial class ChapterListPage : Page
    {
        public ChapterListPage()
        {
            InitializeComponent();
            CbSort.Items.Add("Самые новые");
            CbSort.Items.Add("Самые ранние");
            CbSort.SelectedIndex = 0;
        }

        
        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshСhapters();
        }
        private void RefreshСhapters()
        {
            IEnumerable<Chapter> chapters = App.DB.Chapter.ToList();
            if (CbSort.SelectedIndex == 0)
            {
                chapters = chapters.OrderByDescending(x => x.DateRelease);
            }
            else if (CbSort.SelectedIndex == 1)
            {
                chapters = chapters.OrderBy(x => x.DateRelease);
            }
            if (TbSearch.Text.Length > 0)
            {
                chapters = chapters.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()));
            }
            LvChapters.ItemsSource = chapters;

            LvChapters.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshСhapters();
        }


        private void ChapterBlockElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as UserControl).DataContext as Chapter;
            NavigationService.Navigate(new ChapterViewPage(selectedItem));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshСhapters();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
    }
}
