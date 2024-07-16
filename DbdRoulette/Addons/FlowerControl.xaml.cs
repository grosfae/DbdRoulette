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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Addons
{
    /// <summary>
    /// Логика взаимодействия для FlowerControl.xaml
    /// </summary>
    public partial class FlowerControl : UserControl
    {
        public FlowerControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MainToggle_Checked(object sender, RoutedEventArgs e)
        {
            FirstGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = -150,
                EasingFunction = new CircleEase {EasingMode = EasingMode.EaseOut},
                Duration = TimeSpan.FromSeconds(0.5)
            });
            FirstGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = -100,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(0.5)
            });

            SecondGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = 150,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(0.8)
            });

            SecondGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = -100,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(0.8)
            });


            ThirdGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = 150,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(1.0)
            });
            ThirdGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = 100,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(1.0)
            });

            FourthGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = -150,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(1.2)
            });
            FourthGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = 100,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(1.2)
            });
        }

        private void MainToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            FirstGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(0.5)
            });
            FirstGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(0.5)
            });

            SecondGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(0.8)
            });

            SecondGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(0.8)
            });


            ThirdGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(1.0)
            });
            ThirdGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(1.0)
            });

            FourthGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(1.2)
            });
            FourthGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                To = 0,
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn },
                Duration = TimeSpan.FromSeconds(1.2)
            });
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as StackPanel).RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation
            {
                From = -SystemParameters.PrimaryScreenHeight,
                To = 0,
                
                Duration = TimeSpan.FromSeconds(1.2)
            });
        }
    }
}
