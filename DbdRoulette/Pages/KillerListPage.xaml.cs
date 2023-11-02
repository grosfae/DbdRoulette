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
    /// Логика взаимодействия для KillerListPage.xaml
    /// </summary>
    public partial class KillerListPage : Page
    {
        public KillerListPage()
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


            LvCharacters.BeginAnimation(ListView.OpacityProperty, animationOpacity);

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

            LvCharacters.BeginAnimation(ListView.OpacityProperty, animationOpacity);

            CbSort.Items.Clear();

            CbSort.Items.Add("Самые новые");
            CbSort.Items.Add("Самые ранние");

            CbSort.SelectedIndex = 0;


        }
        private void TbSelectedCharacterBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as TextBox).DataContext as Killer;
            //NavigationService.Navigate(new CharacterViewPage(selectedItem));
        }

        private void RefreshKillers()
        {
            IEnumerable<KillerChapter> killerChapters = App.DB.KillerChapter.ToList();
            if(CbSort.SelectedIndex == 0)
            {
                killerChapters = killerChapters.OrderByDescending(x => x.Сhapter.DateRelease);
            }
            else if(CbSort.SelectedIndex == 1)
            {
                killerChapters = killerChapters.OrderBy(x => x.Сhapter.DateRelease);
            }
            else if (CbSort.SelectedIndex == 2)
            {
                killerChapters = killerChapters.Where(x => x.Killer.DifficultyId == 1);
            }
            else if (CbSort.SelectedIndex == 3)
            {
                killerChapters = killerChapters.Where(x => x.Killer.DifficultyId == 2);
            }
            else if (CbSort.SelectedIndex == 4)
            {
                killerChapters = killerChapters.Where(x => x.Killer.DifficultyId == 3);
            }
            else if (CbSort.SelectedIndex == 5)
            {
                killerChapters = killerChapters.Where(x => x.Killer.DifficultyId == 4);
            }
            if(TbSearch.Text.Length > 0)
            {
                killerChapters = killerChapters.Where(x => x.Killer.Name.ToLower().Contains(TbSearch.Text.ToLower()));
            }
            LvCharacters.ItemsSource = killerChapters;
        }
        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshKillers();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshKillers();
        }

    }
}
