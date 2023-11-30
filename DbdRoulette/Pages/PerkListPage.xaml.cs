using AngleSharp;
using DbdRoulette.Components;
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
        public PerkListPage()
        {
            InitializeComponent();
            LvPerks.ItemsSource = App.DB.Perk.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShrineCheck();
            Refresh(false);
        }

        private void ShrineCheck()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            List<string> list = new List<string>();
            var document = context.OpenAsync("https://deadbydaylight.fandom.com/wiki/Dead_by_Daylight_Wiki").Result;

            if (document.GetElementsByClassName("sosPerkDescName").Count() > 0)
            {
                list.AddRange(document.GetElementsByClassName("sosPerkDescName").Select(x => x.TextContent));
            }
            var shrineDays = document.GetElementsByClassName("clr4").FirstOrDefault();
            if (shrineDays != null)
            {
                string translatedText = shrineDays.TextContent;
                if (translatedText.Contains("Days"))
                {
                    translatedText = translatedText.Replace("Days", "Дней");
                    MessageBox.Show(translatedText);
                }
                if (translatedText.Contains("Hours"))
                {
                    translatedText = translatedText.Replace("Hours", "Часов");
                    MessageBox.Show(translatedText);
                }
                
            }

            document.Dispose();
        }

        private void Refresh(bool isSurvivor)
        {
            IEnumerable<TextTag> textTags = App.DB.TextTag.ToList();

            if (isSurvivor == true)
            {
                textTags = textTags.Where(x => x.Id > 2 && x.Id != 18);

            }
            else
            {
                textTags = textTags.Where(x => x.Id > 2 && x.Id != 17);

            }
            LvTags.ItemsSource = textTags.OrderBy(x => x.Name).ToList();
        }
        private void TagSwitchBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            Refresh(false);
        }

        private void TagSwitchBtn_Checked(object sender, RoutedEventArgs e)
        {
            Refresh(true);
        }
    }
}
