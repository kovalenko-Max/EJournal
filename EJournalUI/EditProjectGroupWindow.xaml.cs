using EJournalBLL;
using EJournalBLL.Models;
using EJournalBLL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for EditProjectGroupWindow.xaml
    /// </summary>
    public partial class EditProjectGroupWindow : Window
    {
        private StudentService _studentServices;
        private ProjectGroupSevice _projectGroupServices;
        private CommentsService _commentService;

        public ProjectGroup ProjectGroup { get; set; }
        public Action PrintStudents { get; set; }
        public List<Student> studentsList { get; set; }
        public StudentCard StudentCard { get; set; }

        public EditProjectGroupWindow(ProjectGroup projectGroup)
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _studentServices = new StudentService();
            _projectGroupServices = new ProjectGroupSevice();
            _commentService = new CommentsService();
            ProjectGroup = projectGroup;
            ProjectGroupTextBox.Text = projectGroup.Name;
            MarkTextBox.Text = projectGroup.Mark.ToString();
            studentsList = _studentServices.GetStudentsNotAreInProjectGroups(ProjectGroup.Id);
            PrintStudents += PrintAllStudents;
            SearchComboBox.ItemsSource = Enum.GetValues(typeof(SearchTypeInGroups)).Cast<SearchTypeInGroups>();
            SearchComboBox.SelectedItem = (SearchTypeInGroups)0;
            PrintStudents += PrintProjectGroupStudents;
            PrintStudents.Invoke();
        }

        private void PrintAllStudents()
        {
            AllStudentsWrapPanel.Children.Clear();
            foreach (Student student in studentsList)
            {
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                AllStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void PrintProjectGroupStudents()
        {
            TeamStudentsWrapPanel.Children.Clear();
            foreach (Student student in ProjectGroup.Students)
            {
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                TeamStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void SelectStudentCard(StudentCard studentCard)
        {
            HighlightSelectedStudentCard(studentCard);
            AddOrRemoveStudentFromProjectGroup(studentCard.Student);
        }

        private void StudentCardMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StudentCard)
            {
                if (e.ClickCount == 1)
                {
                    SelectStudentCard((StudentCard)sender);
                }
            }
        }

        private void HighlightSelectedStudentCard(StudentCard studentCard)
        {
            if (StudentCard != null)
            {
                StudentCard.Background = Brushes.White;
            }

            StudentCard = studentCard;
            BrushConverter brushConverter = new BrushConverter();
            StudentCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectGroupTextBox.Text != string.Empty)
            {
                ProjectGroup.Name = ProjectGroupTextBox.Text;
                ProjectGroup.Mark = Convert.ToInt32(MarkTextBox.Text);
                _projectGroupServices.UpdateProjectGroup(ProjectGroup);

                if (TeamCommentsTextBox.Text != string.Empty)
                {
                    Comment comments = new Comment
                    {
                        Comments = TeamCommentsTextBox.Text,
                        CommentTypeValue = CommentType.Group
                    };

                    _commentService.AddCommentToStudent(comments, ProjectGroup.Students);
                }

                ProjectGroupWindow.Close();
            }
        }

        private void AddOrRemoveStudentFromProjectGroup(Student studentInput)
        {
            TeamStudentsWrapPanel.Children.Clear();
            if (ProjectGroup.Students.Contains(studentInput))
            {
                studentsList.Add(studentInput);
                ProjectGroup.Students.Remove(studentInput);
            }
            else
            {
                studentsList.Remove(studentInput);
                ProjectGroup.Students.Add(studentInput);
            }
            PrintStudents.Invoke();
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text;

            switch (SearchComboBox.SelectedItem)
            {
                case SearchTypeInGroups.Name:
                    {
                        var selectedUsers = from Student in studentsList
                                            where (Student.Surname + " " + Student.Name).Contains(search)
                                            select Student;

                        AllStudentsWrapPanel.Children.Clear();
                        foreach (var s in selectedUsers)
                        {
                            StudentCard studentCard = new StudentCard(s);
                            AllStudentsWrapPanel.Children.Add(studentCard);
                            studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                        }

                        break;
                    }
                case SearchTypeInGroups.Email:
                    {
                        var selectedUsers = from Student in studentsList
                                            where Student.Email.Contains(search)
                                            select Student;

                        AllStudentsWrapPanel.Children.Clear();
                        foreach (var s in selectedUsers)
                        {
                            StudentCard studentCard = new StudentCard(s);
                            AllStudentsWrapPanel.Children.Add(studentCard);
                            studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                        }

                        break;
                    }

                case SearchTypeInGroups.Phone:
                    {
                        var selectedUsers = from Student in studentsList
                                            where Student.Phone.Contains(search)
                                            select Student;

                        AllStudentsWrapPanel.Children.Clear();
                        foreach (var s in selectedUsers)
                        {
                            StudentCard studentCard = new StudentCard(s);
                            AllStudentsWrapPanel.Children.Add(studentCard);
                            studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                        }

                        break;
                    }
                case SearchTypeInGroups.City:
                    {
                        var selectedUsers = from Student in studentsList
                                            where Student.City != null && Student.City.Contains(search)
                                            select Student;

                        AllStudentsWrapPanel.Children.Clear();
                        foreach (var s in selectedUsers)
                        {
                            StudentCard studentCard = new StudentCard(s);
                            AllStudentsWrapPanel.Children.Add(studentCard);
                            studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                        }

                        break;
                    }
                case SearchTypeInGroups.AgreementNumber:
                    {
                        var selectedUsers = from Student in studentsList
                                            where Student.AgreementNumber.Contains(search)
                                            select Student;

                        AllStudentsWrapPanel.Children.Clear();
                        foreach (var s in selectedUsers)
                        {
                            StudentCard studentCard = new StudentCard(s);
                            AllStudentsWrapPanel.Children.Add(studentCard);
                            studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                        }

                        break;
                    }
            }
        }

        private void MarkTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9][0-9]?$|^100$");
            string futureText = ((TextBox)sender).Text + e.Text;

            if (regex.IsMatch(futureText))
            {
                e.Handled = !regex.IsMatch(e.Text);
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
