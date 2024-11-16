using DbdRoulette.Components;
using DbdRoulette.Pages;
using DbdRoulette.Properties;
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
    /// Логика взаимодействия для MapSlider.xaml
    /// </summary>
    public partial class MapSlider : UserControl
    {
        Map contextMap;

        List<byte[]> MapGalleryImages = new List<byte[]>();

        int maxPage = 0;
        int numberPage = 0;
        int count = 1;
        int fakePage = 1;
        public MapSlider()
        {
            InitializeComponent();
            if (Settings.Default.ThemeCode == 2)
            {
                LineSep.Fill = MiscUtilities.HauntedThemeCyanBrush;
                VerticalBorder.BorderBrush = MiscUtilities.HauntedThemeCyanBrush;
                HorizontalBorder.BorderBrush = MiscUtilities.HauntedThemeCyanBrush;
            }
            if (Settings.Default.ThemeCode == 3)
            {
                LineSep.Fill = MiscUtilities.AnniversaryThemeGoldenBrush;
                VerticalBorder.BorderBrush = MiscUtilities.AnniversaryThemeGoldenBrush;
                HorizontalBorder.BorderBrush = MiscUtilities.AnniversaryThemeGoldenBrush;
            }

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            contextMap = DataContext as Map;
            FillList();
            if (MapGalleryImages.Count > 0)
            {
                maxPage = MapGalleryImages.Count;
            }
        }
        private void FillList()
        {
            foreach (var item in App.DB.MapGallery.Where(x => x.MapId == contextMap.Id))
            {
                MapGalleryImages.Add(item.Screenshot);
            }
        }
        private void Refresh()
        {
            List<byte[]> bytes = MapGalleryImages.ToList();
            if (bytes.Count() > count)
            {
                if (bytes.Count() % count > 0)
                {
                    maxPage = (MapGalleryImages.Count / count) + 1;
                }
                else
                {
                    maxPage = MapGalleryImages.Count / count;
                }
            }
            else
            {
                maxPage = 1;
            }
            if (fakePage > maxPage)
            {
                fakePage = maxPage;
            }

            bytes = MapGalleryImages.Skip(count * numberPage).Take(count).ToList();
            LvSlider.ItemsSource = bytes.ToList();
        }

        private void AnimListview()
        {
            var animationOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),

            };
            LvSlider.BeginAnimation(ListView.OpacityProperty, animationOpacity);
        }
        private void DotStackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as StackPanel).Children.Clear();
            for (int i = 1; i <= maxPage; i++)
            {
                RadioButton btn = new RadioButton
                {
                    Content = i,
                    Width = 10,
                    Height = 10,
                    Margin = new Thickness(3, 0, 3, 0),
                };
                btn.Checked += RadioButton_Checked;
                Style style = this.FindResource("DotPictureSelectRadio") as Style;
                btn.Style = style;
                (sender as StackPanel).Children.Add(btn);

                if (int.Parse(btn.Content.ToString()) == fakePage)
                {
                    btn.IsChecked = true;
                }
            }

        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            int realPageNumber = int.Parse(radioButton.Content.ToString()) - 1;
            numberPage = realPageNumber;
            fakePage = int.Parse(radioButton.Content.ToString());
            Refresh();
            AnimListview();
        }
        private void RightListBtn_Click(object sender, RoutedEventArgs e)
        {
            numberPage++;
            fakePage++;
            if (numberPage == maxPage)
            {
                numberPage = maxPage - 1;
                fakePage--;
            }
            else
            {
                AnimListview();
            }

            if (fakePage < maxPage + 1)
            {
                Refresh();
                foreach (var child in DotStackPanel.Children)
                {
                    var radioButton = (child as RadioButton);
                    if (int.Parse(radioButton.Content.ToString()) == fakePage)
                    {
                        radioButton.IsChecked = true;
                    }
                }
            }
        }

        private void LeftListBtn_Click(object sender, RoutedEventArgs e)
        {
            numberPage--;
            fakePage--;
            if (numberPage < 0)
                numberPage = 0;
            if (fakePage < 1)
                fakePage = 1;
            else
            {
                AnimListview();
            }
            Refresh();
            foreach (var child in DotStackPanel.Children)
            {
                var radioButton = (child as RadioButton);
                if (int.Parse(radioButton.Content.ToString()) == fakePage)
                {
                    radioButton.IsChecked = true;
                }

            }
        }

        private void UcGlobal_MouseEnter(object sender, MouseEventArgs e)
        {
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),
            };
            LineSep.BeginAnimation(Rectangle.OpacityProperty, animation);
            transformSide.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
            transformUpDown.BeginAnimation(ScaleTransform.ScaleXProperty, animation);


        }

        private void UcGlobal_MouseLeave(object sender, MouseEventArgs e)
        {
            var animation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2),
            };

            LineSep.BeginAnimation(Rectangle.OpacityProperty, animation);
            transformSide.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
            transformUpDown.BeginAnimation(ScaleTransform.ScaleXProperty, animation);

        }

        private void UcGlobal_Unloaded(object sender, RoutedEventArgs e)
        {
            maxPage = 1;
        }

        private void ChapterLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ChapterViewPage(contextMap.Chapter));
        }
    }
}
