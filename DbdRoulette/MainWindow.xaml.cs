using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using DbdRoulette.Pages;
using DbdRoulette.Addons;
using System.Media;

namespace DbdRoulette
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Head.MouseLeftButtonDown += new MouseButtonEventHandler(Window_MouseDown);

            ContentLoader.StopAnimation();
            
            MainFrame.Navigate(new MainPage());

            var ThemeCode = Properties.Settings.Default.ThemeCode;
            if (ThemeCode == 2)
            {
                this.BorderBrush = MiscUtilities.HauntedThemeCyanBrush;
                PopupSeparator.Background = MiscUtilities.HauntedThemeCyanBrush;
                GeneralBackground.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/HauntedTheme/KeyArt.jpg"));
                Icon = new BitmapImage(new Uri("pack://application:,,,/Resources/HauntedTheme/HauntedThemeIcon.ico"));
                CharacterListRect.Fill = new SolidColorBrush(Colors.DarkSlateGray);
                PerkPageRect.Fill = new SolidColorBrush(Colors.DarkSlateGray);
                ItemListRect.Fill = new SolidColorBrush(Colors.DarkSlateGray);
                PowerListRect.Fill = new SolidColorBrush(Colors.DarkSlateGray);
                EffectListRect.Fill = new SolidColorBrush(Colors.DarkSlateGray);
                PumpkinsGrid.Visibility = Visibility.Visible;
                HeaderHauntedLine.Visibility = Visibility.Visible;
                StartPumpkinAnimation();
            }
            if (ThemeCode == 3)
            {
                this.BorderBrush = MiscUtilities.AnniversaryThemeGoldenBrush;
                Head.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/AnniversaryTheme/HeaderAnniversaryBackground.jpg")));
                LogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/AnniversaryTheme/AnniversaryLogo.png"));
                PopupSeparator.Background = MiscUtilities.AnniversaryThemeGoldenBrush;
                GeneralBackground.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/AnniversaryTheme/AnniversaryThemeBackground.jpg"));
                Icon = new BitmapImage(new Uri("pack://application:,,,/Resources/AnniversaryTheme/AnniversaryThemeIcon.ico"));
                CharacterListRect.Fill = MiscUtilities.SpecialBlack;
                PerkPageRect.Fill = MiscUtilities.SpecialBlack;
                ItemListRect.Fill = MiscUtilities.SpecialBlack;
                PowerListRect.Fill = MiscUtilities.SpecialBlack;
                EffectListRect.Fill = MiscUtilities.SpecialBlack;
                TryksEyeGrid.Visibility = Visibility.Visible;
                StartEyeGlow();
            }

        }
        public void StartPumpkinAnimation()
        {
            PumpLeft.BeginAnimation(TranslateTransform.YProperty,
            new DoubleAnimation
            {
                From = 0,
                To = -15,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.FromSeconds(5),
                AutoReverse = true
            });
            PumpRight.BeginAnimation(TranslateTransform.YProperty,
            new DoubleAnimation
            {
                From = 0,
                To = 10,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.FromSeconds(5),
                AutoReverse = true
            });
        }
        public void StartEyeGlow()
        {
            GlowEllipse.BeginAnimation(OpacityProperty,
            new DoubleAnimation
            {
                From = 0,
                To = 1,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.FromSeconds(5),
                EasingFunction = new BounceEase() {Bounces = 10, EasingMode = EasingMode.EaseIn },
                AutoReverse = true
            });
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is SettingsPage)
            {
                return;
            }
            else
            {
                MainFrame.Navigate(new SettingsPage());
            }

        }
        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.XButton1 || e.ChangedButton == MouseButton.XButton2)
            {
                e.Handled = true;
            }
        }
        private void CharactersBtn_Checked(object sender, RoutedEventArgs e)
        {
            transform.BeginAnimation(ScaleTransform.ScaleYProperty,
            new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
            });
        }

        private void CharactersBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            transform.BeginAnimation(ScaleTransform.ScaleYProperty,
            new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
            });
        }
        private void CharacterListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is CharacterListPage)
            {
                return;
            }
            else
            {
                ContentLoader.StartAnimation();
                MainFrame.Navigate(new CharacterListPage(ContentLoader));
            }
        }

        private void DLCViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is ChapterListPage)
            {
                return;
            }
            else
            {
                ContentLoader.StartAnimation();
                MainFrame.Navigate(new ChapterListPage(ContentLoader));
            }
        }

        private void PerkPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is PerkListPage)
            {
                return;
            }
            else
            {
                ContentLoader.StartAnimation();
                MainFrame.Navigate(new PerkListPage(ContentLoader));
            }
        }

        private void ItemListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is ItemListPage)
            {
                return;
            }
            else
            {
                ContentLoader.StartAnimation();
                MainFrame.Navigate(new ItemListPage(ContentLoader));
            }
        }

        private void PowerListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is PowerListPage)
            {
                return;
            }
            else
            {
                ContentLoader.StartAnimation();
                MainFrame.Navigate(new PowerListPage(ContentLoader));
            }
        }

        private void EffectListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is EffectListPage)
            {
                return;
            }
            else
            {
                ContentLoader.StartAnimation();
                MainFrame.Navigate(new EffectListPage(ContentLoader));
            }
        }

        private void LocationViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is LocationsListPage)
            {
                return;
            }
            else
            {
                ContentLoader.StartAnimation();
                MainFrame.Navigate(new LocationsListPage(ContentLoader));
            }
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is MainPage)
            {
                return;
            }
            else
            {
                MainFrame.Navigate(new MainPage());
            }
        }

        private void RoulettesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is RoulettePage)
            {
                return;
            }
            else
            {
                MainFrame.Navigate(new RoulettePage());
            }
        }

    }
}
