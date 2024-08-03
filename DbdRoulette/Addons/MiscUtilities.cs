﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

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

    }

}
