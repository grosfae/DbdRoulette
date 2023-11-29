using AngleSharp;
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
            LvTags.Items.Add("");
            LvTags.Items.Add("");
            LvTags.Items.Add("");
            LvTags.Items.Add("");
            LvTags.Items.Add("");
            LvTags.Items.Add("");
            LvPerks.ItemsSource = App.DB.Perk.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShrineCheck();
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

            document.Dispose();
        }
    }
}
