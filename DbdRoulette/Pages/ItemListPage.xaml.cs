using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.ViewModels;
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
    /// Логика взаимодействия для ItemListPage.xaml
    /// </summary>
    public partial class ItemListPage : Page
    {
        LoadingControl contextContentLoader;
        public bool FirstTry;
        public ItemListPage(LoadingControl loadingControl)
        {
            InitializeComponent();

            CbSort.Items.Add("По названию");
            CbSort.Items.Add("По возрастанию редкости");
            CbSort.Items.Add("По убыванию редкости");
            LvRarities.ItemsSource = App.DB.Rarity.Where(x => x.Id != 6 && x.Id != 8 && x.Id != 10).ToList();

            contextContentLoader = loadingControl;
            DataContext = new ItemListViewModel();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void ItemBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as Grid).DataContext as Item;
            NavigationService.Navigate(new ItemAddonsPage(selectedItem.ItemType));
        }

        private void LvItems_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (FirstTry == true)
            {
                contextContentLoader.StopAnimation();
            }
            else
            {
                FirstTry = true;
            }

            if (LvItems.Items.Count == 0)
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvItems.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
        }
    }
}
