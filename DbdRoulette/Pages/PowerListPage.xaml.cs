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
    /// Логика взаимодействия для PowerListPage.xaml
    /// </summary>
    public partial class PowerListPage : Page
    {
        int maxPage = 0;
        int numberPage = 0;
        int count = 15;
        int fakePage = 1;
        public PowerListPage()
        {
            InitializeComponent();

            CbSort.Items.Add("По названию");
            CbSort.Items.Add("По владельцу");

            CbSort.SelectedIndex = 0;
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
            IEnumerable<Power> powers = App.DB.Power.ToList();
            if (CbSort.SelectedIndex == 0)
            {
                powers = powers.OrderBy(x => x.Name);
            }
            else if (CbSort.SelectedIndex == 1)
            {
                powers = powers.OrderBy(x => x.Killer.FirstOrDefault().Name);
            }
            if (TbSearch.Text.Length > 0)
            {
                powers = powers.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()) || x.OwnerName.ToLower().Contains(TbSearch.Text.ToLower()));
            }
            if (powers.Count() > count)
            {
                if (powers.Count() % count > 0)
                {
                    maxPage = (powers.Count() / count) + 1;
                }
                else
                {
                    maxPage = powers.Count() / count;
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
            powers = powers.Skip(count * numberPage).Take(count).ToList();
            LvPowers.ItemsSource = powers;
            LvPowers.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);

            if (LvPowers.Items.Count == 0)
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void PowerBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedPower = (sender as Grid).DataContext as Power;
            NavigationService.Navigate(new PowerAddonsPage(selectedPower));
        }
    }
}
