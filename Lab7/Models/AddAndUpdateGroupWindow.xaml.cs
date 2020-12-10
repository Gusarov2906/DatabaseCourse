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
    /// Логика взаимодействия для AddAndUpdateGroupWindow.xaml
    /// </summary>
    public partial class AddAndUpdateGroupWindow : Window
    {
        private bool IsAdd { get; set; }
        public AddAndUpdateGroupWindow(bool isAdd)
        {
            this.IsAdd = isAdd;
            InitializeComponent();
            if (!IsAdd)
            {
                Button.Content = "Обновить";
                TitleLabel.Content = "Обновление группы";
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    if (GroupNumberTextbox.Text != "" && IdFacultyTextbox.Text != "" && StudentsNumberTextbox.Text != "")
                    {
                        Data.Group group = new Data.Group(GroupNumberTextbox.Text, Convert.ToInt32(IdFacultyTextbox.Text), Convert.ToInt32(StudentsNumberTextbox.Text));
                        Data.Database.AddGroupToDB(group);
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
                    if (GroupNumberTextbox.Text != "" && IdFacultyTextbox.Text != "" && StudentsNumberTextbox.Text != "")
                    {
                        Data.Group group = new Data.Group(GroupNumberTextbox.Text, Convert.ToInt32(IdFacultyTextbox.Text), Convert.ToInt32(StudentsNumberTextbox.Text));
                        Data.Database.UpdateGroupInDB(group);
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
