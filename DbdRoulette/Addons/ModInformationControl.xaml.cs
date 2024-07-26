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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbdRoulette.Addons
{
    /// <summary>
    /// Логика взаимодействия для ModInformationControl.xaml
    /// </summary>
    public partial class ModInformationControl : UserControl
    {
        public ModInformationControl()
        {
            InitializeComponent();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ModInformation.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ModInformation.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
        }
    }
}
