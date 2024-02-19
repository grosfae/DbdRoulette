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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для LocationsListPage.xaml
    /// </summary>
    public partial class LocationsListPage : Page
    {
        public LocationsListPage()
        {
            InitializeComponent();

            CbSort.Items.Add("По умолчанию");
            CbSort.Items.Add("По названию");

            CbSort.SelectedIndex = 0;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Map> maps = App.DB.Map.ToList();
            if (CbSort.SelectedIndex == 1)
            {
                maps = maps.OrderBy(x => x.Name);
            }
            if (TbSearch.Text.Length > 0)
            {
                maps = maps.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()) || x.Chapter.Name.ToLower().Contains(TbSearch.Text.ToLower()));
            }

            LvLocations.ItemsSource = maps;

            if (LvLocations.Items.Count > 0)
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvLocations.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
    }
}
