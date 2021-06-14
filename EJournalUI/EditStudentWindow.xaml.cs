using EJournalBLL.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public Student Student { get; set; }
        public EditStudentWindow()
        {
            InitializeComponent();

            TextBox_Name.MaxLength = 100;
            TextBox_Surname.MaxLength = 100;
            TextBox_Email.MaxLength = 100;
            TextBox_Phone.MaxLength = 16;
            TextBox_Git.MaxLength = 100;
            TextBox_City.MaxLength = 255;
            TextBox_AgreementNumber.MaxLength = 50;
        }

        private void Button_ConfirmAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

            if (Student is null && !String.IsNullOrEmpty(TextBox_Name.Text) &&
                !String.IsNullOrEmpty(TextBox_Surname.Text) &&
                !String.IsNullOrEmpty(TextBox_Email.Text) &&
                regex.IsMatch(TextBox_Email.Text) &&
                !String.IsNullOrEmpty(TextBox_Phone.Text))
            {
                Student = new Student(TextBox_Name.Text, TextBox_Surname.Text, TextBox_Email.Text, TextBox_Phone.Text, TextBox_Git.Text, TextBox_City.Text, TextBox_AgreementNumber.Text);
                MessageBox.Show("Student created");
                this.DialogResult = true;
            }
            else
            {
                if (regex.IsMatch(TextBox_Email.Text) == false)
                {
                    MessageBox.Show("Incorrect email format");
                }
                else
                {
                    MessageBox.Show("Name, Surname, Email and Phone are required fields. Please fill them to create a student");
                }
            }
        }

        private void TextBox_Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_Surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
