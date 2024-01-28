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
    /// Логика взаимодействия для NothingFoundControl.xaml
    /// </summary>
    public partial class NothingFoundControl : UserControl
    {
        public NothingFoundControl()
        {
            InitializeComponent(); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation translateAnim = new DoubleAnimation { 
            From = 0,
            To = -30,
            Duration = TimeSpan.FromSeconds(5),
            BeginTime = TimeSpan.FromSeconds(2),
            };
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(2),
            };
            DoubleAnimation skewAnim = new DoubleAnimation
            {
                From = 20,
                To = 60,
                Duration = TimeSpan.FromSeconds(5),
                BeginTime = TimeSpan.FromSeconds(2),
            };
            //Storyboard storyboard = new Storyboard();
            //storyboard.Children.Add(scaleAnim);
            //storyboard.Children.Add(skewAnim);
            //storyboard.Children.Add(translateAnim);
            //storyboard.RepeatBehavior = RepeatBehavior.Forever;
            //storyboard.AutoReverse = true;

            //Storyboard.SetTargetProperty(scaleAnim, new PropertyPath(ScaleTransform.ScaleYProperty));
            //Storyboard.SetTargetProperty(skewAnim, new PropertyPath(SkewTransform.AngleXProperty));
            //Storyboard.SetTargetProperty(translateAnim, new PropertyPath(TranslateTransform.XProperty));

            //Storyboard.SetTarget(ScanRect, storyboard);

            //ScanRect.BeginStoryboard(storyboard);
        }
    }
}
