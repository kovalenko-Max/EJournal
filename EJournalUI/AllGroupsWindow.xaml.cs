using EJournalBLL.Services;
using EJournalBLL.Models;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using EJournalBLL;
using EJournalDAL.Repository;

namespace EJournalUI
{
    public partial class AllGroupsWindow : Window
    {
        private GroupsService _groupService;
        private ProjectService _projectServices;
        private ProjectGroupSevice _projectGroupServices;
        private StudentService _studentServices;

        public ProjectGroup ProjectGroup { get; set; }
        public GroupCard SelectedGroupCard { get; set; }
        public StudentCard SelectedStudentCard;
        public ProjectCard SelectedProjectCard;
        public ProjectGroupCard SelectedProjectGroupCard;

        public AllGroupsWindow()
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _groupService = new GroupsService(ConnectionString);
            _studentServices = new StudentService(ConnectionString);
            _projectServices = new ProjectService();
            _projectGroupServices = new ProjectGroupSevice();
            PrintAllGroupsFromDB();
            PrintAllStudentsFromDB();
            PrintAllProjectsFromDB();
        }

        #region Groups
        public void PrintAllGroupsFromDB()
        {
            GroupsWrapPanel.Children.Clear();
            foreach (Group group in _groupService.Groups)
            {
                GroupCard groupCard = new GroupCard(group);
                groupCard.MouseDown += GroupCard_MouseLeftButtonDown;
                GroupsWrapPanel.Children.Add(groupCard);
            }
        }

        public void SelectGroupCard(GroupCard groupCard)
        {
            HighlightSelectedGroupCard(groupCard);
            GroupNameTextBox.Text = groupCard.Group.Name;
            GroupCourseTextBox.Text = groupCard.Group.Course.Name;
            StudentsCountTextBox.Text = groupCard.Group.StudentsCount.ToString();
            GetStudentsByGroup();
            GetLessonsAttendancesByGroup();
        }

        private void HighlightSelectedGroupCard(GroupCard groupCard)
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
            DialogWindow addGroupWindow = new DialogWindow(DialogWindowType.AddGroup);

            if (addGroupWindow.ShowDialog() == true)
            {
                _groupService.Groups.Add(addGroupWindow.Group);
                GroupCard groupCard = new GroupCard(addGroupWindow.Group);
                GroupsWrapPanel.Children.Add(groupCard);
                _groupService.AddGroupToDB(addGroupWindow.Group);
                groupCard.MouseUp += GroupCard_MouseLeftButtonDown;
                SelectGroupCard(groupCard);
            }
        }

        private void Button_EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroupCard != null)
            {
                DialogWindow editGroupWindow = new DialogWindow(DialogWindowType.EditGroup);
                editGroupWindow.Group = SelectedGroupCard.Group;
                editGroupWindow.NameTextBox.Text = editGroupWindow.Group.Name;
                int index = editGroupWindow.CourseComboBox.Items.IndexOf(SelectedGroupCard.Group.Course);
                editGroupWindow.CourseComboBox.SelectedItem = editGroupWindow.CourseComboBox.Items[index];

                if (editGroupWindow.ShowDialog() == true)
                {
                    GroupsService groupStorage = new GroupsService(ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString);
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

        private void GetStudentsByGroup()
        {
            GroupStudentsWrapPanel.Children.Clear();
            _studentServices.GetStudentsByGroup(SelectedGroupCard.Group.Id);
            SelectedGroupCard.Group.Students = _studentServices.Students;
            foreach (Student student in _studentServices.Students)
            {
                StudentCard studentCard = new StudentCard(student);
                GroupStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void GetLessonsAttendancesByGroup()
        {
            AttendancesStackPanel.Children.Clear();
            LessonsService lessonsLogic = new LessonsService(new LessonsAttendancesRepository());
            List<Lesson> lessons = lessonsLogic.GetLessonsAttendancesByGroup(SelectedGroupCard.Group);

            foreach (var lesson in lessons)
            {
                AttendancesStackPanel.Children.Add(new AttendancesCard(lesson));
            }
        }
        #endregion

        #region Courses
        private void Button_CreateCourse_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow createCourse = new DialogWindow(DialogWindowType.AddCourse);
            createCourse.ShowDialog();
        }

        private void Button_EditCourses_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow editCourseWindow = new DialogWindow(DialogWindowType.EditCourse);

            if (editCourseWindow.ShowDialog() == true)
            {
                PrintAllGroupsFromDB();
            }
        }
        #endregion

        public void PrintStudentsFromProjectGroup(int IdProjectGroup)
        public void PrintStudentsFromProjectGroup(ProjectGroup projectGroup)
        {
            ProjectTeamsStudentsWrapPanel.Children.Clear();
            projectGroup.Students = new List<Student>();
            foreach (Student student in _studentServices.GetStudentsFromProjectGroups(projectGroup.Id))
            {
                projectGroup.Students.Add(student);
                projectGroup.IdProject = SelectedProjectCard.Project.Id;
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += ProjectGroupCard_MouseLeftButtonDown;
                ProjectTeamsStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        public void PrintAllProjectGroupsFromDB(int IdProject)
        {
            ProjectTeamsWrapPanel.Children.Clear();

            foreach (ProjectGroup projectGroup in _projectGroupServices.GetProjectGroups(IdProject))
            {
                ProjectGroupCard projectGroupCard = new ProjectGroupCard(projectGroup);
                projectGroupCard.MouseDown += ProjectGroupCard_MouseLeftButtonDown;
                ProjectTeamsWrapPanel.Children.Add(projectGroupCard);
            }
        }

        private void Button_CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            if (TeamNameTextBox.Text != string.Empty)
            {
                ProjectGroup projectGroup = new ProjectGroup(TeamNameTextBox.Text);
                projectGroup.IdProject = SelectedProjectCard.Project.Id;
                projectGroup.Id = _projectGroupServices.AddProjectGroup(projectGroup);
                ProjectGroupCard projectGroupCard = new ProjectGroupCard(projectGroup);
                projectGroupCard.MouseUp += ProjectGroupCard_MouseLeftButtonDown;
                ProjectTeamsWrapPanel.Children.Add(projectGroupCard);
            }
        }
        private void Button_EditProjectGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProjectGroupCard != null)
            {
                ProjectGroup projectGroup = SelectedProjectGroupCard.ProjectGroup;
                EditProjectGroupWindow groupWindow = new EditProjectGroupWindow(projectGroup);
                Hide();
                groupWindow.ShowDialog();
                PrintAllProjectGroupsFromDB(projectGroup.Id);
                SelectProjectCard(SelectedProjectCard);
                Show();
            }
        }

        public void Button_DeleteProjectGroup_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Delete this team?", "Please select", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                if (SelectedProjectGroupCard != null)
                {
                    _projectGroupServices.Delete(SelectedProjectGroupCard.ProjectGroup.Id);
                    SelectedProjectGroupCard.ProjectGroup.IsDelete = true;
                    ProjectTeamsWrapPanel.Children.Remove(SelectedProjectGroupCard);
                }
            }
        }

        public void SelectProjectGroupCard(ProjectGroupCard projectGroupCard)
        {
            HighlightSelectedProjectGroup(projectGroupCard);
            PrintStudentsFromProjectGroup(projectGroupCard.ProjectGroup);
            Button_DeleteProjectGroup.IsEnabled = true;
            Button_DeleteProjectGroup.IsEnabled = true;
        }

        private void HighlightSelectedProjectGroup(ProjectGroupCard projectGroupCard)
        {
            if (SelectedProjectGroupCard != null)
            {
                SelectedProjectGroupCard.Background = Brushes.White;
            }

            SelectedProjectGroupCard = projectGroupCard;
            BrushConverter brushConverter = new BrushConverter();
            SelectedProjectGroupCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
        }

        private void ProjectGroupCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ProjectGroupCard)
            {
                if (e.ClickCount == 1)
                {
                    SelectProjectGroupCard((ProjectGroupCard)sender);
                }
            }
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
                AllStudentCardsWrapPanel.Children.Add(studentCard);
            }
        }

        private void Button_CreateProject_Click(object sender, RoutedEventArgs e)
        {
            EditProjectWindow addProjectWindow = new EditProjectWindow();

            if (addProjectWindow.ShowDialog() == true)
            {
                addProjectWindow.Project.Id = _projectServices.AddProject(addProjectWindow.Project);
                ProjectCard projectCard = new ProjectCard(addProjectWindow.Project);
                projectCard.MouseUp += ProjectCard_MouseLeftButtonDown;
                ProjectsWrapPanel.Children.Add(projectCard);
            }
        }

        private void Button_DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Delete this project?", "Please select", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedProjectCard != null)
                {
                    _projectServices.DeleteProject(SelectedProjectCard.Project.Id);
                    SelectedProjectCard.Project.IsDelete = true;
                    ProjectsWrapPanel.Children.Remove(SelectedProjectCard);
                }
            }
        }

        public void SelectProjectCard(ProjectCard projectCard)
        {
            ProjectNameTextBox.Text = projectCard.Project.Name;
            ProjectDescriptionTextBox.Text = projectCard.Project.Description;
            HighlightSelectedProject(projectCard);
            PrintAllProjectGroupsFromDB(projectCard.Project.Id);
            EditProjectButton.IsEnabled = true;
            DeleteProjectButton.IsEnabled = true;
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
                    ProjectService projectServices = new ProjectService();
                    projectServices.UpdateProject(SelectedProjectCard.Project);
                    SelectedProjectCard.UpdateFields();
                    SelectProjectCard(SelectedProjectCard);
                }
            }
        }

        private void Button_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            EditStudentWindow addStudentWindow = new EditStudentWindow();

            if (addStudentWindow.ShowDialog() == true)
            {
                _studentServices.AddStudent(addStudentWindow.student);
                StudentCard studentCard = new StudentCard(addStudentWindow.student);
                AllStudentCardsWrapPanel.Children.Add(studentCard);
            }
        }

        private void Button_AttendancesSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var c in AttendancesStackPanel.Children)
            {
                if (c is AttendancesCard)
                {
                    AttendancesCard ac = (AttendancesCard)c;
                    LessonsService lessonsLogic = new LessonsService(new LessonsAttendancesRepository());
                    ac.Lesson.DateLesson = (DateTime)ac.LessonDateDatePicker.SelectedDate;
                    ac.Lesson.Topic = ac.LessonsTopicTexBox.Text.ToString();
                    lessonsLogic.UpdateLessonAttendances(ac.Lesson);
                }
            }
        }

        private void Button_AttendancesAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroupCard != null)
            {
                Lesson lesson = new Lesson();
                lesson.IdGroup = SelectedGroupCard.Group.Id;

                foreach (var student in SelectedGroupCard.Group.Students)
                {
                    lesson.Attendances.Add(new Attendances(student));
                }

                AttendancesCard attendancesCard = new AttendancesCard(lesson);
                AttendancesStackPanel.Children.Insert(0, attendancesCard);
                LessonsService lessonsService = new LessonsService(new LessonsAttendancesRepository());
                lessonsService.AddLesson(lesson);
            }
        }
    }
}