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
    /// Логика взаимодействия для RemoveWindow.xaml
    /// </summary>
    public partial class RemoveWindow : Window
    {
        string type = "";
        public RemoveWindow(string str)
        {
            InitializeComponent();
            switch (str)
            {

                case " person":
                    TitleLabel.Content += " персоны";
                    break;
                case " student":
                    TitleLabel.Content += " студента";
                    break;
                case " relative of student":
                    TitleLabel.Content += " родственника студента";
                    break;
                case " type of relative":
                    TitleLabel.Content += " вида родственника";
                    break;
                case " benefit":
                    TitleLabel.Content += " льготы";
                    break;
                case " group":
                    TitleLabel.Content += " группы";
                    break;
                case " faculty":
                    TitleLabel.Content += " факультета";
                    break;
                default:
                    break;
            }
            this.type = str; 
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IDTextbox.Text != "")
                switch (type)
                {

                    case " person":
                            Data.Database.DeleteFromTableByID(Convert.ToInt32(IDTextbox.Text), "Персона");
                            this.Close();
                            break;
                    case " student":
                            Data.Database.DeleteFromTableByID(Convert.ToInt32(IDTextbox.Text), "Студент");
                            this.Close();
                            break;
                    case " relative of student":
                            Data.Database.DeleteFromTableByID(Convert.ToInt32(IDTextbox.Text), "Родственник студента");
                            this.Close();
                            break;
                    case " type of relative":
                            Data.Database.DeleteFromTableByID(Convert.ToInt32(IDTextbox.Text), "Вид родственников");
                            this.Close();
                            break;
                    case " benefit":
                            Data.Database.DeleteFromTableByID(Convert.ToInt32(IDTextbox.Text), "Льгота");
                            this.Close();
                            break;
                    case " group":
                            Data.Database.DeleteFromTableByID(IDTextbox.Text);
                            this.Close();
                            break;
                    case " faculty":
                            Data.Database.DeleteFromTableByID(Convert.ToInt32(IDTextbox.Text), "Факультет");
                            this.Close();
                            break;
                    default:
                        break;
                }
                else
                {
                    ErrorLabel.Content = "Не все поля заполнены!";
                    ErrorLabel.Visibility = Visibility.Visible;
                }
                
            }
            catch(Exception err)
            {
                ErrorLabel.Content = err.Message;
                ErrorLabel.Visibility = Visibility.Visible;
            }
        }
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isRemovingWindowOpened = false;
        }
    }
}
