using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.Components.NoneDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoulettePage.xaml
    /// </summary>
    public partial class RoulettePage : Page
    {
        public List<Player> SelectedPlayersList = new List<Player>();
        public List<PerkSlot> PerkSlotList = new List<PerkSlot>(4);
        public List<Perk> PerkList = new List<Perk>(4);
        public bool IsFirstLocationTry = true;

        public RoulettePage()
        {
            InitializeComponent();
            LvPartyPlayers.ItemsSource = App.DB.Player.ToList();
            LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Порядок игроков").OrderByDescending(x => x.RollDate).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void PartyRouletteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Horizontal arrow
            HorizontalArrowGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
            {
                To = -460,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut}
            });
            HorizontalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Vertical arrow
            VerticalArrowGridTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation()
            {
                To = -145,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Corners coloring
            TopLeftStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopLeftStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(77, 255, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(45, 99, 161),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            PartyRouletteSt.Visibility = Visibility.Visible;
        }

        private void LocationRouletteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Horizontal arrow
            HorizontalArrowGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
            {
                To = -145,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Vertical arrow
            VerticalArrowGridTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation()
            {
                To = -145,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Corners coloring
            TopLeftStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopLeftStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(183, 183, 183),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            LocationRouletteSt.Visibility = Visibility.Visible;
        }

        private void PerkRouletteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Horizontal arrow
            HorizontalArrowGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
            {
                To = 165,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Vertical arrow
            VerticalArrowGridTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation()
            {
                To = -145,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Corners coloring
            TopLeftStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopLeftStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(156, 61, 255),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
        }

        private void ModsRouletteBtn_Click(object sender, RoutedEventArgs e)
        {   //Horizontal arrow
            HorizontalArrowGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
            {
                To = 480,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Vertical arrow
            VerticalArrowGridTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation()
            {
                To = -145,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Corners coloring
            TopLeftStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopLeftStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(189, 0, 69),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
        }

        private void KillerRouletteBtn_Click(object sender, RoutedEventArgs e)
        {   //Horizontal arrow
            HorizontalArrowGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
            {
                To = -460,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            HorizontalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            //Vertical arrow
            VerticalArrowGridTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation()
            {
                To = 190,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalExternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalInternalStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            VerticalPathArrowheadStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });

            //Corners coloring
            TopLeftStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopLeftStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            TopRightStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            LeftBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop1.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            RightBottomStop2.BeginAnimation(GradientStop.ColorProperty, new ColorAnimation()
            {
                To = System.Windows.Media.Color.FromRgb(170, 26, 24),
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
        }

        private void RollBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPlayersList.Count() > 1)
            {
                List<PartyPlayer> ResultPlayersList = new List<PartyPlayer>();
                foreach (var Player in SelectedPlayersList)
                {
                    PartyPlayer NewPartyPlayer = new PartyPlayer();
                    NewPartyPlayer.Name = Player.Name;
                    ResultPlayersList.Add(NewPartyPlayer);
                }
                int PlayerQueueNumber = 1;
                ResultPlayersList.Shuffle();
                string TextResult = "";
                foreach (var PartyPlayer in ResultPlayersList)
                {
                    PartyPlayer.PlayerNumber = PlayerQueueNumber;
                    TextResult += $"{PlayerQueueNumber} - {PartyPlayer.Name}, ";
                    PlayerQueueNumber++;
                }
                LvPartyResult.ItemsSource = ResultPlayersList.ToList();

                App.DB.RouletteResult.Add(new RouletteResult()
                {
                    RouletteName = "Порядок игроков",
                    RollDate = DateTime.Now,
                    Result = TextResult.Remove(TextResult.Length -2, 2)
                });
                App.DB.SaveChanges();
                LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Порядок игроков").OrderByDescending(x => x.RollDate).ToList();
            }
        }

        private void TbSelectPlayer_Checked(object sender, RoutedEventArgs e)
        {
            var SelectedPlayer = (sender as ToggleButton).DataContext as Player;
            SelectedPlayersList.Add(SelectedPlayer);
        }

        private void TbSelectPlayer_Unchecked(object sender, RoutedEventArgs e)
        {
            var SelectedPlayer = (sender as ToggleButton).DataContext as Player;
            SelectedPlayersList.Remove(SelectedPlayer);
        }

        private void PlayerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TbPlayerName.Text) == false)
            {
                App.DB.Player.Add(new Player() { Name = TbPlayerName.Text});
                App.DB.SaveChanges();
                SelectedPlayersList.Clear();
                LvPartyPlayers.ItemsSource = App.DB.Player.ToList();
                TbPlayerName.Text = string.Empty;
            }
        }

        private void PlayerRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbPlayerName.Text) == false)
            {
                var Player = App.DB.Player.FirstOrDefault(x => x.Name == TbPlayerName.Text);
                if (Player != null)
                {
                    App.DB.Player.Remove(Player);
                    App.DB.SaveChanges();
                    SelectedPlayersList.Clear();
                    LvPartyPlayers.ItemsSource = App.DB.Player.ToList();
                    TbPlayerName.Text = string.Empty;
                }
            }
        }

        private void LocationRollBtn_Click(object sender, RoutedEventArgs e)
        {

            var ResultLocation = App.DB.Map.Find(new Random().Next(1, App.DB.Map.Count() + 1));
            if(ResultLocation != null)
            {
                LocationGrid.DataContext = ResultLocation.MapGallery.FirstOrDefault();
                string TextResult = $"Локация - {ResultLocation.Name}";
                App.DB.RouletteResult.Add(new RouletteResult()
                {
                    RouletteName = "Случайная локация",
                    RollDate = DateTime.Now,
                    Result = TextResult
                });
                App.DB.SaveChanges();
                LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайная локация").OrderByDescending(x => x.RollDate).ToList();
                if (IsFirstLocationTry == true)
                {
                    TbQuestion.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(1),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    MapImage.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(1),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    MapData.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(1),
                        Duration = TimeSpan.FromSeconds(1),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    IsFirstLocationTry = false;
                }
                else
                {
                    Storyboard MapDataStoryboard = new Storyboard();
                    DoubleAnimation AppearAnimation = new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(1),
                        BeginTime = TimeSpan.FromSeconds(2),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    };
                    DoubleAnimation AppearAnimationImage = new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(1),
                        BeginTime = TimeSpan.FromSeconds(1),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    };
                    DoubleAnimation DisappearAnimation = new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(1),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    };
                    Storyboard.SetTargetProperty(AppearAnimation, new PropertyPath(OpacityProperty));
                    Storyboard.SetTargetProperty(DisappearAnimation, new PropertyPath(OpacityProperty));
                    Storyboard.SetTargetProperty(AppearAnimationImage, new PropertyPath(OpacityProperty));
                    MapDataStoryboard.Children = new TimelineCollection()
                    {
                        DisappearAnimation, AppearAnimation
                    };
                    MapData.BeginStoryboard(MapDataStoryboard);

                    Storyboard MapImageStoryboard = new Storyboard();
                    MapImageStoryboard.Children = new TimelineCollection()
                    {
                        DisappearAnimation, AppearAnimationImage
                    };
                    MapImageStoryboard.BeginTime = TimeSpan.FromSeconds(1);
                    MapImage.BeginStoryboard(MapImageStoryboard);
                }
            }
            
        }

        private void PerkRollingBtn_Click(object sender, RoutedEventArgs e)
        {
            FirstPerkGrid.DataContext = null;
            SecondPerkGrid.DataContext = null;
            ThirdPerkGrid.DataContext = null;
            FourthPerkGrid.DataContext = null;
            var PerkListForRandom = new List<Perk>();
            if(RadioKillerPerk.IsChecked == true)
            {
                PerkListForRandom = App.DB.Perk.Where(x => x.PerkTypeId == 1).ToList();
            }
            else if(RadioSurvivorPerk.IsChecked == true)
            {
                PerkListForRandom = App.DB.Perk.Where(x => x.PerkTypeId == 2).ToList();
            }
            else
            { 
                PerkListForRandom = App.DB.Perk.ToList();
            }
            int CountPerkSelectedSlots = 0;
            if (FirstPerkTb.IsChecked == true)
            {
                CountPerkSelectedSlots++;
                PerkSlotList.Add(new PerkSlot() 
                { 
                    SlotNumber = 1
                });
            }
            if (SecondPerkTb.IsChecked == true)
            {
                CountPerkSelectedSlots++;
                PerkSlotList.Add(new PerkSlot()
                {
                    SlotNumber = 2
                });
            }
            if (ThirdPerkTb.IsChecked == true)
            {
                CountPerkSelectedSlots++;
                PerkSlotList.Add(new PerkSlot()
                {
                    SlotNumber = 3
                });
            }
            if (FourthPerkTb.IsChecked == true)
            {
                CountPerkSelectedSlots++;
                PerkSlotList.Add(new PerkSlot()
                {
                    SlotNumber = 4
                });
            }
            if(CountPerkSelectedSlots == 0)
            {
                return;
            }
            for (int i = 1; i <= CountPerkSelectedSlots; i++)
            {
                Perk ResultPerk = null;
                do
                {
                    ResultPerk = PerkListForRandom[new Random().Next(0, PerkListForRandom.Count)];
                }
                while (PerkList.Contains(ResultPerk));
                if (ResultPerk != null)
                {
                    PerkList.Add(ResultPerk);
                    PerkSlotList[i - 1].Perk = ResultPerk;
                }
            }
            if (FirstPerkTb.IsChecked == true)
            {
                FirstPerkGrid.DataContext = PerkSlotList.FirstOrDefault(x => x.SlotNumber == 1).Perk;
                FirstPerkGrid.Opacity = 1;
            }
            if (SecondPerkTb.IsChecked == true)
            {
                SecondPerkGrid.DataContext = PerkSlotList.FirstOrDefault(x => x.SlotNumber == 2).Perk;
                SecondPerkGrid.Opacity = 1;
            }
            if (ThirdPerkTb.IsChecked == true)
            {
                ThirdPerkGrid.DataContext = PerkSlotList.FirstOrDefault(x => x.SlotNumber == 3).Perk;
                ThirdPerkGrid.Opacity = 1;
            }
            if (FourthPerkTb.IsChecked == true)
            {
                FourthPerkGrid.DataContext = PerkSlotList.FirstOrDefault(x => x.SlotNumber == 4).Perk;
                FourthPerkGrid.Opacity = 1;
            }
            string TextResult = "";
            foreach(var Perk in PerkSlotList)
            {
                TextResult += $"{Perk.SlotNumber} - {Perk.Perk.Name}, ";
            }
            App.DB.RouletteResult.Add(new RouletteResult()
            {
                RouletteName = "Случайные навыки",
                RollDate = DateTime.Now,
                Result = TextResult.Remove(TextResult.Length - 2, 2)
            });
            App.DB.SaveChanges();
            LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайные навыки").OrderByDescending(x => x.RollDate).ToList();
            PerkList.Clear();
            PerkSlotList.Clear();
        }

        private void RadioKillerPerk_Checked(object sender, RoutedEventArgs e)
        {
            FirstPerkGrid.DataContext = null;
            SecondPerkGrid.DataContext = null;
            ThirdPerkGrid.DataContext = null;
            FourthPerkGrid.DataContext = null;
        }

        private void RadioSurvivorPerk_Checked(object sender, RoutedEventArgs e)
        {
            FirstPerkGrid.DataContext = null;
            SecondPerkGrid.DataContext = null;
            ThirdPerkGrid.DataContext = null;
            FourthPerkGrid.DataContext = null;
        }
    }
}
