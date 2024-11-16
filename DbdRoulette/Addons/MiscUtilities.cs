using DbdRoulette.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Oct = Octokit;

namespace DbdRoulette.Addons
{
    public class MiscUtilities
    {
        public static SolidColorBrush SurvivorBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(45, 99, 161));

        public static SolidColorBrush KillerBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(170, 26, 24));

        public static SolidColorBrush SpecialBlack = new SolidColorBrush(System.Windows.Media.Color.FromRgb(18, 18, 18));

        public static SolidColorBrush HauntedThemeCyanBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(75, 218, 214));

        public static SolidColorBrush AnniversaryThemeGoldenBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 173, 73));
        public static SolidColorBrush AnniversaryThemeBlueBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 163, 255));

        public static BitmapImage ImageConvert(byte[] convertableImage)
        {
            var image = new BitmapImage();
            using (var mem = new MemoryStream(convertableImage))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

        public static DoubleAnimation AppearOpacityAnimation = new DoubleAnimation
        {
            From = 0,
            To = 1,
            Duration = TimeSpan.FromSeconds(1.0),
        };

        public static string Generate(int number, string nominativ, string genetiv, string plural)
        {
            var titles = new[] { nominativ, genetiv, plural };
            var cases = new[] { 2, 0, 1, 1, 1, 2 };
            return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
        }
        public static bool CheckInternetConnection()
        {
            try
            {
                Dns.GetHostEntry("ya.ru");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static async Task SearchingUpdates()
        {
            Oct.GitHubClient GitClient = new Oct.GitHubClient(new Oct.ProductHeaderValue("SomeName"));
            IReadOnlyList<Oct.Release> Releases = await GitClient.Repository.Release.GetAll("grosfae", "DbdRoulette");
            if (Releases.Count > 0)
            {
                string LatestGitHubVersion = Releases[0].TagName;

                if (Convert.ToDouble(App.CurrentApplicationVersion.Replace(".", ""), CultureInfo.InvariantCulture) < Convert.ToDouble(LatestGitHubVersion.Replace(".", ""), CultureInfo.InvariantCulture))
                {
                    DialogResult result = CustomMessageBox.Show($"Доступна новая версия программы - {LatestGitHubVersion}. Желаете скачать новую версию?", CustomMessageBox.CustomMessageBoxTitle.Подтверждение, CustomMessageBox.CustomMessageBoxButton.Да, CustomMessageBox.CustomMessageBoxButton.Нет);
                    if (result == DialogResult.Yes)
                    {
                        FolderBrowserDialog FBD = new FolderBrowserDialog();
                        if (FBD.ShowDialog() == DialogResult.OK)
                        {
                            WebClient webClient = new WebClient();
                            webClient.DownloadFile(Releases[0].Assets[0].BrowserDownloadUrl, FBD.SelectedPath + @"\" + Releases[0].Assets[0].Name);
                            CustomMessageBox.Show($"Загрузка установщика новой версии программы завершена!", CustomMessageBox.CustomMessageBoxTitle.Успешно, CustomMessageBox.CustomMessageBoxButton.Хорошо, CustomMessageBox.CustomMessageBoxButton.Нет);
                        }
                    }
                }
            }
        }
        //For update perk icons in database from folder
        private void DownloadPerkImages()
        {
            var folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo folder = new DirectoryInfo(folderDialog.SelectedPath);
                System.Windows.MessageBox.Show(folder.FullName);
                foreach (var img in folder.GetFiles())
                {
                    string ImageName = img.Name;
                    var perk = App.DB.Perk.FirstOrDefault(x => x.EngName.ToLower().Contains(ImageName.ToLower().Remove(ImageName.Length - 4, 4)));
                    perk.MainIcon = File.ReadAllBytes(img.FullName);
                    App.DB.SaveChanges();
                }
            }
        }
    }

}
