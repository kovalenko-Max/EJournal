using EJournalBLL.Models;
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

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public Student student;
        public EditStudentWindow()
        {
            InitializeComponent();
        }

        private void Button_ConfirmAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (student is null)
            {
                student = new Student(TextBox_Name.Text, TextBox_Surname.Text, TextBox_Email.Text, TextBox_Phone.Text, TextBox_Git.Text, TextBox_City.Text, TextBox_AgreementNumber.Text);
            }
            else
            {
                student.Name = TextBox_Name.Text;
                student.Surname = TextBox_Surname.Text;
                student.Email = TextBox_Email.Text;
                student.Phone = TextBox_Phone.Text;
                student.Git = TextBox_Git.Text;
                student.City = TextBox_City.Text;
                student.AgreementNumber = TextBox_AgreementNumber.Text;
            }
            this.DialogResult = true;
        }
    }
}
