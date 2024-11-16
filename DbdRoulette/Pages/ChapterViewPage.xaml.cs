using DbdRoulette.Addons;
using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ChapterViewPage.xaml
    /// </summary>
    public partial class ChapterViewPage : Page
    {
        Chapter contextChapter;
        List<Perk> Images = new List<Perk>();
        public ChapterViewPage(Chapter chapter)
        {
            InitializeComponent();
            contextChapter = chapter;
            DataContext = contextChapter;
            LvKillers.ItemsSource = contextChapter.Killer;
            LvSurvivors.ItemsSource = contextChapter.Survivor;

            var ThemeCode = Properties.Settings.Default.ThemeCode;
            if (ThemeCode == 2)
            {
                HauntedLine.Visibility = Visibility.Visible;
                //GridMapImageSource.ImageSource = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/HauntedTheme/SectionBackground.jpg"));
                //PresentImageBtn.Foreground = MiscUtilities.HauntedThemeCyanBrush;
                //MapRectangle.Fill = MiscUtilities.HauntedThemeCyanBrush;
            }
            if (ThemeCode == 3)
            {
                //GridMapImageSource.ImageSource = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/AnniversaryTheme/AnniversaryMapBackground.jpg"));
                //PresentImageBtn.Foreground = MiscUtilities.AnniversaryThemeGoldenBrush;
                //MapRectangle.Fill = MiscUtilities.AnniversaryThemeGoldenBrush;
            }

            if (contextChapter.Survivor.Count > 0)
            {
                RecGradient.Fill = MiscUtilities.SurvivorBrush;
            }

            if (contextChapter.Killer.Count == 0)
            {
                RectangleTop.Fill = MiscUtilities.SurvivorBrush;
            } 

            if (contextChapter.ChapterCharm.Count > 0)
            {
                StCharm.Visibility = Visibility.Visible;
                var chapterCharm = contextChapter.ChapterCharm.FirstOrDefault();
                CharmIcon.Source = MiscUtilities.ImageConvert(chapterCharm.Charm.MainIcon);
                CharmName.Text = chapterCharm.Charm.Name;
                CharmDescription.Text = chapterCharm.Charm.Description;
            }

            
            //var chapterMap = contextChapter.Map.FirstOrDefault();
            //if (chapterMap != null)
            //{
            //    GridMap.Visibility = Visibility.Visible;
            //    MapName.Text = chapterMap.Name;
            //    MapDescription.Text = chapterMap.Description;
            //    MapSlider.DataContext = chapterMap;
            //}

            //GalleryLoad();

            GlobalStackPanel.BeginAnimation(StackPanel.OpacityProperty, MiscUtilities.AppearOpacityAnimation);

        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        //private void GalleryLoad()
        //{
        //    if (contextChapter.Killer.Count > 0)
        //    {
        //        foreach (var killer in contextChapter.Killer)
        //        {
        //            if (killer.KillerPerk.Count > 0)
        //            {
        //                foreach (var killerPerk in killer.KillerPerk)
        //                {
        //                    Images.Add(killerPerk.Perk);

        //                }
        //                break;
        //            }

        //        }
        //    }
        //    if (contextChapter.Survivor.Count > 0)
        //    {
        //        foreach (var survivor in contextChapter.Survivor)
        //        {
        //            if (survivor.SurvivorPerk.Count > 0)
        //            {
        //                foreach (var survivorPerk in survivor.SurvivorPerk)
        //                {
        //                    Images.Add(survivorPerk.Perk);
        //                }
        //                break;
        //            }
        //        }

        //    }
        //    foreach (var item in Images)
        //    {
        //        LvGallery.Items.Add(item);
        //    }

        //}

        //private void RadioGalleryBtn_Checked(object sender, RoutedEventArgs e)
        //{
        //    var selectedPerk = (sender as RadioButton).DataContext as Perk;
        //    MainImage.ImageSource = MiscUtilities.ImageConvert(selectedPerk.DemoImage);
        //    LvGallery.SelectedItem = selectedPerk;
        //    LvGallery.RenderTransform = new TranslateTransform();


        //    var easing = new QuarticEase
        //    {
        //        EasingMode = EasingMode.EaseInOut
        //    };

        //    var animationOpacity = new DoubleAnimation
        //    {
        //        From = 0,
        //        To = 1,
        //        Duration = TimeSpan.FromSeconds(0.3),

        //    };

        //    var animationDown = new DoubleAnimation
        //    {
        //        From = 0,
        //        To = -50,
        //        Duration = TimeSpan.FromSeconds(0.3),
        //        AutoReverse = true,
        //        EasingFunction = easing

        //    };
        //    var animationUp = new DoubleAnimation
        //    {
        //        From = 0,
        //        To = 50,
        //        AutoReverse = true,
        //        Duration = TimeSpan.FromSeconds(0.3),
        //        EasingFunction = easing

        //    };

        //    MainImage.BeginAnimation(ImageBrush.OpacityProperty, animationOpacity);
        //    if (LvGallery.SelectedIndex == 0)
        //    {
        //        LvGallery.Items.Insert(0, LvGallery.Items[LvGallery.Items.Count - 1]);
        //        LvGallery.Items.RemoveAt(LvGallery.Items.Count - 1);
        //        LvGallery.Items.Insert(0, LvGallery.Items[LvGallery.Items.Count - 1]);
        //        LvGallery.Items.RemoveAt(LvGallery.Items.Count - 1);
        //        LvGallery.RenderTransform.BeginAnimation(TranslateTransform.YProperty, animationUp);
        //        LvGallery.BeginAnimation(ListView.OpacityProperty, animationOpacity);

        //    }
        //    if (LvGallery.SelectedIndex == 1)
        //    {
        //        LvGallery.Items.Insert(0, LvGallery.Items[LvGallery.Items.Count - 1]);
        //        LvGallery.Items.RemoveAt(LvGallery.Items.Count - 1);
        //        LvGallery.RenderTransform.BeginAnimation(TranslateTransform.YProperty, animationUp);
        //        LvGallery.BeginAnimation(ListView.OpacityProperty, animationOpacity);
        //    }
        //    if (LvGallery.SelectedIndex == 3)
        //    {
        //        LvGallery.Items.Add(LvGallery.Items[0]);
        //        LvGallery.Items.RemoveAt(0);
        //        LvGallery.RenderTransform.BeginAnimation(TranslateTransform.YProperty, animationDown);
        //        LvGallery.BeginAnimation(ListView.OpacityProperty, animationOpacity);
        //    }
        //    if (LvGallery.SelectedIndex == 4)
        //    {
        //        LvGallery.Items.Add(LvGallery.Items[0]);
        //        LvGallery.Items.RemoveAt(0);
        //        LvGallery.Items.Add(LvGallery.Items[0]);
        //        LvGallery.Items.RemoveAt(0);
        //        LvGallery.RenderTransform.BeginAnimation(TranslateTransform.YProperty, animationDown);
        //        LvGallery.BeginAnimation(ListView.OpacityProperty, animationOpacity);
        //    }

        //}
        //private void LvGallery_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (LvGallery.Items.Count > 0)
        //    {
        //        ListViewItem item = LvGallery.ItemContainerGenerator.ContainerFromIndex(2) as ListViewItem;
        //        if (item != null)
        //        {
        //            var radioButton = MiscUtilities.FindVisualChild<RadioButton>(item);
        //            radioButton.IsChecked = true;
        //        }
        //    }
        //}

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            var objectData = (sender as Button).DataContext;
            NavigationService.Navigate(new CharacterViewPage(objectData));
        }
    }
}
