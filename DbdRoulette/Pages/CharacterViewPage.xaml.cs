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
    /// Логика взаимодействия для CharacterViewPage.xaml
    /// </summary>
    public partial class CharacterViewPage : Page
    {
        object contextCharacter;

        public CharacterViewPage(Object obj)
        {
            InitializeComponent();
            contextCharacter = obj;
            DataContext = contextCharacter;
            
            if(contextCharacter is Survivor)
            {
                ColorTitleGrid.Background = new SolidColorBrush(Color.FromRgb(45, 99, 161));
                ColorPolyDarkStop.Color = Color.FromRgb(29, 67, 120);
                ColorPolyLightStop.Color = Color.FromRgb(46, 98, 160);

                RoleIcon.Source = new BitmapImage(new Uri("pack://application:,,,/DbdRoulette;component/Resources/Misc/SurvIcon.png"));
                RoleTitle.Text = "Выживший";

                StDifficulty.Visibility = Visibility.Collapsed;
                PowerAndPerksHeader.Text = "НАВЫКИ";
                PerkDemoBtn.Foreground = new SolidColorBrush(Color.FromRgb(56, 129, 239));
                RadioPower.Foreground = new SolidColorBrush(Color.FromRgb(56, 129, 239));
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
