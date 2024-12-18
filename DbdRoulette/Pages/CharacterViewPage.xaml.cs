﻿using DbdRoulette.Addons;
using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharacterViewPage.xaml
    /// </summary>
    public partial class CharacterViewPage : Page
    {
        object contextCharacter;
        bool FirstPerkSelected = true;
        public CharacterViewPage(Object obj)
        {
            InitializeComponent();
            contextCharacter = obj;
            DataContext = contextCharacter;

            GlobalStackPanel.BeginAnimation(StackPanel.OpacityProperty, MiscUtilities.AppearOpacityAnimation);

            var ThemeCode = Properties.Settings.Default.ThemeCode;
            if (ThemeCode == 2)
            { 
                HauntedLine.Visibility = Visibility.Visible;
            }

            if (contextCharacter is Survivor)
            {
                if((contextCharacter as Survivor).ChapterId == 3)
                {
                    ChapterGrid.Visibility = Visibility.Collapsed;
                    ChapterSt.Visibility = Visibility.Hidden;
                }
                LvPerks.ItemsSource = (contextCharacter as Survivor).SurvivorPerk.ToList();
                
                ColorTitleGrid.Background = MiscUtilities.SurvivorBrush;
                ColorPolyDarkStop.Color = Color.FromRgb(29, 67, 120);
                ColorPolyLightStop.Color = Color.FromRgb(45, 99, 161);

                RoleIcon.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/SurvIcon.png"));
                RoleTitle.Text = "Выживший";

                StDifficulty.Visibility = Visibility.Collapsed;
                TbDiaryLetter.Visibility = Visibility.Visible;
                StTerrorRadius.Visibility = Visibility.Collapsed;
                StMoveSpeed.Visibility = Visibility.Collapsed;
                StHeight.Visibility = Visibility.Collapsed;

                PowerAndPerksHeader.Text = "НАВЫКИ";

                PerkDemoBtn.Foreground = MiscUtilities.SurvivorBrush;

                RadioPower.Visibility = Visibility.Collapsed;
                LineSep.Fill = MiscUtilities.SurvivorBrush;

                RecGradient.Fill = MiscUtilities.SurvivorBrush;
                RecGradientBottom.Fill = MiscUtilities.SurvivorBrush;

                LineSepChapter.Fill = MiscUtilities.SurvivorBrush;

                ChapterViewBtn.Style = this.FindResource("ChapterBlueBtn") as Style;
            }
            else
            {
                if ((contextCharacter as Killer).ChapterId == 3)
                {
                    ChapterGrid.Visibility = Visibility.Collapsed;
                    ChapterSt.Visibility = Visibility.Hidden;
                }
                RadioPower.IsChecked = true;
                LvPerks.ItemsSource = (contextCharacter as Killer).KillerPerk.ToList();
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void RadioPerkBtn_Checked(object sender, RoutedEventArgs e)
        {
            var animationOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),

            };

            if (contextCharacter is Survivor)
            {
                var selectedItem = (sender as RadioButton).DataContext as SurvivorPerk;
                if (selectedItem.Perk.DemoImage != null)
                {
                    PerksDemoImage.ImageSource = MiscUtilities.ImageConvert(selectedItem.Perk.DemoImage);
                }
                else
                {
                    PerksDemoImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/EmptyImage.jpg"));
                }
                TbTitlePerk.Text = selectedItem.Perk.Name;
                TbPerkDescription.Text = selectedItem.Perk.Description;
            }
            else
            {
                var selectedItem = (sender as RadioButton).DataContext as KillerPerk;
                if (selectedItem.Perk.DemoImage != null)
                {
                    PerksDemoImage.ImageSource = MiscUtilities.ImageConvert(selectedItem.Perk.DemoImage);
                }
                else
                {
                    PerksDemoImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/EmptyImage.jpg"));
                }
                TbTitlePerk.Text = selectedItem.Perk.Name;
                TbPerkDescription.Text = selectedItem.Perk.Description;
            }
            TbTypeHeader.Text = "Навык";
            PerksDemoImage.BeginAnimation(ImageBrush.OpacityProperty, animationOpacity);
            PerkDetailsContainer.BeginAnimation(StackPanel.OpacityProperty, animationOpacity);
            
            
        }

        private void RadioPower_Checked(object sender, RoutedEventArgs e)
        {
            var animationOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),

            };
            var character = contextCharacter as Killer;
            TbTypeHeader.Text = "Сила";
            if (character.Power.DemoImage != null)
            {
                PerksDemoImage.ImageSource = MiscUtilities.ImageConvert(character.Power.DemoImage);
            }
            else
            {
                PerksDemoImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/EmptyImage.jpg"));
            }
            TbTitlePerk.Text = character.Power.Name;
            TbPerkDescription.Text = character.Power.Description;
            PerksDemoImage.BeginAnimation(ImageBrush.OpacityProperty, animationOpacity);
            PerkDetailsContainer.BeginAnimation(StackPanel.OpacityProperty, animationOpacity);

        }

        private void ChapterViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (contextCharacter is Survivor)
            {
                NavigationService.Navigate(new ChapterViewPage((contextCharacter as Survivor).Chapter));
            }
            if (contextCharacter is Killer)
            {
                NavigationService.Navigate(new ChapterViewPage((contextCharacter as Killer).Chapter));
            }
        }

        private void RadioPerkBtn_Initialized(object sender, EventArgs e)
        {
            if (contextCharacter is Survivor && FirstPerkSelected == true)
            {
                (sender as RadioButton).IsChecked = true;
                FirstPerkSelected = false;
            }
        }

        private void TbChapter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (contextCharacter is Survivor)
            {
                NavigationService.Navigate(new ChapterViewPage((contextCharacter as Survivor).Chapter));
            }
            if (contextCharacter is Killer)
            {
                NavigationService.Navigate(new ChapterViewPage((contextCharacter as Killer).Chapter));
            }
        }
    }
}
