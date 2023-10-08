using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для KillerRoulette.xaml
    /// </summary>
    public partial class KillerRoulette : Page
    {
        public KillerRoulette()
        {
            InitializeComponent(); SetContext();
        }
        private void SpinButton_Click(object sender, RoutedEventArgs e)
        {
            StartAnimation();
        }

        private void SetupList()
        {
            var list = new List<string>() { "Булат", "Динар", "Кирилл", "Никита", "Субудай" };
            double Angle = 360 / list.Count;
            double AngleBuff = Angle;
            foreach (var people in list)
            {

            }
        }

        public void StartAnimation()
        {
            Random random = new Random();
            transform.BeginAnimation(RotateTransform.AngleProperty,
            new DoubleAnimation
            {
                From = 0,
                To = random.Next(720, 720 * 3),
                Duration = TimeSpan.FromSeconds(10),
                DecelerationRatio = 0.25

            });

        }


        private void SetContext()
        {
            var list = App.DB.Users.ToList();

            var image = System.Drawing.Image.FromFile("C:\\Users\\grosf\\OneDrive\\Рабочий стол\\sd\\yan.png"); // or wherever it comes from
            var bitmap = new System.Drawing.Bitmap(image);
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bitmap.Dispose();
            var brush = new ImageBrush(bitmapSource);

            foreach (var people in list)
            {
                PieChartGraph.Series.Add(new PieSeries()
                {
                    Title = people.Name,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(people.PieValue) },
                    DataLabels = true,
                    LabelPoint = point => people.Name,
                    FontSize = 20,
                });
            }

            DataContext = this;
        }
    }
}
