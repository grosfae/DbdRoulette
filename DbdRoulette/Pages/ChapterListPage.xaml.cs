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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChapterListPage.xaml
    /// </summary>
    public partial class ChapterListPage : Page
    {
        public ChapterListPage()
        {
            InitializeComponent();
            LvSlider.ItemsSource = App.DB.Chapter.ToList();
            CbSort.Items.Add("Самые новые");
            CbSort.Items.Add("Самые ранние");
            CbSort.SelectedIndex = 0;
        }

        
        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }


        private void ScrollElem_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            
        }

        private void ChapterBlockElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
