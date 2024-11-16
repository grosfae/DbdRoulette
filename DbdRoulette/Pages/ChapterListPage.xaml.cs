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
        LoadingControl contextContentLoader;
        public ChapterListPage(LoadingControl loadingControl)
        {
            InitializeComponent();
            CbSort.Items.Add("Самые новые");
            CbSort.Items.Add("Самые ранние");
            contextContentLoader = loadingControl;
            DataContext = new ChapterListViewModel();
        }

        private void ChapterBlockElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as UserControl).DataContext as Chapter;
            NavigationService.Navigate(new ChapterViewPage(selectedItem));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void LvChapters_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (LvChapters.Items.Count == 0)
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvChapters.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
        }

        private void LvChapters_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (LvChapters.Visibility == Visibility.Visible)
            {
                contextContentLoader.StopAnimation();
            }
        }
    }
}
