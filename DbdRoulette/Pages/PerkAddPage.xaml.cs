using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для PerkAddPage.xaml
    /// </summary>
    public partial class PerkAddPage : Page
    {
        Perk contextPerk;
        public PerkAddPage()
        {
            InitializeComponent();
            contextPerk = new Perk();
            DataContext = contextPerk;
            CbCharacter.ItemsSource = App.DB.Killer.ToList();
            CbFirstEffect.ItemsSource = App.DB.Effect.ToList();
            CbSecondEffect.ItemsSource = App.DB.Effect.ToList();
            CbPerkType.ItemsSource = App.DB.PerkType.ToList();
        }

        private void DownloadIconBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            {
                dialog.Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg|*.webp|*.webp";
            };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextPerk.MainIcon = System.IO.File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextPerk;
            }
        }

        private void DownloadDemoImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            {
                dialog.Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg|*.webp|*.webp";
            };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextPerk.DemoImage = System.IO.File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextPerk;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (App.DB.Perk.FirstOrDefault(x => x.Name == contextPerk.Name) != null)
                {
                    CustomMessageBox.Show("Такой навык уже есть", CustomMessageBox.CustomMessageBoxTitle.Предупреждение, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
                    return;
                }
                contextPerk.PerkTypeId = (CbPerkType.SelectedItem as PerkType).Id;
                App.DB.Perk.Add(contextPerk);
                var PerkOwner = CbCharacter.SelectedItem;
                if(PerkOwner is Killer)
                {
                    App.DB.KillerPerk.Add(new KillerPerk()
                    {
                        Perk = contextPerk,
                        Killer = PerkOwner as Killer
                    });
                }
                else if (PerkOwner is Survivor)
                {
                    App.DB.SurvivorPerk.Add(new SurvivorPerk()
                    {
                        Perk = contextPerk,
                        Survivor = PerkOwner as Survivor
                    });
                }
                var selectedFirstEffect = CbFirstEffect.SelectedItem as Effect;
                if(selectedFirstEffect != null)
                {
                    App.DB.PerkEffect.Add(new PerkEffect()
                    {
                        Perk = contextPerk,
                        Effect = selectedFirstEffect,
                    });
                }
                var selectedSecondEffect = CbSecondEffect.SelectedItem as Effect;
                if (selectedSecondEffect != null)
                {
                    App.DB.PerkEffect.Add(new PerkEffect()
                    {
                        Perk = contextPerk,
                        Effect = selectedSecondEffect,
                    });
                }
                App.DB.SaveChanges();
                DataContext = null;
                contextPerk = new Perk();
                DataContext = contextPerk;
            }
            catch(Exception ex)
            {
                CustomMessageBox.Show(ex.ToString(), CustomMessageBox.CustomMessageBoxTitle.Предупреждение, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
            }
        }

        private void CbPerkType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedPerkType = CbPerkType.SelectedItem as PerkType;
            if(SelectedPerkType.Name == "Убийца")
            {
                CbCharacter.ItemsSource = App.DB.Killer.ToList();
            }
            if (SelectedPerkType.Name == "Выживший")
            {
                CbCharacter.ItemsSource = App.DB.Survivor .ToList();
            }
        }

        private void ResetEffectBtn_Click(object sender, RoutedEventArgs e)
        {
            CbFirstEffect.SelectedItem = null;
            CbSecondEffect.SelectedItem = null;
        }
    }
}
