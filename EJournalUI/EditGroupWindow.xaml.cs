using EJournalBLL.Models;
using EJournalBLL.Services;
using EJournalDAL.Repository;
using System.Collections.Generic;
using System.Windows;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for EditGroupWindow.xaml
    /// </summary>
    public partial class EditGroupWindow : Window
    {
        public List<Student> Students { get; set; }

        public GroupCard GroupCard { get; set; }

        private StudentService _studentService;
        private GroupsService _groupsService;

        public EditGroupWindow(GroupCard groupCard)
        {
            InitializeComponent();

            GroupCard = groupCard;
            GroupNameTextBox.Text = GroupCard.Group.Name;

            _studentService = new StudentService();
            Students = _studentService.GetStudentsNotAreInGroup(GroupCard.Group.Id);

            CoursesService coursesService = new CoursesService(new CoursesRepository());
            CourseComboBox.ItemsSource = coursesService.Courses;
            CourseComboBox.SelectedItem = GroupCard.Group.Course;

            PrintAllStudents();
            PrintGroupStudent();

            AcceptButton.Click += Button_Edit_Accept_Click;
        }

        public EditGroupWindow()
        {
            InitializeComponent();
            DeleteGroupButton.Visibility = Visibility.Hidden;
            _groupsService = new GroupsService();

            CoursesService coursesService = new CoursesService(new CoursesRepository());
            CourseComboBox.ItemsSource = coursesService.Courses;
            CourseComboBox.SelectedItem = coursesService.Courses[0];

            Group group = new Group(string.Empty, coursesService.Courses[0]);
            GroupCard = new GroupCard(group);

            _studentService = new StudentService();
            Students = _studentService.GetAllStudent();
            PrintAllStudents();

            AcceptButton.Click += Button_Create_Accept_Click;
        }

        private void Button_Create_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (GroupNameTextBox.Text != string.Empty && CourseComboBox.SelectedItem is Course)
            {
                GroupCard.Group.Name = GroupNameTextBox.Text;
                GroupCard.Group.Course = (Course)CourseComboBox.SelectedItem;

                _groupsService.AddGroupAndStudentsToDB(GroupCard.Group, GroupCard.Group.Students);
                //_groupsService.UpdateGroupStudents(GroupCard.Group, GroupCard.Group.Students);
                DialogResult = true;

                this.Close();
            }
            else
            {
                MessageBox.Show("Group name must contain at least one character. \nSelect an existing course");
            }
        }

        private void Button_Edit_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (GroupNameTextBox.Text != string.Empty)
            {
                GroupCard.Group.Name = GroupNameTextBox.Text;

                if (CourseComboBox.SelectedItem is Course)
                {
                    GroupCard.Group.Course = (Course)CourseComboBox.SelectedItem;
                    GroupsService groupsService = new GroupsService();
                    groupsService.UpdateGroupStudents(GroupCard.Group, GroupCard.Group.Students);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select an existing course");
                }
            }
            else
            {
                MessageBox.Show("Group name must contain at least one character");
            }
        }

        private void StudentCard_AddStudentToGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is StudentCard)
            {
                StudentCard studentCard = (StudentCard)sender;
                Student student = studentCard.Student;

                GroupCard.Group.Students.Add(student);
                AllStudentsWrapPanel.Children.Remove(studentCard);
                GroupStudentsWrapPanel.Children.Add(studentCard);

                studentCard.MouseDown -= StudentCard_AddStudentToGroup_Click;
                studentCard.MouseDown += StudentCard_DeleteStudentFromGroup_Click;
            }
        }

        private void StudentCard_DeleteStudentFromGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is StudentCard)
            {
                StudentCard studentCard = (StudentCard)sender;
                Student student = studentCard.Student;

                GroupCard.Group.Students.Remove(student);
                GroupStudentsWrapPanel.Children.Remove(studentCard);
                AllStudentsWrapPanel.Children.Add(studentCard);

                studentCard.MouseDown -= StudentCard_DeleteStudentFromGroup_Click;
                studentCard.MouseDown += StudentCard_AddStudentToGroup_Click;
            }
        }

        private void PrintAllStudents()
        {
            AllStudentsWrapPanel.Children.Clear();

            foreach (var s in Students)
            {
                StudentCard studentCard = new StudentCard(s);
                AllStudentsWrapPanel.Children.Add(studentCard);
                studentCard.MouseDown += StudentCard_AddStudentToGroup_Click;
            }
        }

        private void PrintGroupStudent()
        {
            GroupStudentsWrapPanel.Children.Clear();

            foreach (var s in GroupCard.Group.Students)
            {
                StudentCard studentCard = new StudentCard(s);
                studentCard.MouseDown += StudentCard_DeleteStudentFromGroup_Click;

                GroupStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void Button_DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            GroupsService groupsService = new GroupsService();
            if (GroupCard != null)
            {
                if (MessageBox.Show("Are you sure want to delete item?", "Delete confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    groupsService.DeleteGroup(GroupCard.Group);
                    GroupCard.DeleteGroupCard();
                    this.Close();
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GroupsService groupsService = new GroupsService();
            string search = "";
            string caseSwitch = "";
            switch (caseSwitch)
            {
                case "Email":
                    {
                        foreach (Student student in Students)
                        {
                            if (student.Email != search):
                            {
                                student.Email.Remove();
                            }
                        }
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in Students)
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "Name":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsByName(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "Surname":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsBySurname(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "Phone":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsByPhone(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "City":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsByCity(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "AllStudents":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsAllStudents())
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "AgreementNumber":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsAgreementNumbers(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "Group":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsGroup(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case "Courses":
                    {
                        GroupStudentsWrapPanel.Children.Clear();
                        foreach (Student student in groupsService.SearchStudentsCourses(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            GroupStudentsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
            }
        }
    }
}
