using AngleSharp;
using DbdRoulette.Addons;
using DbdRoulette.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для PerkListPage.xaml
    /// </summary>
    public partial class PerkListPage : Page
    {
        int maxPage = 0;
        int numberPage = 0;
        int count = 15;
        int fakePage = 1;

        public PerkListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShrineCheck();
            GenerateTags();
            GeneratePageButtons();
        }

        private void ShrineCheck()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            List<string> shrinePerks = new List<string>();
            var document = context.OpenAsync("https://deadbydaylight.fandom.com/wiki/Dead_by_Daylight_Wiki").Result;

            if (document.GetElementsByClassName("sosPerkDescName").Count() > 0)
            {
                shrinePerks.AddRange(document.GetElementsByClassName("sosPerkDescName").Select(x => x.TextContent));
            }

            string firstPerk = shrinePerks[0];
            string secondPerk = shrinePerks[1];
            string thirdPerk = shrinePerks[2];
            string fourthPerk = shrinePerks[2];

            PerkFirst.DataContext = App.DB.Perk.FirstOrDefault(x => x.EngName == firstPerk);

            PerkSecond.DataContext = App.DB.Perk.FirstOrDefault(x => x.EngName == secondPerk);

            PerkThird.DataContext = App.DB.Perk.FirstOrDefault(x => x.EngName == thirdPerk);

            PerkFourth.DataContext = App.DB.Perk.FirstOrDefault(x => x.EngName == fourthPerk);

            var shrineDays = document.GetElementsByClassName("clr4").FirstOrDefault();
            if (shrineDays != null)
            {
                string remainingDays = shrineDays.TextContent;
                if (remainingDays.Contains("Days"))
                {
                    string text = remainingDays.Substring(0, 2).Trim();
                    remainingDays = $"{text} {MiscUtilities.Generate(int.Parse(text), "День", "Дня", "Дней")}";
                }
                if (remainingDays.Contains("Hours"))
                {
                    string text = remainingDays.Substring(0, 2).Trim();
                    remainingDays = $"{text} {MiscUtilities.Generate(int.Parse(text), "Час", "Часа", "Часов")}";
                }
                TbRefreshShrine.Text = remainingDays;
            }
            document.Dispose();
        }

        private void Refresh()
        {
            IEnumerable<Perk> perks = App.DB.Perk.ToList();

            List<Perk> taggedPerks = new List<Perk>();

            if (TagSwitchBtn.IsChecked == true)
            {
                perks = perks.Where(x => x.PerkTextTag.Where(y => y.TextTagId == 2).Count() > 0);
            }
            else
            {
                perks = perks.Where(x => x.PerkTextTag.Where(y => y.TextTagId == 1).Count() > 0);
            }

            foreach (ToggleButton toggleButton in TagsContainer.Children)
            {
                if (toggleButton.IsChecked == true)
                {
                    taggedPerks.AddRange(perks.Where(x => x.PerkTextTag.Any(y => y.TextTag.Name == toggleButton.Content.ToString())));
                }
            }

            perks = taggedPerks;

            if(TbSearch.Text.Length > 0)
            {
                perks = perks.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()) || x.OwnerName.ToLower().Contains(TbSearch.Text.ToLower()));
            }

            var groupedPerks = perks.OrderBy(x => x.Name).GroupBy(x => x.Name);

            if (groupedPerks.Count() > count)
            {
                if (groupedPerks.Count() % count > 0)
                {
                    maxPage = (groupedPerks.Count() / count) + 1;
                }
                else
                {
                    maxPage = groupedPerks.Count() / count;
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

            groupedPerks = groupedPerks.Skip(count * numberPage).Take(count).ToList();
            LvPerks.ItemsSource = groupedPerks.ToList();

            LvPerks.BeginAnimation(OpacityProperty, MiscUtilities.AppearOpacityAnimation);
        }

        private void GeneratePageButtons()
        {
            SPanelPages.Children.Clear();
            for (int i = 1; i <= maxPage; i++)
            {
                RadioButton btn = new RadioButton
                {
                    Content = i,
                    Width = 30,
                    Height = 30,
                    Margin = new Thickness(10, 0, 10, 0),
                };
                btn.Checked += RadioPageButton_Checked;
                btn.Style = FindResource("PageNumberRadio") as Style;
                SPanelPages.Children.Add(btn);

                if (int.Parse(btn.Content.ToString()) == fakePage)
                {
                    btn.IsChecked = true;
                }
            }
        }
        private void RadioPageButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            int realPageNumber = int.Parse(radioButton.Content.ToString()) - 1;
            numberPage = realPageNumber;
            fakePage = int.Parse(radioButton.Content.ToString());
            Refresh();
        }
        private void GenerateTags()
        {
            TagsContainer.Children.Clear();
            IEnumerable<TextTag> textTags = App.DB.TextTag.ToList();
            if (TagSwitchBtn.IsChecked == true)
            {
                textTags = textTags.Where(x => x.Id > 2 && x.Id != 18).OrderBy(x => x.Name);
            }
            else
            {
                textTags = textTags.Where(x => x.Id > 2 && x.Id != 17).OrderBy(x => x.Name);
            }
            foreach (var item in textTags)
            {
                ToggleButton btn = new ToggleButton
                {
                    Content = item.Name,
                    FontSize = 16,
                    Height = 35,
                    Margin = new Thickness(0, 0, 0, 10),
                    BorderBrush = (Brush)new BrushConverter().ConvertFromString(item.TagColor),
                    IsChecked = true
                };
                btn.Checked += TagBtn_Checked;
                btn.Unchecked += TagBtn_Unchecked;

                btn.Style = FindResource("ToggleTagBtn") as Style;

                TagsContainer.Children.Add(btn);
                TagsContainer.BeginAnimation(OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
        }
        private void TagSwitchBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            GenerateTags();
            GeneratePageButtons();

            RecGradient.Fill = MiscUtilities.KillerBrush;
        }

        private void TagSwitchBtn_Checked(object sender, RoutedEventArgs e)
        {
            GenerateTags();
            GeneratePageButtons();

            RecGradient.Fill = MiscUtilities.SurvivorBrush;
        }

        private void TagBtn_Checked(object sender, RoutedEventArgs e)
        {
            Refresh();
            GeneratePageButtons();
        }

        private void TagBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            Refresh();
            GeneratePageButtons();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
            GeneratePageButtons();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
    }
}
