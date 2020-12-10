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
    /// Логика взаимодействия для AddAndUpdatePersonWindow.xaml
    /// </summary>
    public partial class AddAndUpdatePersonWindow : Window
    {
        private bool IsAdd { get; set; }
        public AddAndUpdatePersonWindow(bool isAdd)
        {
            this.IsAdd = isAdd;
            InitializeComponent();
            if (!IsAdd)
            {
                Button.Content = "Обновить";
                TitleLabel.Content = "Обновление персоны";
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    if (SurnameTextbox.Text != "" && NameTextbox.Text != "" && PatronymicTextbox.Text != "" && DateOfBirthTextbox.Text != "" && GenderCombobox.Text != ""  && AddressTextbox.Text != "")
                    {
                        Data.Person person = new Data.Person(Data.Database.idStruct.PersonId + 1, SurnameTextbox.Text, NameTextbox.Text, PatronymicTextbox.Text, DateOfBirthTextbox.Text, GenderCombobox.Text, AddressTextbox.Text);
                        Data.Database.AddPersonToDB(person);
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
                    if (SurnameTextbox.Text != "" && NameTextbox.Text != "" && PatronymicTextbox.Text != "" && DateOfBirthTextbox.Text != "" && GenderCombobox.Text != "" && AddressTextbox.Text != "")
                    {
                        Data.Person person = new Data.Person(MainWindow.curId, SurnameTextbox.Text, NameTextbox.Text, PatronymicTextbox.Text, DateOfBirthTextbox.Text, GenderCombobox.Text, AddressTextbox.Text);
                        Data.Database.UpdatePersonInDB(person);
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
