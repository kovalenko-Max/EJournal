using EJournalBLL;
using EJournalBLL.Logics;
using EJournalBLL.Models;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using System;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AllGroupsWindow : Window
    {
        private GroupsLogic _groupStorage;
        private StudentsLogic _studentsLogic;
        private ProjectServices _projectServices;

        public GroupCard SelectedGroupCard;
        public StudentCard SelectedStudentCard;
        public ProjectCard SelectedProjectCard;


        private StudentServices _studentServices;
        public AllGroupsWindow()
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _groupStorage = new GroupsLogic(ConnectionString);
            _studentsLogic = new StudentsLogic(ConnectionString);
            _studentServices = new StudentServices(ConnectionString);
            _projectServices = new ProjectServices(); 
            PrintAllGroupsFromDB();
            PrintAllStudentsFromDB();
            PrintAllProjectsFromDB();
        }

        public void PrintAllProjectsFromDB()
        {
            ProjectsWrapPanel.Children.Clear();
            foreach (Project project in _projectServices.GetAllProjects())
            {
                ProjectCard projectCard = new ProjectCard(project);
                projectCard.MouseDown += ProjectCard_MouseLeftButtonDown;
                ProjectsWrapPanel.Children.Add(projectCard);
            }
        }

        public void PrintAllStudentsFromDB()
        {
            AllStudentCardsWrapPanel.Children.Clear();
            foreach (Student student in _studentServices.GetAllStudent())
            {
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseUp += StudentCard_MouseLeftButtonDown;
                AllStudentCardsWrapPanel.Children.Add(studentCard);
            }
        }

        private void Button_CreateProject_Click(object sender, RoutedEventArgs e)
        {
            EditProjectWindow addProjectWindow = new EditProjectWindow();

            if (addProjectWindow.ShowDialog() == true)
            {
                addProjectWindow.Project.Id=_projectServices.AddProject(addProjectWindow.Project);
                ProjectCard projectCard = new ProjectCard(addProjectWindow.Project);
                projectCard.MouseUp += ProjectCard_MouseLeftButtonDown;
                ProjectsWrapPanel.Children.Add(projectCard);
            }
        }

        private void Button_DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProjectCard != null)
            {
                _projectServices.DeleteProject(SelectedProjectCard.Project.Id);
                SelectedProjectCard.Project.IsDelete = true;
                ProjectsWrapPanel.Children.Remove(SelectedProjectCard);
            }
        }

        public void SelectProjectCard(ProjectCard projectCard)
        {
            HighlightSelectedProject(projectCard);
            ProjectNameTextBox.Text = projectCard.Project.Name;
            ProjectDescriptionTextBox.Text = projectCard.Project.Description;
        }

        private void HighlightSelectedProject(ProjectCard projectCard)
        {
            if (SelectedProjectCard != null)
            {
                SelectedProjectCard.Background = Brushes.White;
            }

            SelectedProjectCard = projectCard;
            BrushConverter brushConverter = new BrushConverter();
            SelectedProjectCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
        }

        private void ProjectCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ProjectCard)
            {
                if (e.ClickCount == 1)
                {
                    SelectProjectCard((ProjectCard)sender);
                }
            }
        }

        private void Button_EditProject_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProjectCard != null)
            {
                EditProjectWindow editProjectWindow = new EditProjectWindow();
                editProjectWindow.Project = SelectedProjectCard.Project;
                editProjectWindow.ProjectNameTextBox.Text = editProjectWindow.Project.Name;
                editProjectWindow.DescriptionTextBox.Text = editProjectWindow.Project.Description;

                if (editProjectWindow.ShowDialog() == true)
                {
                    ProjectServices projectServices = new ProjectServices();
                    projectServices.UpdateProject(SelectedProjectCard.Project);
                    SelectedProjectCard.UpdateFields();
                    SelectProjectCard(SelectedProjectCard);
                }
            }
        }

        public void PrintAllGroupsFromDB()
        {
            GroupsWrapPanel.Children.Clear();
            foreach (Group group in _groupStorage.Groups)
            {
                GroupCard groupCard = new GroupCard(group);
                groupCard.MouseDown += GroupCard_MouseLeftButtonDown;
                GroupsWrapPanel.Children.Add(groupCard);
            }
        }

        public void SelectGroupCard(GroupCard groupCard)
        {
            HighlightSelected(groupCard);
            GroupNameTextBox.Text = groupCard.Group.Name;
            GroupCourseTextBox.Text = groupCard.Group.Course.Name;
            StudentsCountTextBox.Text = groupCard.Group.StudentsCount.ToString(); ;
            GetStudentsByGroup();
            GetLessonsAttendancesByGroup();
        }

        private void HighlightSelected(GroupCard groupCard)
        {
            if (SelectedGroupCard != null)
            {
                SelectedGroupCard.Background = Brushes.White;
            }

            SelectedGroupCard = groupCard;
            BrushConverter brushConverter = new BrushConverter();
            SelectedGroupCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
        }

        private void Button_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupWindow addGroupWindow = new EditGroupWindow();

            if (addGroupWindow.ShowDialog() == true)
            {
                _groupStorage.Groups.Add(addGroupWindow.Group);
                GroupCard groupCard = new GroupCard(addGroupWindow.Group);
                GroupsWrapPanel.Children.Add(groupCard);
                _groupStorage.AddGroupToDB(addGroupWindow.Group);
                groupCard.MouseUp += GroupCard_MouseLeftButtonDown;
                SelectGroupCard(groupCard);
            }
        }

        private void Button_EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroupCard != null)
            {
                EditGroupWindow editGroupWindow = new EditGroupWindow();
                editGroupWindow.Group = SelectedGroupCard.Group;
                editGroupWindow.GroupNameTextBox.Text = editGroupWindow.Group.Name;
                int index = editGroupWindow.CourseComboBox.Items.IndexOf(SelectedGroupCard.Group.Course);
                editGroupWindow.CourseComboBox.SelectedItem = editGroupWindow.CourseComboBox.Items[index];

                if (editGroupWindow.ShowDialog() == true)
                {
                    GroupsLogic groupStorage = new GroupsLogic(ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString);
                    groupStorage.UpdateGroupInDB(SelectedGroupCard.Group);
                    SelectedGroupCard.UpdateFields();
                    SelectGroupCard(SelectedGroupCard);
                }
            }
        }

        private void GroupCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is GroupCard)
            {
                if (e.ClickCount == 1)
                {
                    SelectGroupCard((GroupCard)sender);
                }
            }
        }

        private void StudentCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StudentCard)
            {
                if (e.ClickCount == 1)
                {
                    StudentCard studentCard = (StudentCard)sender;
                    SelectedStudentCard = studentCard;
                    StudentWindow studentWindow = new StudentWindow(studentCard);
                    studentWindow.StudentDeleted += StudentWindow_DataChanged;
                    studentWindow.Show();
                }
            }
        }

        private void GetStudentsByGroup()
        {
            GroupStudentsWrapPanel.Children.Clear();
            _studentsLogic.GetStudentsByGroup(SelectedGroupCard.Group.Id);
            SelectedGroupCard.Group.Students = _studentsLogic.Students;
            foreach (Student student in _studentsLogic.Students)
            {
                StudentCard studentCard = new StudentCard(student);
                GroupStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void Button_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            EditStudentWindow addStudentWindow = new EditStudentWindow();

            if(addStudentWindow.ShowDialog() == true)
            {
                _studentServices.AddStudent(addStudentWindow.student);
                StudentCard studentCard = new StudentCard(addStudentWindow.student);
                AllStudentCardsWrapPanel.Children.Add(studentCard);
            }
        }

        private void GetLessonsAttendancesByGroup()
        {
            AttendancesStackPanel.Children.Clear();
            LessonsLogic lessonsLogic = new LessonsLogic(ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString);
            List<Lesson> lessons = lessonsLogic.GetLessonsAttendancesByGroup(SelectedGroupCard.Group);

            foreach (var lesson in lessons)
            {
                AttendancesStackPanel.Children.Add(new AttendancesCard(lesson));
            }
        }

        private void Button_AttendancesSave_Click(object sender, RoutedEventArgs e)
        {
            foreach(var c in AttendancesStackPanel.Children)
            {
                if(c is AttendancesCard)
                {
                    AttendancesCard ac = (AttendancesCard)c;
                    LessonsLogic lessonsLogic = new LessonsLogic(ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString);
                    lessonsLogic.UpdateLessonAttendances(ac.Lesson);
                }
            }
        }

        private void StudentWindow_DataChanged(object sender, EventArgs e)
        {
            AllStudentCardsWrapPanel.Children.Remove(SelectedStudentCard);
        }
    }
}
