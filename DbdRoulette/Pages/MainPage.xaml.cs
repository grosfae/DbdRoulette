using DbdRoulette.Addons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        DoubleAnimation zoomInAnimation = new DoubleAnimation
        {
            To = 500,
            Duration = TimeSpan.FromSeconds(0.3),
            EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
        };

        DoubleAnimation zoomOutAnimation = new DoubleAnimation
        {
            To = 450,
            Duration = TimeSpan.FromSeconds(0.3),
            EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn }
        };

        DoubleAnimation opacityInAnimation = new DoubleAnimation
        {
            To = 1,
            Duration = TimeSpan.FromSeconds(0.3),
            EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
        };

        DoubleAnimation opacityOutAnimation = new DoubleAnimation
        {
            To = 0,
            Duration = TimeSpan.FromSeconds(0.3),
            EasingFunction = new CircleEase { EasingMode = EasingMode.EaseIn }
        };
        public MainPage()
        {
            InitializeComponent();
            RadioKiller.IsChecked = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                BackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void KillerManualBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            KillerImage.BeginAnimation(WidthProperty, zoomInAnimation);
            KillerGrayImage.BeginAnimation(WidthProperty, zoomInAnimation);

            SurvivorGrayImage.BeginAnimation(OpacityProperty, opacityInAnimation);
            SurvivorImage.BeginAnimation(OpacityProperty, opacityOutAnimation);
        }

        private void KillerManualBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            KillerImage.BeginAnimation(WidthProperty, zoomOutAnimation);
            KillerGrayImage.BeginAnimation(WidthProperty, zoomOutAnimation);

            SurvivorGrayImage.BeginAnimation(OpacityProperty, opacityOutAnimation);
            SurvivorImage.BeginAnimation(OpacityProperty, opacityInAnimation);
        }

        private void KillerManualBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(RadioSurvivor.IsChecked == true)
            {
                RadioKiller.IsChecked = true;
            }
        }

        private void SurvivorManualBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SurvivorImage.BeginAnimation(WidthProperty, zoomInAnimation);
            SurvivorGrayImage.BeginAnimation(WidthProperty, zoomInAnimation);

            KillerGrayImage.BeginAnimation(OpacityProperty, opacityInAnimation);
            KillerImage.BeginAnimation(OpacityProperty, opacityOutAnimation);
        }

        private void SurvivorManualBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            SurvivorImage.BeginAnimation(WidthProperty, zoomOutAnimation);
            SurvivorGrayImage.BeginAnimation(WidthProperty, zoomOutAnimation);

            KillerGrayImage.BeginAnimation(OpacityProperty, opacityOutAnimation);
            KillerImage.BeginAnimation(OpacityProperty, opacityInAnimation);
        }

        private void SurvivorManualBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (RadioKiller.IsChecked == true)
            {
                RadioSurvivor.IsChecked = true;
            }
        }
        private void RadioKiller_Checked(object sender, RoutedEventArgs e)
        {
            MainStageTitle.Text = "ОСНОВЫ ИГРЫ ЗА УБИЙЦУ";
            MainStageMiniText.Text = "Несмотря на уникальность каждого убийцы, их цели остаются неизменными. Убивайте выживших одного за другим и приносите их в жертву Сущности. Вот основы, с которых можно начать.";

            FirstStageTitle.Text = "ОХОТА";
            FirstStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/MainPageStagesImages/FirstStageKiller.jpg"));
            FirstStageTb.Text = "Выжившим нужно починить генераторы по всей карте, чтобы включить выходные ворота и сбежать. Патрулируйте и повреждайте эти генераторы в поисках следующей жертвы. Следите за шумовыми оповещениями, появляющимися, когда выжившие не проходят проверку генератора и навыков лечения или выполняют поспешные действия, такие как прыжки через окна.";

            foreach (var rect in FirstStageGrid.Children)
            {
                (rect as Rectangle).Fill = MiscUtilities.KillerBrush;
            }

            SecondStageTitle.Text = "ПОГОНЯ";
            SecondStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/MainPageStagesImages/SecondStageKiller.jpg"));
            SecondStageTb.Text = "По мере того, как выжившие спасаются бегством, они будут оставлять следы, по которым их можно найти. Если след исчезает, проверьте ближайшие шкафчики, где они могут прятаться. Выжившие будут пытаться ускользнуть от вас, перепрыгивая через окна, ослепляя вас фонариками и сбрасывая поддоны на вашем пути. Думайте наперед, сокращайте дистанцию и наносите удар.";

            foreach (var rect in SecondStageGrid.Children)
            {
                (rect as Rectangle).Fill = MiscUtilities.KillerBrush;
            }

            ThirdStageTitle.Text = "КРЮК";
            ThirdStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/MainPageStagesImages/ThirdStageKiller.jpg"));
            ThirdStageTb.Text = "Один раз ударив выжившего, он становится раненым. После второго удара они входят в предсмертное сотояние, позволяя вам поднять их, поднести к одному из многочисленных жертвенных крюков и пронзить. Если они слишком долго борются на крюке, не могут быть спасены союзником или спасены и подвешены в общей сложности 3 раза - жертва неизбежна.";

            foreach (var rect in ThirdStageGrid.Children)
            {
                (rect as Rectangle).Fill = MiscUtilities.KillerBrush;
            }

            IconStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/KillerIcon.png"));

            RecGradientTop.Fill = MiscUtilities.KillerBrush;
            RecGradientDown.Fill = MiscUtilities.KillerBrush;

            ContentStackPanel.BeginAnimation(OpacityProperty, MiscUtilities.AppearOpacityAnimation);
        }

        private void RadioSurvivor_Checked(object sender, RoutedEventArgs e)
        {
            MainStageTitle.Text = "ОСНОВЫ ИГРЫ ЗА ВЫЖИВШЕГО";
            MainStageMiniText.Text = "Выжившие могут играть разные роли в команде, но их общая цель никогда не меняется. Уклонитесь от Убийцы и сбегите от суда. Вот основы, с которых можно начать.";

            FirstStageTitle.Text = "ПОЧИНКА";
            FirstStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/MainPageStagesImages/FirstStageSurvivor.png"));
            FirstStageTb.Text = "Чтобы включить ворота и сбежать, выжившие должны починить 5 из 7 генераторов, расположенных по всей карте. Проверки навыков будут появляться по мере того, как вы будете работать над генераторами. Если вы потерпите неудачу, убийца будет предупрежден, а ваш прогресс ремонта будет отброшен назад. Несколько выживших, работающих на одном генераторе одновременно ускоряют ремонт.";

            foreach (var rect in FirstStageGrid.Children)
            {
                (rect as Rectangle).Fill = MiscUtilities.SurvivorBrush;
            }

            SecondStageTitle.Text = "УКЛОНЕНИЕ";
            SecondStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/MainPageStagesImages/SecondStageSurvivor.png"));
            SecondStageTb.Text = "Большинство убийц быстрее, чем выжившие. Избегайте бега по прямой. Вместо этого бросайте паллеты на пути убийцы, ослепляйте их фонариком или прыгайте через окна, чтобы сбежать. Бег оставляет следы, которые видит убийца. Ходите, приседайте или прячьтесь в шкафчиках, чтобы избежать обнаружения. Чем дольше погоня, тем больше времени у ваших союзников есть на то, чтобы сосредоточиться на генераторах.";

            foreach (var rect in SecondStageGrid.Children)
            {
                (rect as Rectangle).Fill = MiscUtilities.SurvivorBrush;
            }

            ThirdStageTitle.Text = "ПОБЕГ";
            ThirdStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/MainPageStagesImages/ThirdStageSurvivor.png"));
            ThirdStageTb.Text = "Если убийца ударит вас дважды, вы войдете в предсмертное состояние, где вас могут поднять и насадить на жертвенный крюк. Попытайтесь освободиться во время переноски. Если вы попадете на крюк, вам придется положиться на своих союзников, которые должны спасти вас до того, как жертва будет завершена. Помогите друг другу остаться в живых, ремонтируйте генераторы и включайте выходные ворота, чтобы сбежать до того, как истечет время.";

            foreach (var rect in ThirdStageGrid.Children)
            {
                (rect as Rectangle).Fill = MiscUtilities.SurvivorBrush;
            }

            IconStageImage.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/SurvIcon.png"));

            RecGradientTop.Fill = MiscUtilities.SurvivorBrush;
            RecGradientDown.Fill = MiscUtilities.SurvivorBrush;

            ContentStackPanel.BeginAnimation(OpacityProperty, MiscUtilities.AppearOpacityAnimation);
        }

        private void YouTubeBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCaSgsFdGbwjfdawl3rOXiwQ");
        }

        private void TwitterBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://twitter.com/DeadbyDaylight");
        }

        private void TwitchBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.twitch.tv/deadbydaylight");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
 
    }
}
