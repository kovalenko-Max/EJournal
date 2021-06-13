using EJournalBLL.Models;
using EJournalBLL.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private StudentService _studentServices;
        private CommentsService _commentsService;
        public StudentCard StudentCard;
        public event EventHandler StudentDeleted;
        public List<Comment> Comments { get; set; }
        public Student Student { get; set; }
        public StudentWindow(StudentCard studentCard)
        {
            InitializeComponent();
            _studentServices = new StudentService();
            _commentsService = new CommentsService();
            StudentCard = studentCard;
            Student = studentCard.Student;

            Comments = _commentsService.GetCommentsByStudent(Student.Id);

            TextBox_Name.Text = Student.Name;
            TextBox_Surname.Text = Student.Surname;
            TextBox_Email.Text = Student.Email;
            TextBox_Phone.Text = Student.Phone;
            TextBox_Git.Text = Student.Git;
            TextBox_City.Text = Student.City;
            TextBox_Agreement.Text = Student.AgreementNumber;
            TextBox_TeacherAssessment.Text = Student.TeacherAssessment.ToString();
            TextBlock_Rating.Text = Student.Ranking.ToString();

            PrintComments();
        }

        private void PrintComments()
        {
            foreach (var comment in Comments)
            {
                CommentStackPannel.Children.Add(new CommentCard(comment));
            }
        }

        private void Button_EditStudent_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Name.IsReadOnly = false;
            TextBox_Surname.IsReadOnly = false;
            TextBox_Email.IsReadOnly = false;
            TextBox_Phone.IsReadOnly = false;
            TextBox_Git.IsReadOnly = false;
            TextBox_City.IsReadOnly = false;
            TextBox_Agreement.IsReadOnly = false;
            TextBox_TeacherAssessment.IsReadOnly = false;
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
            int teacherAssessment;
            if (Int32.TryParse(TextBox_TeacherAssessment.Text, out teacherAssessment))
            {
                Student.TeacherAssessment = teacherAssessment;
            }
            Student.AgreementNumber = TextBox_Agreement.Text;
            TextBox_Name.IsReadOnly = true;
            TextBox_Surname.IsReadOnly = true;
            TextBox_Email.IsReadOnly = true;
            TextBox_Phone.IsReadOnly = true;
            TextBox_Git.IsReadOnly = true;
            TextBox_City.IsReadOnly = true;
            TextBox_Agreement.IsReadOnly = true;

            TextBox_TeacherAssessment.IsReadOnly = true;

            _studentServices.Update(Student);
            StudentCard.UpdateFields();
        }

        private void Button_DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentCard != null)
            {
                if (MessageBox.Show("Are you sure want to delete item?", "Delete confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _studentServices.Delete(StudentCard.Student.Id);

                    StudentDeleted?.Invoke(this, new EventArgs());

                    this.Close();
                }
            }
        }

        private void Button_AddComment_Click(object sender, RoutedEventArgs e)
        {
            Comment comment = new Comment();
            CommentCard commentCard = new CommentCard(comment);
            CommentStackPannel.Children.Add(commentCard);
            new CommentsService().AddComment(comment, Student);
        }

        private void TextBox_Phone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}