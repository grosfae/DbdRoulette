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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для SliderPage.xaml
    /// </summary>
    public partial class SliderPage : Page
    {
        public SliderPage()
        {
            InitializeComponent();
            foreach (var item in App.DB.Perk)
            {
                LvPerks.Items.Add(item);
            }
           
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

        private void RadioPerkBtn_Checked(object sender, RoutedEventArgs e)
        {
            var selectedPerk = (sender as RadioButton).DataContext as Perk;
            MainImage.Source = ImageConvert(selectedPerk.DemoImage);
            LvPerks.SelectedItem = selectedPerk;
            
            if(LvPerks.SelectedIndex == 0)
            {
                LvPerks.Items.Insert(0 , LvPerks.Items[LvPerks.Items.Count - 1]);
                LvPerks.Items.RemoveAt(LvPerks.Items.Count - 1);
                LvPerks.Items.Insert(0 , LvPerks.Items[LvPerks.Items.Count - 1]);
                LvPerks.Items.RemoveAt(LvPerks.Items.Count - 1);

            }
            if (LvPerks.SelectedIndex == 1)
            {
                LvPerks.Items.Insert(0, LvPerks.Items[LvPerks.Items.Count - 1]);
                LvPerks.Items.RemoveAt(LvPerks.Items.Count - 1);
            }
            if (LvPerks.SelectedIndex == 3)
            {
                LvPerks.Items.Add(LvPerks.Items[0]);
                LvPerks.Items.RemoveAt(0);
            }
            if (LvPerks.SelectedIndex == 4)
            {
                LvPerks.Items.Add(LvPerks.Items[0]);
                LvPerks.Items.RemoveAt(0);
                LvPerks.Items.Add(LvPerks.Items[0]);
                LvPerks.Items.RemoveAt(0);

            }

        }

        private void RadioPerkBtn_Initialized(object sender, EventArgs e)
        {
            if (LvPerks.SelectedIndex == 0)
            {
                (sender as RadioButton).BeginAnimation(ScaleTransform.ScaleYProperty,
                new DoubleAnimation
                {
                   From = 0,
                   To = 1,
                   Duration = TimeSpan.FromSeconds(0.2),

                });

            }
        }
    }
}
