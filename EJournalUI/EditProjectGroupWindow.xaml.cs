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
    /// Interaction logic for EditProjectGroupWindow.xaml
    /// </summary>
    public partial class EditProjectGroupWindow : Window
    {
        private StudentService _studentServices;

        private ProjectGroupSevice _projectGroupServices;
        public ProjectGroup ProjectGroup { get; set; }
        //pub Action PrintStudents ();

        public StudentCard StudentCard;

        public EditProjectGroupWindow(ProjectGroup projectGroup)
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _studentServices = new StudentService(ConnectionString);
            _projectGroupServices = new ProjectGroupSevice();
            ProjectGroup = projectGroup;
            ProjectGroupTextBox.Text = projectGroup.Name;
            PrintAllStudentsFromDB();
            PrintProjectGroupStudentsFromDB();
        }

       
        public void PrintAllStudentsFromDB()
        {
            AllStudentsWrapPanel.Children.Clear();
            foreach (Student student in _studentServices.GetStudentsNotAreInProjectGroups(ProjectGroup.Id))
            {
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                AllStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        public void PrintProjectGroupStudentsFromDB()
        {
            TeamStudentsWrapPanel.Children.Clear();
            foreach (Student student in _studentServices.GetStudentsFromProjectGroups(ProjectGroup.Id))
            {
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += StudentCardMouseLeftButtonDown;
                TeamStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        public void SelectStudentCard(StudentCard studentCard)
        {
            HighlightSelectedStudentCard(studentCard);
            AddOrRemoveStudentFromProjectTeam(studentCard.Student);
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
                AllGroupsWindow allGroupsWindow = new AllGroupsWindow();
                allGroupsWindow.PrintAllProjectGroupsFromDB(ProjectGroup.IdProject);
                allGroupsWindow.PrintStudentsFromProjectGroup(ProjectGroup);

            }
        }

        private void AddOrRemoveStudentFromProjectTeam(Student studentInput)
        {
            TeamStudentsWrapPanel.Children.Clear();
            ProjectGroupStudent projectGroupStudent = new ProjectGroupStudent
            { IdStudent = studentInput.Id, IdProjectGroup = ProjectGroup.Id };

            if (ProjectGroup.Students.Contains(studentInput))
            {
                DeleteStudent(projectGroupStudent);
                ProjectGroup.Students.Remove(studentInput);
            }
            else
            {
                AddStudent(projectGroupStudent);
                ProjectGroup.Students.Add(studentInput);
            }
         
        }

        private void AddStudent(ProjectGroupStudent projectGroupStudent)
        {
            _projectGroupServices.AddStudentToProjectGroup(projectGroupStudent);
        }

        private void DeleteStudent(ProjectGroupStudent projectGroupStudent)
        {
            _projectGroupServices.DeleteStudentFromProjectGroup(projectGroupStudent);
        }



    }
}
