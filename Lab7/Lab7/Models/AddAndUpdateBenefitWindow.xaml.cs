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
    /// Логика взаимодействия для AddAndUpdateBenefitWindow.xaml
    /// </summary>
    public partial class AddAndUpdateBenefitWindow : Window
    {
        private bool IsAdd { get; set; }
        public AddAndUpdateBenefitWindow(bool isAdd)
        {
            this.IsAdd = isAdd;
            InitializeComponent();
            if (!IsAdd)
            {
                Button.Content = "Обновить";
                TitleLabel.Content = "Обновление льготы";
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    if (NumberStudentCardTextbox.Text != "" && BenefitTypeTextbox.Text != "" && BasisTextbox.Text != "" && DateTextbox.Text != "")
                    {
                        Data.Benefit benefit = new Data.Benefit(Data.Database.idStruct.BenefitId + 1,Convert.ToInt32(NumberStudentCardTextbox.Text), BenefitTypeTextbox.Text, BasisTextbox.Text, DateTextbox.Text);
                        Data.Database.AddBenefitToDB(benefit);
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
                    if (NumberStudentCardTextbox.Text != "" && BenefitTypeTextbox.Text != "" && BasisTextbox.Text != "" && DateTextbox.Text != "")
                    {
                        Data.Benefit benefit = new Data.Benefit(MainWindow.curId,Convert.ToInt32(NumberStudentCardTextbox.Text), BenefitTypeTextbox.Text, BasisTextbox.Text, DateTextbox.Text);
                        Data.Database.UpdateBenefitInDB(benefit);
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
