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
    /// Логика взаимодействия для ItemListPage.xaml
    /// </summary>
    public partial class ItemListPage : Page
    {
        public ItemListPage()
        {
            InitializeComponent();
            LvRarities.ItemsSource = App.DB.Rarity.Where(x => x.Id != 6 && x.Id != 8 && x.Id != 10).ToList();
            LvItems.ItemsSource = App.DB.Item.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
