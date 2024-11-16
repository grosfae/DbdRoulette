using AngleSharp;
using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.Properties;
using DbdRoulette.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace DbdRoulette
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string CurrentApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        public static ApplicationContext DB = new ApplicationContext();

        public static Perk PerkShrineFirst;
        public static Perk PerkShrineSecond;
        public static Perk PerkShrineThird;
        public static Perk PerkShrineFourth;

        public static string RefreshShrineTimeOut;
        public static int ThemeCode;
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

            if (shrinePerks.Count > 0)
            {
                string firstPerk = shrinePerks[0];
                string secondPerk = shrinePerks[1];
                string thirdPerk = shrinePerks[2];
                string fourthPerk = shrinePerks[3];

                PerkShrineFirst = DB.Perk.FirstOrDefault(x => x.EngName == firstPerk);

                PerkShrineSecond = DB.Perk.FirstOrDefault(x => x.EngName == secondPerk);

                PerkShrineThird = DB.Perk.FirstOrDefault(x => x.EngName == thirdPerk);

                PerkShrineFourth = DB.Perk.FirstOrDefault(x => x.EngName == fourthPerk);

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
                    RefreshShrineTimeOut = remainingDays;
                }
            }
            document.Dispose();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            ThemeCode = Settings.Default.ThemeCode;
            if (Settings.Default.ThemeCode == 2)
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/ThemesDictionaries/HauntedThemeDictionary.xaml") };
            }
            if (Settings.Default.ThemeCode == 3)
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/ThemesDictionaries/AnniversaryThemeDictionary.xaml") };
            }
            await Task.Run(() => ShrineCheck());
            if (MiscUtilities.CheckInternetConnection())
            {
                try
                {
                    await MiscUtilities.SearchingUpdates();
                }
                catch
                {
                    //CustomMessageBox.Show("Репозиторий недоступен!", CustomMessageBox.CustomMessageBoxTitle.Предупреждение, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
                }
            }
            else
            {
                CustomMessageBox.Show("Отсутствует доступ к интернету!", CustomMessageBox.CustomMessageBoxTitle.Предупреждение, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
            }
        }

        public static void ApplicationRestart()
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LoggerSerivce.Write(e.Exception);
            MessageBox.Show(e.Exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

    }
}
