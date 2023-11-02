﻿using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Defaults;
using LiveCharts.Wpf.Charts.Base;
using System.Windows.Interop;
using DbdRoulette.Pages;

namespace DbdRoulette
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Head.MouseLeftButtonDown += new MouseButtonEventHandler(Window_MouseDown);
            MainFrame.Navigate(new KillerListPage());
        }

        private void MinButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CharactersBtn_Checked(object sender, RoutedEventArgs e)
        {
            transform.BeginAnimation(ScaleTransform.ScaleYProperty,
            new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),

            });
        }

        private void CharactersBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            transform.BeginAnimation(ScaleTransform.ScaleYProperty,
            new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2),

            });
        }
    }
}