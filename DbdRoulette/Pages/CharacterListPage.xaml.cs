using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для CharacterListPage.xaml
    /// </summary>
    public partial class CharacterListPage : Page
    {
        LoadingControl contextContentLoader;
        public bool FirstTry;

        public CharacterListPage(LoadingControl loadingControl)
        {
            InitializeComponent();
            contextContentLoader = loadingControl;
            DataContext = new CharacterListViewModel();
            RadioKiller.IsChecked = true;
        }

        private void RadioKiller_Checked(object sender, RoutedEventArgs e)
        {
            PresentImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/KillerImage.jpg"));
            var animationOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1.5),

            };

            var animationBlur = new DoubleAnimation
            {
                From = 30,
                To = 0,
                Duration = TimeSpan.FromSeconds(1),

            };
            PresentImage.BeginAnimation(ImageBrush.OpacityProperty, animationOpacity);
            BlurRad.BeginAnimation(BlurBitmapEffect.RadiusProperty, animationBlur);

            RecGradient.Fill = MiscUtilities.KillerBrush;
            PresentImageBtn.Foreground = MiscUtilities.KillerBrush;

            CbSort.Items.Clear();

            CbSort.Items.Add("Самые новые");
            CbSort.Items.Add("Самые ранние");
            CbSort.Items.Add("Сложность - Легко");
            CbSort.Items.Add("Сложность - Умеренно");
            CbSort.Items.Add("Сложность - Тяжело");
            CbSort.Items.Add("Сложность - Очень тяжело");
        }

        private void RadioSurvivor_Checked(object sender, RoutedEventArgs e)
        {
            PresentImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/SurvivorImage.jpg"));

            var animationOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1.5),
            };

            var animationBlur = new DoubleAnimation
            {
                From = 30,
                To = 0,
                Duration = TimeSpan.FromSeconds(1),
            };

            PresentImage.BeginAnimation(ImageBrush.OpacityProperty, animationOpacity);
            BlurRad.BeginAnimation(BlurBitmapEffect.RadiusProperty, animationBlur);

            RecGradient.Fill = MiscUtilities.SurvivorBrush;

            PresentImageBtn.Foreground = MiscUtilities.SurvivorBrush;

            CbSort.Items.Clear();

            CbSort.Items.Add("Самые новые");
            CbSort.Items.Add("Самые ранние");

            CbSort.SelectedIndex = 0;

        }
        private void TbSelectedCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RadioKiller.IsChecked == true)
            {
                var selectedKiller = (sender as Button).DataContext as Killer;
                NavigationService.Navigate(new CharacterViewPage(selectedKiller));
            }
            else
            {
                var selectedSurvivor = (sender as Button).DataContext as Survivor;
                NavigationService.Navigate(new CharacterViewPage(selectedSurvivor));
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }


        private void LvCharacters_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (FirstTry == true)
            {
                contextContentLoader.StopAnimation();
            }
            else
            {
                FirstTry = true;
            }
            if (LvCharacters.Items.Count == 0)
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvCharacters.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
        }
    }
}
