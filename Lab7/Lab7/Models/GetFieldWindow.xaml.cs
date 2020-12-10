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
    /// Логика взаимодействия для GetFieldWindow.xaml
    /// </summary>
    public partial class GetFieldWindow : Window
    {
        public GetFieldWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ParamTextbox.Text != "")
                {
                    RequestsWindow.param = ParamTextbox.Text;
                    this.Close();
                }
                else
                {
                    ErrorLabel.Content = "Не все поля заполнены!";
                    ErrorLabel.Visibility = Visibility.Visible;
                }

            }

            catch (Exception err)
            {
                ErrorLabel.Content = err.Message;
                ErrorLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
