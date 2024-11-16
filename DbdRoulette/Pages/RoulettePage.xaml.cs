using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.Components.NoneDatabase;
using DbdRoulette.Properties;
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
        public List<Killer> SelectedKillersList = new List<Killer>();
        public List<PrivateMod> PrivateModList = new List<PrivateMod>();
        public List<PrivateModCheck> PrivateModRolledList = new List<PrivateModCheck>();
        public List<PerkSlot> PerkSlotList = new List<PerkSlot>(4);
        public List<Perk> PerkList = new List<Perk>(4);
        public ModInformationControl LastWinnerModControl = null;
        public bool IsFirstLocationTry = true;
        public bool IsModPanelClear = false;
        public bool IsFirstKillerRollTry = true;

        public RoulettePage()
        {
            InitializeComponent();
            if(Settings.Default.ThemeCode == 2)
            {
                SelectAllKillersBtn.BorderBrush = MiscUtilities.HauntedThemeCyanBrush;
            }
            if (Settings.Default.ThemeCode == 3)
            {
                SelectAllKillersBtn.BorderBrush = MiscUtilities.AnniversaryThemeGoldenBrush;
            }
            LvResultHistory.ItemsSource = App.DB.RouletteResult.OrderByDescending(x => x.RollDate).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        #region RouletteSelect Buttons
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
            SelectedPlayersList.Clear();
            LvPartyResult.ItemsSource = null;
            PartyRouletteSt.Visibility = Visibility.Visible;
            LvPartyPlayers.ItemsSource = App.DB.Player.ToList();
            LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Порядок игроков").OrderByDescending(x => x.RollDate).ToList();
            LocationRouletteSt.Visibility = Visibility.Collapsed;
            PerkRouletteSt.Visibility = Visibility.Collapsed;
            ModsRouletteSt.Visibility = Visibility.Collapsed;
            KillerRouletteSt.Visibility = Visibility.Collapsed;
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
            PartyRouletteSt.Visibility = Visibility.Collapsed;
            LocationRouletteSt.Visibility = Visibility.Visible;
            LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайная локация").OrderByDescending(x => x.RollDate).ToList();
            PerkRouletteSt.Visibility = Visibility.Collapsed;
            ModsRouletteSt.Visibility = Visibility.Collapsed;
            KillerRouletteSt.Visibility = Visibility.Collapsed;
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
            PartyRouletteSt.Visibility = Visibility.Collapsed;
            LocationRouletteSt.Visibility = Visibility.Collapsed;
            PerkRouletteSt.Visibility = Visibility.Visible;
            LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайные навыки").OrderByDescending(x => x.RollDate).ToList();
            ModsRouletteSt.Visibility = Visibility.Collapsed;
            KillerRouletteSt.Visibility = Visibility.Collapsed;
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
            PartyRouletteSt.Visibility = Visibility.Collapsed;
            LocationRouletteSt.Visibility = Visibility.Collapsed;
            PerkRouletteSt.Visibility = Visibility.Collapsed;
            KillerRouletteSt.Visibility = Visibility.Collapsed;
            ModsRouletteSt.Visibility = Visibility.Visible;
            LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайный модификатор").OrderByDescending(x => x.RollDate).ToList();
            ModPlatesGenerate();
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
            PartyRouletteSt.Visibility = Visibility.Collapsed;
            LocationRouletteSt.Visibility = Visibility.Collapsed;
            PerkRouletteSt.Visibility = Visibility.Collapsed;
            ModsRouletteSt.Visibility = Visibility.Collapsed;
            KillerRouletteSt.Visibility = Visibility.Visible;
            LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайный убийца").OrderByDescending(x => x.RollDate).ToList();
            var KillerList = App.DB.Killer.ToList();
            LvCharacters.ItemsSource = KillerList.OrderByDescending(x => x.Chapter.CorrectDateRelease);
            SelectedKillersList.Clear();
            SelectAllKillersBtn.IsChecked = false;
            IsFirstKillerRollTry = true;
            KillerGrid.DataContext = null;
            GridKillerBackground.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            });
            KillerImage.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            });
            ParametersGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            });
            StDifficulty.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            }); ;
            StHeight.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            }); ;
            StMoveSpeed.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            }); ;
            StTerrorRadius.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            }); ;
            KillerNameGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0)
            });
        }
        #endregion
        private void ModPlatesGenerate()
        {
            PrivateModList = App.DB.PrivateMod.ToList();
            PrivateModRolledList.Clear();
            PrivateModList.Shuffle();
            LastWinnerModControl = null;
            WrapPanelForModPlates.Children.Clear();
            //Generate plates
            int ModIndex = 0;
            foreach (var Mod in PrivateModList)
            {
                PrivateModRolledList.Add(new PrivateModCheck()
                {
                    ModNumber = ModIndex,
                    PrivateMod = Mod
                });
                ModIndex++;
                ModInformationControl modInformationControl = new ModInformationControl();
                modInformationControl.DataContext = Mod;
                WrapPanelForModPlates.Children.Add(modInformationControl);
            }
            PrivateModRolledList.Shuffle();
            ModRollBtn.Content = "Определить модификатор"; 
            IsModPanelClear = false;
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

        private async void LocationRollBtn_Click(object sender, RoutedEventArgs e)
        {

            var ResultLocation = App.DB.Map.Find(new Random().Next(1, App.DB.Map.Count() + 1));
            if(ResultLocation != null)
            {
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
                    LocationGrid.DataContext = ResultLocation.MapGallery.FirstOrDefault();
                    MapData.DataContext = ResultLocation;
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
                    await Task.Delay(2000);
                    LocationGrid.DataContext = ResultLocation.MapGallery.FirstOrDefault();
                    MapData.DataContext = ResultLocation;
                }
            }
            
        }

        private void PerkRollingBtn_Click(object sender, RoutedEventArgs e)
        {
            PerkSlotList.Clear();
            PerkList.Clear();
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

        private async void ModRollBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsModPanelClear == true)
            {
                ModPlatesGenerate();
            }
            else
            {
                ModRollBtn.IsEnabled = false;
                if (LastWinnerModControl != null)
                {
                    LastWinnerModControl.MainBorderBrushStop.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                    {
                        To = Color.FromRgb(18, 18, 18),
                        Duration = TimeSpan.FromSeconds(0.2),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    LastWinnerModControl.MainBorder.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0.3,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                }

                double Tick = 0;
                foreach (var Row in PrivateModRolledList)
                {
                    if (Settings.Default.ThemeCode == 1)
                    {
                        (WrapPanelForModPlates.Children[Row.ModNumber] as ModInformationControl).MainBorderBrushStop.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                        {
                            To = Color.FromRgb(56, 129, 239),
                            Duration = TimeSpan.FromSeconds(0.2),
                            BeginTime = TimeSpan.FromSeconds(Tick),
                            AutoReverse = true,
                            EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                        });
                    }
                    if (Settings.Default.ThemeCode == 2)
                    {
                        (WrapPanelForModPlates.Children[Row.ModNumber] as ModInformationControl).MainBorderBrushStop.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                        {
                            To = Color.FromRgb(75, 218, 214),
                            Duration = TimeSpan.FromSeconds(0.2),
                            BeginTime = TimeSpan.FromSeconds(Tick),
                            AutoReverse = true,
                            EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                        });
                    }
                    if (Settings.Default.ThemeCode == 3)
                    {
                        (WrapPanelForModPlates.Children[Row.ModNumber] as ModInformationControl).MainBorderBrushStop.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                        {
                            To = Color.FromRgb(223, 173, 73),
                            Duration = TimeSpan.FromSeconds(0.2),
                            BeginTime = TimeSpan.FromSeconds(Tick),
                            AutoReverse = true,
                            EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                        });
                    }
                    Tick += 0.2;
                }
                Random rnd = new Random();
                int WinDigit = rnd.Next(0, PrivateModList.Count);
                var WinnerMod = PrivateModList[WinDigit];
                await Task.Delay(TimeSpan.FromSeconds(Tick));
                foreach (var Child in WrapPanelForModPlates.Children)
                {
                    var ControlChild = Child as ModInformationControl;
                    if ((ControlChild.DataContext as PrivateMod).Id == WinnerMod.Id)
                    {
                        ControlChild.MainBorderBrushStop.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                        {
                            To = Color.FromRgb(170, 26, 24),
                            Duration = TimeSpan.FromSeconds(0.3),
                            EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                        });
                        App.DB.RouletteResult.Add(new RouletteResult()
                        {
                            RouletteName = "Случайный модификатор",
                            RollDate = DateTime.Now,
                            Result = WinnerMod.Name,
                        });
                        App.DB.SaveChanges();
                        LastWinnerModControl = ControlChild;
                        PrivateModList.Remove(WinnerMod);
                        PrivateModRolledList.Remove(PrivateModRolledList.FirstOrDefault(x => x.PrivateMod == WinnerMod));
                        PrivateModRolledList.Shuffle();
                    }
                }
                ModRollBtn.IsEnabled = true;
                if (PrivateModList.Count == 0)
                {
                    ModRollBtn.Content = "Начать заново";
                    IsModPanelClear = true;
                }
                LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайный модификатор").OrderByDescending(x => x.RollDate).ToList();
            }

        }

        private void CharacterBtn_Checked(object sender, RoutedEventArgs e)
        {
            var SelectedKiller = (sender as ToggleButton).DataContext as Killer;
            SelectedKillersList.Add(SelectedKiller);
            if(SelectedKillersList.Count == LvCharacters.Items.Count)
            {
                SelectAllKillersBtn.IsChecked = true;
            }
        }

        private void CharacterBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            var SelectedKiller = (sender as ToggleButton).DataContext as Killer;
            SelectedKillersList.Remove(SelectedKiller);
            if (SelectedKillersList.Count < LvCharacters.Items.Count)
            {
                SelectAllKillersBtn.IsChecked = false;
            }
        }

        private void SelectAllKillersBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (SelectedKillersList.Count < LvCharacters.Items.Count)
            {
                foreach (var ChildItem in LvCharacters.Items)
                {
                    ListViewItem item = LvCharacters.ItemContainerGenerator.ContainerFromItem(ChildItem) as ListViewItem;
                    if (item != null)
                    {
                        var ToggleButton = MiscUtilities.FindVisualChild<ToggleButton>(item);
                        if (ToggleButton.IsChecked == false)
                        {
                            ToggleButton.IsChecked = true;
                        }
                    }
                }
            }
        }

        private void SelectAllKillersBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SelectedKillersList.Count < LvCharacters.Items.Count)
            {
                SelectAllKillersBtn.IsChecked = false;
            }
            else
            {
                foreach (var ChildItem in LvCharacters.Items)
                {
                    ListViewItem item = LvCharacters.ItemContainerGenerator.ContainerFromItem(ChildItem) as ListViewItem;
                    if (item != null)
                    {
                        var ToggleButton = MiscUtilities.FindVisualChild<ToggleButton>(item);
                        if (ToggleButton.IsChecked == true)
                        {
                            ToggleButton.IsChecked = false;
                        }
                    }
                }
            }
        }

        private async void KillerRollBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedKillersList.Count > 1)
            {
                KillerRollBtn.IsEnabled = false;
                Random rnd = new Random();
                int WinDigit = rnd.Next(0, SelectedKillersList.Count);
                var WinnerKiller = SelectedKillersList[WinDigit];
                if (IsFirstKillerRollTry == true)
                {
                    KillerGrid.DataContext = WinnerKiller;
                    ParametersGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    GridKillerBackground.BeginAnimation(ImageBrush.OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StDifficulty.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(0.6),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StHeight.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(0.6),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StMoveSpeed.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.2),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StTerrorRadius.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.2),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    KillerImage.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.8),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    KillerNameGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.8),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    IsFirstKillerRollTry = false;
                    await Task.Delay(2400);
                    KillerRollBtn.IsEnabled = true;
                }
                else
                {
                    ParametersGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    GridKillerBackground.BeginAnimation(ImageBrush.OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StDifficulty.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StHeight.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StMoveSpeed.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StTerrorRadius.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    KillerImage.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    KillerNameGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    //Opacity appear
                    await Task.Delay(300);
                    KillerGrid.DataContext = WinnerKiller;
                    ParametersGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(0.6),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    GridKillerBackground.BeginAnimation(ImageBrush.OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(0.6),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StDifficulty.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.2),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StHeight.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.2),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StMoveSpeed.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.8),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    StTerrorRadius.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(1.8),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    KillerImage.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(2.4),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    KillerNameGrid.BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.6),
                        BeginTime = TimeSpan.FromSeconds(2.4),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                    });
                    await Task.Delay(3000);
                    KillerRollBtn.IsEnabled = true;
                }
                App.DB.RouletteResult.Add(new RouletteResult()
                {
                    RouletteName = "Случайный убийца",
                    RollDate = DateTime.Now,
                    Result = WinnerKiller.Name,
                });
                App.DB.SaveChanges();
                LvResultHistory.ItemsSource = App.DB.RouletteResult.Where(x => x.RouletteName == "Случайный убийца").OrderByDescending(x => x.RollDate).ToList();

            }
        }
    }
}
