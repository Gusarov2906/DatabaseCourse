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
    /// Логика взаимодействия для AddAndUpdateStudentWindow.xaml
    /// </summary>
    public partial class AddAndUpdateStudentWindow : Window
    {
        private bool IsAdd { get; set; }
        public AddAndUpdateStudentWindow(bool isAdd)
        {
            this.IsAdd = isAdd;
            InitializeComponent();
            if (!IsAdd)
            {
                Button.Content = "Обновить";
                TitleLabel.Content = "Обновление студента";
            }
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    if (PersonIDTextbox.Text != "" && NumberStudentCardTextbox.Text != "" && GroupNumberTextbox.Text != "")
                    {
                        Data.Student student = new Data.Student(Convert.ToInt32(NumberStudentCardTextbox.Text), Convert.ToInt32(PersonIDTextbox.Text), GroupNumberTextbox.Text);
                        Data.Database.AddStudentToDB(student);
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Content = "Не все поля заполнены!";
                        ErrorLabel.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    Data.Student student = new Data.Student(Convert.ToInt32(NumberStudentCardTextbox.Text), Convert.ToInt32(PersonIDTextbox.Text), GroupNumberTextbox.Text);
                    Data.Database.UpdateStudentInDB(student);
                    this.Close();
                }
            }
            catch (Exception err)
            {
                ErrorLabel.Content = err.Message;
                ErrorLabel.Visibility = Visibility.Visible;
            }
        }
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsAdd)
            {
                MainWindow.isAddingWindowOpened = false;
            }
            else
            {
                MainWindow.isUpdatingWindowOpened = false;
            }
        }
    }
}
