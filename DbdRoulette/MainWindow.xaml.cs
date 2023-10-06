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
            SetupList();
        }

        private void SpinButton_Click(object sender, RoutedEventArgs e)
        {
            StartAnimation();
        }

        private void SetupList()
        {
            var list = new List<string>() {"Булат", "Динар", "Кирилл", "Никита", "Субудай"};
            double Angle = 360 / list.Count;
            double AngleBuff = Angle;
            foreach (var people in list)
            {
                CheckBox checkBox = new CheckBox();
                RotateTransform rotateTransform = new RotateTransform();
                ScaleTransform scaleTransform = new ScaleTransform(); 
                TransformGroup transformGroup = new TransformGroup();
                scaleTransform.ScaleY = 1;
                scaleTransform.ScaleX = 2;
                rotateTransform.Angle = AngleBuff;

                transformGroup.Children.Add(scaleTransform);
                transformGroup.Children.Add(rotateTransform);
                
                checkBox.Content = people;
                checkBox.RenderTransform = transformGroup;

                checkBox.Style = FindResource("Red_number") as Style;
                AngleBuff += Angle;
                RouletteGrid.Children.Add(checkBox);
            }
        }

        public void StartAnimation()
        {
            transform.BeginAnimation(RotateTransform.AngleProperty,
            new DoubleAnimation
            {
                From = 0,
                To = 1440,
                Duration = TimeSpan.FromSeconds(10),
                DecelerationRatio = 0.25           
                
            });
        }
    }
}
