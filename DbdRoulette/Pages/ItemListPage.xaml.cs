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
    /// Логика взаимодействия для ItemListPage.xaml
    /// </summary>
    public partial class ItemListPage : Page
    {
        int maxPage = 0;
        int numberPage = 0;
        int count = 15;
        int fakePage = 1;
        public ItemListPage()
        {
            InitializeComponent();

            CbSort.Items.Add("По алфавиту");
            CbSort.Items.Add("По редкости");
            CbSort.SelectedIndex = 0;

            LvRarities.ItemsSource = App.DB.Rarity.Where(x => x.Id != 6 && x.Id != 8 && x.Id != 10).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
            GeneratePageButtons();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
            GeneratePageButtons();
        }
        private void Refresh()
        {
            IEnumerable<Item> items = App.DB.Item.ToList();
            if (CbSort.SelectedIndex == 0)
            {
                items = items.OrderBy(x => x.Name);
            }
            else if (CbSort.SelectedIndex == 1)
            {
                items = items.OrderBy(x => x.RarityId);
            }
            if (TbSearch.Text.Length > 0)
            {
                items = items.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()));
            }
            if (items.Count() > count)
            {
                if (items.Count() % count > 0)
                {
                    maxPage = (items.Count() / count) + 1;
                }
                else
                {
                    maxPage = items.Count() / count;
                }
            }
            else
            {
                maxPage = 1;
            }
            if (fakePage > maxPage)
            {
                fakePage = maxPage;
            }
            items = items.Skip(count * numberPage).Take(count).ToList();
            LvItems.ItemsSource = items;
            LvItems.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            GeneratePageButtons();
        }
        private void GeneratePageButtons()
        {
            SPanelPages.Children.Clear();
            for (int i = 1; i <= maxPage; i++)
            {
                RadioButton btn = new RadioButton
                {
                    Content = i,
                    Width = 30,
                    Height = 30,
                    Margin = new Thickness(10, 0, 10, 0),
                };
                btn.Checked += RadioPageButton_Checked;
                btn.Style = FindResource("PageNumberRadio") as Style;
                SPanelPages.Children.Add(btn);

                if (int.Parse(btn.Content.ToString()) == fakePage)
                {
                    btn.IsChecked = true;
                }
            }
        }
        private void RadioPageButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            int realPageNumber = int.Parse(radioButton.Content.ToString()) - 1;
            numberPage = realPageNumber;
            fakePage = int.Parse(radioButton.Content.ToString());
            Refresh();
        }

        private void ItemBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as Grid).DataContext as Item;
            NavigationService.Navigate(new ItemAddonsPage(selectedItem.ItemType));
        }
    }
}
