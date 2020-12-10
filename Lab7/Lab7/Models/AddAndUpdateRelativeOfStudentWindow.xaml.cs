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
    /// Логика взаимодействия для AddAndUpdateRelativeOfStudentWindow.xaml
    /// </summary>
    public partial class AddAndUpdateRelativeOfStudentWindow : Window
    {
        private bool IsAdd { get; set; }
        public AddAndUpdateRelativeOfStudentWindow(bool isAdd)
        {
            this.IsAdd = isAdd;
            InitializeComponent();
            if (!IsAdd)
            {
                Button.Content = "Обновить";
                TitleLabel.Content = "Обновление родственника студента";
            }
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    if (PersonIDTextbox.Text != "" && NumberStudentCardTextbox.Text != "" && IDTypeRelativeTextbox.Text != "")
                    {
                        Data.RelativeOfStudent relativeOfStudent = new Data.RelativeOfStudent(Data.Database.idStruct.RelativeOfStudentId + 1, Convert.ToInt32(PersonIDTextbox.Text), Convert.ToInt32(NumberStudentCardTextbox.Text), Convert.ToInt32(IDTypeRelativeTextbox.Text));
                        Data.Database.AddRelativeOfStudentToDB(relativeOfStudent);
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
                    Data.RelativeOfStudent person = new Data.RelativeOfStudent(MainWindow.curId, Convert.ToInt32(PersonIDTextbox.Text), Convert.ToInt32(NumberStudentCardTextbox.Text), Convert.ToInt32(IDTypeRelativeTextbox.Text));
                    Data.Database.UpdateRelativeOfStudentInDB(person);
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
