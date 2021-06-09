using EJournalBLL;
using EJournalBLL.Models;
using EJournalDAL.Repository;
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
    /// Interaction logic for EditGroupWindow.xaml
    /// </summary>
    public partial class EditGroupWindow : Window
    {
        public List<Student> Students { get; set; }
        public Group Group { get; set; }

        private StudentService _studentService;

        public EditGroupWindow(Group group)
        {
            InitializeComponent();
            _studentService = new StudentService();
            Group = group;
            GroupNameTextBox.Text = Group.Name;

            Students = _studentService.GetStudentsNotAreInGroup(Group.Id);
            PrintAllStudents();
            PrintGroupStudent();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            _studentService.UpdateGroupStudents(Group.Id ,Group.Students);
            this.Close();
        }

        private void StudentCard_AddStudentToGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is StudentCard)
            {
                StudentCard studentCard = (StudentCard)sender;
                Student student = studentCard.Student;

                Group.Students.Add(student);
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

                Group.Students.Remove(student);
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

            foreach (var s in Group.Students)
            {
                StudentCard studentCard = new StudentCard(s);
                studentCard.MouseDown += StudentCard_DeleteStudentFromGroup_Click;

                GroupStudentsWrapPanel.Children.Add(studentCard);
            }
        }
    }
}
