using EJournalBLL;
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

        public EditGroupWindow(GroupCard groupCard)
        {
            InitializeComponent();
            _studentService = new StudentService();
            CoursesService coursesService = new CoursesService(new CoursesRepository());
            GroupCard = groupCard;
            GroupNameTextBox.Text = GroupCard.Group.Name;

            Students = _studentService.GetStudentsNotAreInGroup(GroupCard.Group.Id);
            PrintAllStudents();
            PrintGroupStudent();
            CourseComboBox.ItemsSource = coursesService.Courses;
            CourseComboBox.SelectedItem = GroupCard.Group.Course;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
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
    }
}
