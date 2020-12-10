using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab7.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isAddingWindowOpened = false;
        public static bool isRemovingWindowOpened = false;
        public static bool isUpdatingWindowOpened = false;
        public static bool isRequestsWindowOpened = false;
        public static int curId = -1;
        public static string curGroupNum = "";
        public static DataTable MSysObjectsData =  new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            Data.Database.GetIdStruct("all");
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isAddingWindowOpened)
            {
                Data.Database.GetIdStruct(TypeOfTableCombobox.Text);
                switch (TypeOfTableCombobox.Text)
                {
                    case "Person":
                        new AddAndUpdatePersonWindow(true).Show();
                        break;
                    case "Student":
                        new AddAndUpdateStudentWindow(true).Show();
                        break;
                    case "Relative of student":
                        new AddAndUpdateRelativeOfStudentWindow(true).Show();
                        break;
                    case "Type of relative":
                        new AddAndUpdateTypeOfRelativeWindow(true).Show();
                        break;
                    case "Benefit":
                        new AddAndUpdateBenefitWindow(true).Show();
                        break;
                    case "Group":
                        new AddAndUpdateGroupWindow(true).Show();
                        break;
                    case "Faculty":
                        new AddAndUpdateFacultyWindow(true).Show();
                        break;
                    default:
                        return;
                }
                isAddingWindowOpened = true;
            }
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {   
            if (!isUpdatingWindowOpened)
            {
                switch (TypeOfTableCombobox.Text)
                {
            
                    case "Person":
                        new GetIdWindow("Person").Show();
                        break;
                    case "Student":
                        new AddAndUpdateStudentWindow(false).Show();
                        break;
                    case "Relative of student":
                        new GetIdWindow("Relative of student").Show();
                        break;
                    case "Type of relative":
                        new GetIdWindow("Type of relative").Show();
                        break;
                    case "Benefit":
                        new GetIdWindow("Benefit").Show();
                        break;
                    case "Group":
                        new AddAndUpdateGroupWindow(false).Show();
                        break;
                    case "Faculty":
                        new GetIdWindow("Faculty").Show();
                        break;
                    default:
                        break;
                 }
                isUpdatingWindowOpened = true;
             }
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isRemovingWindowOpened)
            {
                switch (TypeOfTableCombobox.Text)
                {

                    case "Person":
                        new RemoveWindow(" person").Show();
                        break;
                    case "Student":
                        new RemoveWindow(" student").Show();
                        break;
                    case "Relative of student":
                        new RemoveWindow(" relative of student").Show();
                        break;
                    case "Type of relative":
                        new RemoveWindow(" type of relative").Show();
                        break;
                    case "Benefit":
                        new RemoveWindow(" benefit").Show();
                        break;
                    case "Group":
                        new RemoveWindow(" group").Show();
                        break;
                    case "Faculty":
                        new RemoveWindow(" faculty").Show();
                        break;
                    default:
                        break;
                }
                isRemovingWindowOpened = true;
            }
        }

        private void ReloadButtonClick(object sender, RoutedEventArgs e)
        {
            Reload();
        }


        private void RequestsButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isRequestsWindowOpened)
            {
                new RequestsWindow().Show();
            }
            isRequestsWindowOpened = true;
        }

        private void MSysObjectsButtonClick(object sender, RoutedEventArgs e)
        {
            TableTitleLabel.Content = "MSysObjects";
            DataTable data = Data.Database.MSysObjectsRequest();
            DataTable.AutoGenerateColumns = true;
            DataTable.ItemsSource = data.DefaultView;
            DataTable.Items.Refresh();
        }


        public void Reload(object sender, SelectionChangedEventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            string[] temp = TypeOfTableCombobox.SelectedItem.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (temp[temp.Length - 1])
            {
                case "Person":
                    TableTitleLabel.Content = "Таблица Персона";
                    DataTable.AutoGenerateColumns = true;
                    Data.Database.GetPersons();
                    DataTable.ItemsSource = Data.Database.persons;
                    DataTable.Items.Refresh();
                    break;
                case "Student":
                    TableTitleLabel.Content = "Таблица Студент";
                    DataTable.AutoGenerateColumns = true;
                    Data.Database.GetStudents();
                    DataTable.ItemsSource = Data.Database.students;
                    DataTable.Items.Refresh();
                    break;
                case "student":
                    TableTitleLabel.Content = "Таблица Родственник студента";
                    DataTable.AutoGenerateColumns = true;
                    Data.Database.GetRelativeOfStudent();
                    DataTable.ItemsSource = Data.Database.relativeOfStudents;
                    DataTable.Items.Refresh();
                    break;
                case "relative":
                    TableTitleLabel.Content = "Таблица Вид родственников";
                    DataTable.AutoGenerateColumns = true;
                    Data.Database.GetTypeOfRelative();
                    DataTable.ItemsSource = Data.Database.typeOfRelatives;
                    DataTable.Items.Refresh();
                    break;
                case "Benefit":
                    TableTitleLabel.Content = "Таблица Льгота";
                    DataTable.AutoGenerateColumns = true;
                    Data.Database.GetBenefits();
                    DataTable.ItemsSource = Data.Database.benefits;
                    DataTable.Items.Refresh();
                    break;
                case "Group":
                    TableTitleLabel.Content = "Таблица Группа";
                    DataTable.AutoGenerateColumns = true;
                    Data.Database.GetGroups();
                    DataTable.ItemsSource = Data.Database.groups;
                    DataTable.Items.Refresh();
                    break;
                case "Faculty":
                    TableTitleLabel.Content = "Таблица Факультет";
                    DataTable.AutoGenerateColumns = true;
                    Data.Database.GetFaculties();
                    DataTable.ItemsSource = Data.Database.faculties;
                    DataTable.Items.Refresh();
                    break;
                default:
                    break;
            }
        }
    }
}
