using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.Properties;
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
    /// Логика взаимодействия для LocationsListPage.xaml
    /// </summary>
    public partial class LocationsListPage : Page
    {
        LoadingControl contextContentLoader;
        public bool FirstTry;
        public LocationsListPage(LoadingControl loadingControl)
        {
            InitializeComponent();

            CbSort.Items.Add("Самые новые");
            CbSort.Items.Add("Самые ранние");
            contextContentLoader = loadingControl;
            DataContext = new LocationListViewModel();
            if(Settings.Default.ThemeCode == 2)
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
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void LvLocations_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (FirstTry == true)
            {
                contextContentLoader.StopAnimation();
            }
            else
            {
                FirstTry = true;
            }

            if (LvLocations.Items.Count == 0)
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvLocations.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
        }
    }
}
