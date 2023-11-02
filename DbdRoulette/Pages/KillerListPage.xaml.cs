using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для KillerListPage.xaml
    /// </summary>
    public partial class KillerListPage : Page
    {
        public KillerListPage()
        {
            InitializeComponent();
            LvCharacters.ItemsSource = App.DB.Killer.ToList();
        }
    }
}
