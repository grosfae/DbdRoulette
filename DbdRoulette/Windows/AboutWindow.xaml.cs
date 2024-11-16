using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace DbdRoulette.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            TbVersion.Text = App.CurrentApplicationVersion.ToString();
            Header.MouseLeftButtonDown += new MouseButtonEventHandler(Window_MouseDown);
            this.Title = "О программе";
            if (App.ThemeCode == 2)
            {
                LogoImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/HauntedTheme/HauntedThemeIcon.ico"));
            }
            if (App.ThemeCode == 3)
            {
                LogoImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/AnniversaryTheme/AnniversaryThemeIcon.ico"));
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GitLinkBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProcessStartInfo GitHubLink = new ProcessStartInfo("https://github.com/grosfae/DbdRoulette.git");
            Process.Start(GitHubLink);
        }

        private void RusWikiTb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProcessStartInfo RusWikiLink = new ProcessStartInfo(RusWikiTb.Text);
            Process.Start(RusWikiLink);
        }

        private void EngWikiTb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProcessStartInfo EngWikiLink = new ProcessStartInfo(EngWikiTb.Text);
            Process.Start(EngWikiLink);
        }

        private void OffSiteTb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProcessStartInfo OffSiteLink = new ProcessStartInfo(OffSiteTb.Text);
            Process.Start(OffSiteLink);
        }
    }
}
