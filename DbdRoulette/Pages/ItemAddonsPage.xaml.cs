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
    /// Логика взаимодействия для ItemAddonsPage.xaml
    /// </summary>
    public partial class ItemAddonsPage : Page
    {
        object contextItemType;
        public ItemAddonsPage(Object itemType)
        {
            InitializeComponent();
            contextItemType = itemType;
            LvItems.ItemsSource = App.DB.ItemType.Where(x => x.Id != 1 && x.Id != 2 && x.Id != 8).ToList();
            LvAddons.ItemsSource = App.DB.Addon.OrderBy(x => x.ItemType.Name).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
        private void ItemTypeBtn_Checked(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as RadioButton).DataContext as ItemType;
            if(selectedItem.Id != 8)
            {
                LvAddons.ItemsSource = App.DB.Addon.Where(x => x.ItemTypeId == selectedItem.Id).OrderBy(x => x.Rarity.Name).OrderBy(x => x.Name).ToList();
            }
            else
            {
                LvAddons.ItemsSource = null;
            }
        }

        private void ItemTypeBtn_Loaded(object sender, RoutedEventArgs e)
        {
            var currentItemType = (sender as RadioButton).DataContext as ItemType;
            if(currentItemType == contextItemType)
            {
                (sender as RadioButton).IsChecked = true;
            }
        }
    }
}
