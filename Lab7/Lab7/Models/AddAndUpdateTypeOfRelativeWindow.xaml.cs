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
    /// Логика взаимодействия для AddAndUpdateTypeOfRelativeWindow.xaml
    /// </summary>
    public partial class AddAndUpdateTypeOfRelativeWindow : Window
    {
        private bool IsAdd { get; set; }
        public AddAndUpdateTypeOfRelativeWindow(bool isAdd)
        {
            this.IsAdd = isAdd;
            InitializeComponent();
            if (!IsAdd)
            {
                Button.Content = "Обновить";
                TitleLabel.Content = "Обновление вида родственных связей";
            }
        }
        

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    if (TypeTextbox.Text != "")
                    {
                        Data.TypeOfRelative typeOfRelative = new Data.TypeOfRelative(Data.Database.idStruct.TypeOfRelativeId + 1, TypeTextbox.Text);
                        Data.Database.AddTypeOfRelativeToDB(typeOfRelative);
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
                    Data.TypeOfRelative typeOfRelative = new Data.TypeOfRelative(MainWindow.curId, TypeTextbox.Text);
                    Data.Database.UpdateTypeOfRelativeInDB(typeOfRelative);
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
            if(IsAdd)
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
