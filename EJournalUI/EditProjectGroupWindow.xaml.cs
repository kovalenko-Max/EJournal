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

        public StudentCard StudentCard;

        public EditProjectGroupWindow(ProjectGroup projectGroup)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _studentServices = new StudentService(ConnectionString);
            _projectGroupServices = new ProjectGroupSevice();
            ProjectGroup = projectGroup;
            TeamNameTextBox.Text = projectGroup.Name;
            InitializeComponent();
        }

        public void PrintAllStudentsFromDB()
        {
            AllStudentsWrapPanel.Children.Clear();
            foreach (Student student in _studentServices.GetAllStudent())
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
            if (TeamNameTextBox.Text != string.Empty)
            {
                ProjectGroup.Name = TeamNameTextBox.Text;
            }
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            if (StudentCard != null)
            {
                if (AllStudentsWrapPanel.Children.Contains(StudentCard))
                {
                    TeamStudentsWrapPanel.Children.Add(StudentCard);
                    AllStudentsWrapPanel.Children.Remove(StudentCard);
                    ProjectGroup.Students.Add(StudentCard.Student);
                }
                else if (TeamStudentsWrapPanel.Children.Contains(StudentCard))
                {
                    AllStudentsWrapPanel.Children.Add(StudentCard);
                    TeamStudentsWrapPanel.Children.Remove(StudentCard);
                    ProjectGroup.Students.Remove(StudentCard.Student);
                }
            }
        }
    }
}
