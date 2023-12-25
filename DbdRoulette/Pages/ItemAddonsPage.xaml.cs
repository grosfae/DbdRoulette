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
    /// Логика взаимодействия для ItemAddonsPage.xaml
    /// </summary>
    public partial class ItemAddonsPage : Page
    {
        public ItemAddonsPage()
        {
            InitializeComponent();
            LvItems.ItemsSource = App.DB.Item.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
