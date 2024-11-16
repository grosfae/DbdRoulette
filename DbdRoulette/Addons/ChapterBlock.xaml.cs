using DbdRoulette.Components;
using DbdRoulette.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ChapterBlock.xaml
    /// </summary>
    public partial class ChapterBlock : UserControl
    {
        Chapter contextChapter;

        int maxPage = 0;
        int numberPage = 0;
        int count = 1;
        int fakePage = 1;

        private List<byte[]> Images = new List<byte[]>();
        private List<Killer> KillerList = new List<Killer> ();
        private List<Survivor> SurvivorList = new List<Survivor>();

        private string ChapterKillers = string.Empty;
        private string ChapterSurvivors = string.Empty;
        private string ChapterMap = string.Empty;
        private string ChapterCharm = string.Empty;
        public ChapterBlock()
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
        private void FillLists()
        {
            if(contextChapter.Killer.Count > 0)
            {
                foreach (var killer in contextChapter.Killer)
                {
                    KillerList.Add(killer);
                }
            }
            if(contextChapter.Survivor.Count > 0)
            {
                foreach (var survivor in contextChapter.Survivor)
                {
                    SurvivorList.Add(survivor);
                }
            }
        }
        private void FindChapterData()
        {
            FillLists();
            if (KillerList.Count == 1)
            {
                ChapterKillers = string.Format("Новый Убийца: {0}", KillerList.FirstOrDefault().Name);
            }
            else
            {
                ChapterKillers = string.Empty;
            }

            if (SurvivorList.Count == 1)
            {
                ChapterSurvivors = string.Format("Новый Выживший: {0}", SurvivorList.FirstOrDefault().Name);
            }
            else if (SurvivorList.Count > 1)
            {
                List<string> survivorNames = new List<string>();
                foreach (var survivor in SurvivorList)
                {
                    survivorNames.Add(survivor.Name);
                }
                ChapterSurvivors = $"Новые Выжившие: {string.Join(" и ", survivorNames)}";
            }
            else
            {
                ChapterSurvivors = string.Empty;
            }

            var Maps = contextChapter.Map;
            if (Maps.Count == 1)
            {
                ChapterMap = string.Format("Новая Локация: {0}", Maps.FirstOrDefault().Name);
            }
            else
            {
                ChapterMap = string.Empty;
            }

            var Charm = contextChapter.ChapterCharm;
            if (Charm.Count == 1)
            {
                ChapterCharm = string.Format("Новый Амулет: {0}", Charm.FirstOrDefault().Charm.Name);
            }
            else
            {
                ChapterCharm = string.Empty;
            }
        }
        private void ShowChapterData()
        {
            if (ChapterKillers.Length > 0)
            {
                TbKiller.Text = ChapterKillers;
                DecKiller.Visibility = Visibility.Visible;
            }
            else
            {
                DecKiller.Visibility = Visibility.Collapsed;
            }

            if (ChapterSurvivors.Length > 0)
            {
                TbSurvivor.Text = ChapterSurvivors;
                DecSurvivor.Visibility = Visibility.Visible;
            }
            else
            {
                DecSurvivor.Visibility = Visibility.Collapsed;
            }

            if (ChapterMap.Length > 0)
            {
                TbMap.Text = ChapterMap;
                DecMap.Visibility = Visibility.Visible;
            }
            else
            {
                DecMap.Visibility = Visibility.Collapsed;
            }

            if (ChapterCharm.Length > 0)
            {
                TbCharm.Text = ChapterCharm;
                DecCharm.Visibility = Visibility.Visible;
            }
            else
            {
                DecCharm.Visibility = Visibility.Collapsed;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            contextChapter = DataContext as Chapter;

            FindChapterData();
            ShowChapterData();

            if (contextChapter.MainImage != null)
            {
                Images.Add(contextChapter.MainImage);
            }
            if (KillerList.Count > 0)
            {
                foreach (var killer in KillerList)
                {
                    if (killer.KillerPerk.Count > 0)
                    {
                        foreach (var killerPerk in killer.KillerPerk)
                        {
                            if (killerPerk.Perk.DemoImage != null)
                            {
                                Images.Add(killerPerk.Perk.DemoImage);
                            }
                        }
                        break;
                    }
                }
            }
            if (SurvivorList.Count > 0)
            {
                foreach (var survivor in SurvivorList)
                {
                    if (survivor.SurvivorPerk.Count > 0)
                    {
                        foreach (var survivorPerk in survivor.SurvivorPerk)
                        {
                            if(survivorPerk.Perk.DemoImage != null)
                            {
                                Images.Add(survivorPerk.Perk.DemoImage);
                            }
                        }
                        break;
                    }
                }
            }

            if (Images.Count > 0)
            {
                maxPage = Images.Count;
            }
        }
        
        private void Refresh()
        {
            List<byte[]> bytes = Images.ToList();
            if (bytes.Count() > count)
            {
                if (bytes.Count() % count > 0)
                {
                    maxPage = (Images.Count / count) + 1;
                }
                else
                {
                    maxPage = Images.Count / count;
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

            bytes = Images.Skip(count * numberPage).Take(count).ToList();
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
            Images.Clear();
            maxPage = 1;
        }
    }
}
