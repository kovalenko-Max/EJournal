using EJournalBLL;
using EJournalBLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private StudentServices _studentServices;
        public StudentCard StudentCard;
        public Student Student { get; set; }
        public StudentWindow(StudentCard studentCard)
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _studentServices = new StudentServices(ConnectionString);
            StudentCard = studentCard;
            Student = studentCard.Student;
            TextBox_Name.Text = Student.Name;
            TextBox_Surname.Text = Student.Surname;
            TextBox_Email.Text = Student.Email;
            TextBox_Phone.Text = Student.Phone;
            TextBox_Git.Text = Student.Git;
            TextBox_City.Text = Student.City;
            TextBox_Agreement.Text = Student.AgreementNumber;
        }

        private void Button_EditStudent_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Name.IsEnabled = true;
            TextBox_Surname.IsEnabled = true;
            TextBox_Email.IsEnabled = true;
            TextBox_Phone.IsEnabled = true;
            TextBox_Git.IsEnabled = true;
            TextBox_City.IsEnabled = true;
            TextBox_Agreement.IsEnabled = true;
            Button_SaveChanges.Visibility = Visibility.Visible;
            Button_SaveChanges.IsEnabled = true;
            Button_DeleteStudent.IsEnabled = false;
            Button_EditStudent.IsEnabled = false;
        }

        private void Button_SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Button_SaveChanges.Visibility = Visibility.Hidden;
            Button_SaveChanges.IsEnabled = false;
            Button_DeleteStudent.IsEnabled = true;
            Button_EditStudent.IsEnabled = true;
            Student.Name = TextBox_Name.Text;
            Student.Surname = TextBox_Surname.Text;
            Student.Email = TextBox_Email.Text;
            Student.Phone = TextBox_Phone.Text;
            Student.Git = TextBox_Git.Text;
            Student.City = TextBox_City.Text;
            Student.AgreementNumber = TextBox_Agreement.Text;
            TextBox_Name.IsEnabled = false;
            TextBox_Surname.IsEnabled = false;
            TextBox_Email.IsEnabled = false;
            TextBox_Phone.IsEnabled = false;
            TextBox_Git.IsEnabled = false;
            TextBox_City.IsEnabled = false;
            TextBox_Agreement.IsEnabled = false;
            _studentServices.Update(Student);
            StudentCard.UpdateFields();
        }

        private void Button_DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
                if (StudentCard != null)
                {
                    _studentServices.Delete(StudentCard.Student.Id);
                    StudentCard.Student.IsDelete = true;
                }
        }
    }
}