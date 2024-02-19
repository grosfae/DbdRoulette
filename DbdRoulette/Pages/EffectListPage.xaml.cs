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
    /// Логика взаимодействия для EffectListPage.xaml
    /// </summary>
    public partial class EffectListPage : Page
    {
        public EffectListPage()
        {
            InitializeComponent();

            CbSort.Items.Add("По умолчанию");
            CbSort.Items.Add("По алфавиту");
            CbSort.Items.Add("Все положительные");
            CbSort.Items.Add("Все отрицательные");
            CbSort.SelectedIndex = 0;

        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Effect> items = App.DB.Effect.ToList();
            if (CbSort.SelectedIndex == 1)
            {
                items = items.OrderBy(x => x.Name);
            }
            else if (CbSort.SelectedIndex == 2)
            {
                items = items.Where(x => x.IsBuff == true);
            }
            else if (CbSort.SelectedIndex == 3)
            {
                items = items.Where(x => x.IsBuff == false);
            }
            if (TbSearch.Text.Length > 0)
            {
                items = items.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()));
            }

            LvEffects.ItemsSource = items;

            if (LvEffects.Items.Count > 0)
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvEffects.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
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
