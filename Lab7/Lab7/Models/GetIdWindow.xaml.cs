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
    /// Логика взаимодействия для GetIdWindow.xaml
    /// </summary>
    public partial class GetIdWindow : Window
    {
        private string Type = "";
        public GetIdWindow(string type)
        {
            InitializeComponent();
            this.Type = type;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IDTextbox.Equals(""))
                {
                    switch (Type)
                    {
                        case "Person":
                            MainWindow.curId = Convert.ToInt32(IDTextbox.Text);
                            new AddAndUpdatePersonWindow(false).Show();
                            break;
                        case "Student":
                            MainWindow.curId = Convert.ToInt32(IDTextbox.Text);
                            new AddAndUpdateStudentWindow(false).Show();
                            break;
                        case "Relative of student":
                            MainWindow.curId = Convert.ToInt32(IDTextbox.Text);
                            new AddAndUpdateRelativeOfStudentWindow(false).Show();
                            break;
                        case "Type of relative":
                            MainWindow.curId = Convert.ToInt32(IDTextbox.Text);
                            new AddAndUpdateTypeOfRelativeWindow(false).Show();
                            break;
                        case "Benefit":
                            MainWindow.curId = Convert.ToInt32(IDTextbox.Text);
                            new AddAndUpdateBenefitWindow(false).Show();
                            break;
                        case "Group":
                            MainWindow.curGroupNum = IDTextbox.Text;
                            new AddAndUpdateGroupWindow(false).Show();
                            break;
                        case "Faculty":
                            MainWindow.curId = Convert.ToInt32(IDTextbox.Text);
                            new AddAndUpdateFacultyWindow(false).Show();
                            break;
                    }

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
