using DbdRoulette.Components;
using LiveCharts.Maps;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
    /// Логика взаимодействия для CharacterViewPage.xaml
    /// </summary>
    public partial class CharacterViewPage : Page
    {
        object contextCharacter;
        bool FirstPerkSelected = true;
        public CharacterViewPage(Object obj)
        {
            InitializeComponent();
            contextCharacter = obj;
            DataContext = contextCharacter;

            var animationOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1.0),

            };

            GlobalStackPanel.BeginAnimation(StackPanel.OpacityProperty, animationOpacity);

            var ThemeCode = Properties.Settings.Default.ThemeCode;
            if (ThemeCode == 2)
            { 
                HauntedLine.Visibility = Visibility.Visible;
            }

            if (contextCharacter is Survivor)
            {

                LvPerks.ItemsSource = (contextCharacter as Survivor).SurvivorPerk.ToList();
                
                
                
                ColorTitleGrid.Background = new SolidColorBrush(Color.FromRgb(45, 99, 161));
                ColorPolyDarkStop.Color = Color.FromRgb(29, 67, 120);
                ColorPolyLightStop.Color = Color.FromRgb(45, 99, 161);

                RoleIcon.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/SurvIcon.png"));
                RoleTitle.Text = "Выживший";

                StDifficulty.Visibility = Visibility.Collapsed;
                TbDiaryLetter.Visibility = Visibility.Visible;
                StTerrorRadius.Visibility = Visibility.Collapsed;
                StMoveSpeed.Visibility = Visibility.Collapsed;
                StHeight.Visibility = Visibility.Collapsed;

                PowerAndPerksHeader.Text = "НАВЫКИ";

                PerkDemoBtn.Foreground = new SolidColorBrush(Color.FromRgb(45, 99, 161));

                RadioPower.Visibility = Visibility.Collapsed;
                LineSep.Fill = new SolidColorBrush(Color.FromRgb(45, 99, 161));

                RecGradient.Fill = new SolidColorBrush(Color.FromRgb(45, 99, 161));
                RecGradientBottom.Fill = new SolidColorBrush(Color.FromRgb(45, 99, 161));

                LineSepChapter.Fill = new SolidColorBrush(Color.FromRgb(45, 99, 161));

                ChapterViewBtn.Style = this.FindResource("ChapterBlueBtn") as Style;
            }
            else
            {
                RadioPower.IsChecked = true;
                LvPerks.ItemsSource = (contextCharacter as Killer).KillerPerk.ToList();
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RadioPerkBtn_Checked(object sender, RoutedEventArgs e)
        {
            var animationOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),

            };

            if (contextCharacter is Survivor)
            {
                var selectedItem = (sender as RadioButton).DataContext as SurvivorPerk;
                PerksDemoImage.ImageSource = ImageConvert(selectedItem.Perk.DemoImage);
                TbTitlePerk.Text = selectedItem.Perk.Name;
                TbPerkDescription.Text = selectedItem.Perk.Description;
            }
            else
            {
                var selectedItem = (sender as RadioButton).DataContext as KillerPerk;
                PerksDemoImage.ImageSource = ImageConvert(selectedItem.Perk.DemoImage);
                TbTitlePerk.Text = selectedItem.Perk.Name;
                TbPerkDescription.Text = selectedItem.Perk.Description;
            }
            TbTypeHeader.Text = "Навык";
            PerksDemoImage.BeginAnimation(ImageBrush.OpacityProperty, animationOpacity);
            PerkDetailsContainer.BeginAnimation(StackPanel.OpacityProperty, animationOpacity);
            
            
        }

        private BitmapImage ImageConvert(byte[] convertableImage)
        {
            var image = new BitmapImage();
            using (var mem = new MemoryStream(convertableImage))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void RadioPower_Checked(object sender, RoutedEventArgs e)
        {
            var character = contextCharacter as Killer;
            TbTypeHeader.Text = "Сила";
            PerksDemoImage.ImageSource = ImageConvert(character.Power.DemoImage);
            TbTitlePerk.Text = character.Power.Name;
            TbPerkDescription.Text = character.Power.Description;
        }

        private void ChapterViewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioPerkBtn_Initialized(object sender, EventArgs e)
        {
            if (contextCharacter is Survivor && FirstPerkSelected == true)
            {
                (sender as RadioButton).IsChecked = true;
                FirstPerkSelected = false;
            }
        }
    }
}
