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
    /// Логика взаимодействия для AddAndUpdateFacultyWindow.xaml
    /// </summary>
    public partial class AddAndUpdateFacultyWindow : Window
    {
        private bool IsAdd { get; set; }
        public AddAndUpdateFacultyWindow(bool isAdd)
        {
            this.IsAdd = isAdd;
            InitializeComponent();
            if (!IsAdd)
            {
                Button.Content = "Обновить";
                TitleLabel.Content = "Обновление факультета";
            }
            
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    if (FacultyNameTextbox.Text != "" && DeanNameTextbox.Text != "" && DeaneryTextbox.Text != "" )
                    {
                        Data.Faculty faculty  = new Data.Faculty(Data.Database.idStruct.FacultyId + 1, FacultyNameTextbox.Text, DeanNameTextbox.Text, DeaneryTextbox.Text);
                        Data.Database.AddFacultyToDB(faculty);
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
                    if (FacultyNameTextbox.Text != "" && DeanNameTextbox.Text != "" && DeaneryTextbox.Text != "")
                    {
                        Data.Faculty faculty = new Data.Faculty(MainWindow.curId, FacultyNameTextbox.Text, DeanNameTextbox.Text, DeaneryTextbox.Text);
                        Data.Database.UpdateFacultyInDB(faculty);
                        this.Close();
                    }
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
