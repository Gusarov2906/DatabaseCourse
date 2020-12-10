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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab7.Windows
{
    /// <summary>
    /// Логика взаимодействия для RequestsWindow.xaml
    /// </summary>
    public partial class RequestsWindow : Window
    {
        public static string param = "";
        public RequestsWindow()
        {
           
            InitializeComponent();
            ErrorLabel.Content = "Введен некорретный запрос или запрашиваемые данные отстуствуют";
            ErrorLabel.Visibility = Visibility.Hidden;
        }
        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            DataTable.AutoGenerateColumns = true;
            Data.Database.Request1();
            DataTable.ItemsSource = Data.Database.groups;
            DataTable.Items.Refresh();
            ErrorLabel.Visibility = Visibility.Hidden;
        }
        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
            DataTable.AutoGenerateColumns = true;
            Data.Database.Request2();
            DataTable.ItemsSource = Data.Database.students;
            DataTable.Items.Refresh();
            ErrorLabel.Visibility = Visibility.Hidden;
        }
        private void ButtonClick3(object sender, RoutedEventArgs e)
        {
            DataTable.AutoGenerateColumns = true;
            Data.Database.Request3();
            DataTable.ItemsSource = Data.Database.groups;

            DataTable.Items.Refresh();
            ErrorLabel.Visibility = Visibility.Hidden;
        }
        private void ButtonClick4(object sender, RoutedEventArgs e)
        {
            if (Param1.Text != "")
            {
                DataTable.AutoGenerateColumns = true;
                Data.Database.Request4(Param1.Text);
                DataTable.ItemsSource = Data.Database.students;
                if (Data.Database.students.Count == 0)
                    ErrorLabel.Visibility = Visibility.Visible;
                else
                    ErrorLabel.Visibility = Visibility.Hidden;
                DataTable.Items.Refresh();
            }
            Param1.Text = "";
        }

        private void ButtonClick5(object sender, RoutedEventArgs e)
        {
            if (Param2.Text != "")
            {
                DataTable.AutoGenerateColumns = true;
                Data.Database.Request5(Param2.Text);
                DataTable.ItemsSource = Data.Database.groups;
                if (Data.Database.groups.Count == 0)
                    ErrorLabel.Visibility = Visibility.Visible;
                else
                    ErrorLabel.Visibility = Visibility.Hidden;
                DataTable.Items.Refresh();
            }
            Param2.Text = "";
        }
        private void ButtonClick6(object sender, RoutedEventArgs e)
        {
            if (Param3.Text != "")
            {
                DataTable.AutoGenerateColumns = true;
                Data.Database.Request6(Param3.Text);
                DataTable.ItemsSource = Data.Database.persons;
                if (Data.Database.persons.Count == 0)
                    ErrorLabel.Visibility = Visibility.Visible;
                else
                    ErrorLabel.Visibility = Visibility.Hidden;
                DataTable.Items.Refresh();
            }
            Param3.Text = "";
        }
        private void ButtonClick7(object sender, RoutedEventArgs e)
        {
            DataTable.AutoGenerateColumns = true;
            Data.Database.Request7();
            DataTable.ItemsSource = Data.Database.persons;
            DataTable.Items.Refresh();
            ErrorLabel.Visibility = Visibility.Hidden;
        }
        private void ButtonClick8(object sender, RoutedEventArgs e)
        {
            DataTable.AutoGenerateColumns = true;
            Data.Database.Request8();
            DataTable.ItemsSource = Data.Database.groups;
            DataTable.Items.Refresh();
            ErrorLabel.Visibility = Visibility.Hidden;
        }
        private void ButtonClick9(object sender, RoutedEventArgs e)
        {
            DataTable.AutoGenerateColumns = true;
            Data.Database.Request9();
            DataTable.ItemsSource = Data.Database.groups;
            DataTable.Items.Refresh();
            ErrorLabel.Visibility = Visibility.Hidden;
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            {
                MainWindow.isRequestsWindowOpened = false;
            }
        }
    }
}
