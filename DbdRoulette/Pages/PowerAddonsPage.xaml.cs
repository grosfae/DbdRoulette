using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.Properties;
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
    /// Логика взаимодействия для PowerAddonsPage.xaml
    /// </summary>
    public partial class PowerAddonsPage : Page
    {
        object contextPower;
        public PowerAddonsPage(Object power)
        {
            InitializeComponent();
            contextPower = power;
            LvPowers.ItemsSource = App.DB.Power.ToList();
            LvAddons.ItemsSource = App.DB.PowerAddon.Where(x => x.Addon.ItemTypeId == 8).OrderBy(x => x.Addon.RarityId).OrderBy(x => x.PowerId).ToList();
            if (Settings.Default.ThemeCode == 2)
            {
                RecGradient.Fill = MiscUtilities.HauntedThemeCyanBrush;
            }
            if (Settings.Default.ThemeCode == 3)
            {
                RecGradient.Fill = MiscUtilities.AnniversaryThemeGoldenBrush;
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
        private void PowerBtn_Checked(object sender, RoutedEventArgs e)
        {
            var selectedPower = (sender as RadioButton).DataContext as Power;
            LvAddons.ItemsSource = App.DB.PowerAddon.Where(x => x.PowerId == selectedPower.Id).OrderBy(x => x.Addon.RarityId).OrderBy(x => x.Addon.Name).ToList();
        }

        private void PowerBtn_Loaded(object sender, RoutedEventArgs e)
        {
            var currentPower = (sender as RadioButton).DataContext as Power;
            if (currentPower == contextPower)
            {
                (sender as RadioButton).IsChecked = true;
            }
        }
    }
}
