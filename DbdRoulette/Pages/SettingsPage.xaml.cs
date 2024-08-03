using DbdRoulette.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            if(App.ThemeCode == 1)
            {
                DefaultThemeBtn.IsChecked = true;
            }
            if(App.ThemeCode == 2)
            {
                HauntedThemeBtn.IsChecked = true;
            }
            if (App.ThemeCode == 3)
            {
                AnniversaryThemeBtn.IsChecked = true;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void DefaultThemeBtn_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ThemeCode = 1;
        }

        private void HauntedThemeBtn_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ThemeCode = 2;
        }

        private void AnniversaryThemeBtn_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ThemeCode = 3;
        }
        private void ClearResultHistoryBtn_Checked(object sender, RoutedEventArgs e)
        {
            CustomMessageBox.Show("Очистка результатов будет выполнена после сохранения настроек.", CustomMessageBox.CustomMessageBoxTitle.Предупреждение, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
        }

        private void SaveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult quest = CustomMessageBox.Show("Вы хотите сохранить изменения?", CustomMessageBox.CustomMessageBoxTitle.Подтверждение, CustomMessageBox.CustomMessageBoxButton.Да, CustomMessageBox.CustomMessageBoxButton.Нет);
            if (quest == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.Save();
                if (ClearResultHistoryBtn.IsChecked == true)
                {
                    App.DB.RouletteResult.RemoveRange(App.DB.RouletteResult);
                    App.DB.SaveChanges();
                }
                if (App.ThemeCode == Properties.Settings.Default.ThemeCode)
                {
                    CustomMessageBox.Show("Настройки успешно сохранены!", CustomMessageBox.CustomMessageBoxTitle.Успешно, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
                }
                else
                {
                    CustomMessageBox.Show("Приложение будет перезапущено для смены темы оформления.", CustomMessageBox.CustomMessageBoxTitle.Предупреждение, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
                    App.ApplicationRestart();
                }
            }
        }

    }
}
