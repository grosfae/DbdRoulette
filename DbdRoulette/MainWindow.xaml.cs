using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Defaults;
using LiveCharts.Wpf.Charts.Base;
using System.Windows.Interop;
using DbdRoulette.Pages;

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
            MainFrame.Navigate(new KillerListPage());

            var ThemeCode = Properties.Settings.Default.ThemeCode;
            if (ThemeCode == 2)
            {
                GeneralBackground.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/HauntedTheme/KeyArt.jpg"));
                PumpkinsGrid.Visibility = Visibility.Visible;
                HeaderHauntedLine.Visibility = Visibility.Visible;
                StartPumpkinAnimation();
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
        private void MinButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

            });
        }
    }
}
