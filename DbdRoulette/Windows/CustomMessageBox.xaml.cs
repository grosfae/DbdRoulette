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
using System.Windows.Shapes;

namespace DbdRoulette.Windows
{
    /// <summary>
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        static CustomMessageBox customMessageBox;
        static DialogResult result = System.Windows.Forms.DialogResult.No;
        public CustomMessageBox()
        {
            InitializeComponent();
            Header.MouseLeftButtonDown += new MouseButtonEventHandler(Window_MouseDown);

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.Yes;
            customMessageBox.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.No;
            customMessageBox.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.No;
            customMessageBox.Close();
        }
        public string GetTitle(CustomMessageBoxTitle value)
        {
            return Enum.GetName(typeof(CustomMessageBoxTitle), value);
        }

        public string GetMessageButton(CustomMessageBoxButton value)
        {
            return Enum.GetName(typeof(CustomMessageBoxButton), value);
        }

        public enum CustomMessageBoxButton
        {
            Хорошо,
            Нет,
            Да,
            Отмена,
            Confirm
        }
        public enum CustomMessageBoxTitle
        {
            Error,
            Warning,
            Подтверждение,
            Предупреждение,
            Успешно
        }
        public static DialogResult Show(string message, CustomMessageBoxTitle title, CustomMessageBoxButton btnOk, CustomMessageBoxButton btnNo)
        {
            customMessageBox = new CustomMessageBox();
            customMessageBox.txtMessage.Text = message;
            customMessageBox.OkBtn.Content = customMessageBox.GetMessageButton(btnOk);
            customMessageBox.CancelBtn.Content = customMessageBox.GetMessageButton(btnNo);
            customMessageBox.txtTitle.Text = customMessageBox.GetTitle(title);

            switch (title)
            {
                case CustomMessageBoxTitle.Error:
                    break;

                case CustomMessageBoxTitle.Warning:
                    customMessageBox.CancelBtn.Visibility = Visibility.Collapsed;
                    customMessageBox.OkBtn.SetValue(Grid.ColumnSpanProperty, 2);
                    break;
                case CustomMessageBoxTitle.Подтверждение:
                    break;
                case CustomMessageBoxTitle.Предупреждение:
                    customMessageBox.CancelBtn.Visibility = Visibility.Collapsed;
                    customMessageBox.txtMessage.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    customMessageBox.txtMessage.SetValue(Grid.ColumnProperty, 0);
                    customMessageBox.txtMessage.SetValue(Grid.ColumnSpanProperty, 2);
                    customMessageBox.OkBtn.SetValue(Grid.ColumnSpanProperty, 2);
                    break;
                case CustomMessageBoxTitle.Успешно:
                    customMessageBox.CancelBtn.Visibility = Visibility.Collapsed;
                    customMessageBox.OkBtn.SetValue(Grid.ColumnSpanProperty, 2);
                    break;
            }
            customMessageBox.ShowDialog();
            return result;
        }
    }
}
