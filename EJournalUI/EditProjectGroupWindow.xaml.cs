using EJournalBLL;
using EJournalBLL.Models;
using EJournalBLL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
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
        private CommentService _commentService;
        public ProjectGroup ProjectGroup { get; set; }
        public Action PrintStudents;
        public List<Student> studentsList;

        public StudentCard StudentCard;

        public EditProjectGroupWindow(ProjectGroup projectGroup)
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _studentServices = new StudentService();
            _projectGroupServices = new ProjectGroupSevice();
            _commentService = new CommentService();
            ProjectGroup = projectGroup;
            ProjectGroupTextBox.Text = projectGroup.Name;
            studentsList = _studentServices.GetStudentsNotAreInProjectGroups(ProjectGroup.Id);
            PrintStudents += PrintAllStudents;
            SearchComboBox.SelectedItem = NameTextBlock;
            PrintStudents += PrintProjectGroupStudents;
            PrintStudents.Invoke();
        }

        public EditProjectGroupWindow() 
        {

        }

        public void PrintAllStudents()
        {
            AllStudentsWrapPanel.Children.Clear();
            foreach (Student student in studentsList)
            {
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                AllStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        public void PrintProjectGroupStudents()
        {
            TeamStudentsWrapPanel.Children.Clear();
            foreach (Student student in ProjectGroup.Students)
            {
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                TeamStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        public void SelectStudentCard(StudentCard studentCard)
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
                _projectGroupServices.Update(ProjectGroup);
                if (TeamCommentsTextBox.Text != string.Empty)
                {
                    Comments comments = new Comments { Comment = TeamCommentsTextBox.Text, IdCommentType = 1, IsDelete = false, Students = ProjectGroup.Students };
                    _commentService.AddCommentsToStudent(comments);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text;
            string caseSwitch = SearchComboBox.Text;

            switch (caseSwitch)
            {
                case "Email":
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
                case "Name":
                    {
                        var selectedUsers = from Student in studentsList
                                            where Student.Name.Contains(search)
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
                case "Surname":
                    {
                        var selectedUsers = from Student in studentsList
                                            where Student.Surname.Contains(search)
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
                case "Phone":
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
                case "City":
                    {
                        var selectedUsers = from Student in studentsList
                                            where Student.City.Contains(search)
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
                case "AgreementNumber":
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

    }

}
