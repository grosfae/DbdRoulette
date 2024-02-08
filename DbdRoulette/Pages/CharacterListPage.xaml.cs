using DbdRoulette.Addons;
using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для CharacterListPage.xaml
    /// </summary>
    public partial class CharacterListPage : Page
    {
        public CharacterListPage()
        {
            InitializeComponent();
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

            CbSort.SelectedIndex = 0;

            RefreshKillers();
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

            RefreshSurvivors();
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

        private void RefreshKillers()
        {
            IEnumerable<Killer> killers = App.DB.Killer.ToList();
            if(CbSort.SelectedIndex == 0)
            {
                killers = killers.OrderByDescending(x => x.Сhapter.DateRelease);
            }
            else if(CbSort.SelectedIndex == 1)
            {
                killers = killers.OrderBy(x => x.Сhapter.DateRelease);
            }
            else if (CbSort.SelectedIndex == 2)
            {
                killers = killers.Where(x => x.DifficultyId == 1);
            }
            else if (CbSort.SelectedIndex == 3)
            {
                killers = killers.Where(x => x.DifficultyId == 2);
            }
            else if (CbSort.SelectedIndex == 4)
            {
                killers = killers.Where(x => x.DifficultyId == 3);
            }
            else if (CbSort.SelectedIndex == 5)
            {
                killers = killers.Where(x => x.DifficultyId == 4);
            }
            if(TbSearch.Text.Length > 0)
            {
                killers = killers.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()));
            }
            LvCharacters.ItemsSource = killers;
            if(LvCharacters.Items.Count > 0)
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvCharacters.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
        }

        private void RefreshSurvivors()
        {
            IEnumerable<Survivor> survivors = App.DB.Survivor.ToList();
            if (CbSort.SelectedIndex == 0)
            {
                survivors = survivors.OrderByDescending(x => x.Сhapter.DateRelease);
            }
            else if (CbSort.SelectedIndex == 1)
            {
                survivors = survivors.OrderBy(x => x.Сhapter.DateRelease);
            }
            if (TbSearch.Text.Length > 0)
            {
                survivors = survivors.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()));
            }
            LvCharacters.ItemsSource = survivors;

            LvCharacters.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
        }
        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RadioKiller.IsChecked == true)
            {
                RefreshKillers();
            }
            if (RadioSurvivor.IsChecked == true)
            {
                RefreshSurvivors();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RadioKiller.IsChecked == true)
            {
                RefreshKillers();
            }
            if (RadioSurvivor.IsChecked == true)
            {
                RefreshSurvivors();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
    }
}
