using AngleSharp;
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
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для PerkListPage.xaml
    /// </summary>
    public partial class PerkListPage : Page
    {
        LoadingControl contextContentLoader;
        public bool FirstTry;

        public PerkListPage(LoadingControl loadingControl)
        {
            InitializeComponent();
            contextContentLoader = loadingControl;
            DataContext = new PerkListViewModel();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PerkFirst.DataContext = App.PerkShrineFirst;
            PerkSecond.DataContext = App.PerkShrineSecond;
            PerkThird.DataContext = App.PerkShrineThird;
            PerkFourth.DataContext = App.PerkShrineFourth;
            TbRefreshShrine.Text = App.RefreshShrineTimeOut;
        }

        private void TagSwitchBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            RecGradient.Fill = MiscUtilities.KillerBrush;
        }

        private void TagSwitchBtn_Checked(object sender, RoutedEventArgs e)
        {
            RecGradient.Fill = MiscUtilities.SurvivorBrush;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void LvPerks_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (FirstTry == true)
            {
                contextContentLoader.StopAnimation();
            }
            else
            {
                FirstTry = true;
            }

            if (LvPerks.Items.Count == 0)
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvPerks.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
        }
    }
}
