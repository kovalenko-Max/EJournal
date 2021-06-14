using EJournalBLL.Services;
using EJournalBLL.Models;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using EJournalBLL;
using EJournalDAL.Repository;
using System.Linq;

namespace EJournalUI
{
    public partial class AllGroupsWindow : Window
    {
        private GroupsService _groupService;
        private ProjectService _projectServices;
        private ProjectGroupSevice _projectGroupServices;
        private StudentService _studentServices;
        private GroupCard _selectedGroupCard;
        private ProjectCard _selectedProjectCard;
        private ProjectGroupCard _selectedProjectGroupCard;

        public AllGroupsWindow()
        {
            InitializeComponent();
            _groupService = new GroupsService();
            _studentServices = new StudentService();
            _projectServices = new ProjectService();
            _projectGroupServices = new ProjectGroupSevice();
            SearchComboBox.ItemsSource = Enum.GetValues(typeof(SearchType)).Cast<SearchType>();
            SearchComboBox.SelectedItem = (SearchType)0;
            PrintAllGroupsFromDB();
            PrintAllStudentsFromDB();
            PrintAllProjectsFromDB();
        }

        #region Groups
        private void PrintAllGroupsFromDB()
        {
            GroupsWrapPanel.Children.Clear();
            foreach (Group group in _groupService.Groups)
            {
                GroupCard groupCard = new GroupCard(group);
                groupCard.MouseDown += GroupCard_MouseLeftButtonDown;
                groupCard.WasDeleted += DeleteGroupCard;
                GroupsWrapPanel.Children.Add(groupCard);
            }
        }

        private void SelectGroupCard(GroupCard groupCard)
        {
            HighlightSelectedGroupCard(groupCard);
            UpdateGroupInfoGridFieldts(null, null);
            GetStudentsByGroup();
            GetLessonsAttendancesByGroup();
            GetExercisesByGroup();
        }

        private void HighlightSelectedGroupCard(GroupCard groupCard)
        {
            if (_selectedGroupCard != null)
            {
                _selectedGroupCard.Background = Brushes.White;
                _selectedGroupCard.Group.GrouChanged -= UpdateGroupInfoGridFieldts;
            }

            _selectedGroupCard = groupCard;
            BrushConverter brushConverter = new BrushConverter();
            _selectedGroupCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
            _selectedGroupCard.Group.GrouChanged += UpdateGroupInfoGridFieldts;
        }

        private void UpdateGroupInfoGridFieldts(object sender, EventArgs e)
        {
            GroupNameTextBox.Text = _selectedGroupCard.Group.Name;
            GroupCourseTextBox.Text = _selectedGroupCard.Group.Course.Name;
            StudentsCountTextBox.Text = _selectedGroupCard.Group.Students.Count.ToString();

            GroupStudentsWrapPanel.Children.Clear();

            foreach (Student student in _selectedGroupCard.Group.Students)
            {
                StudentCard studentCard = new StudentCard(student);
                GroupStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void Button_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupWindow editGroupWindow = new EditGroupWindow();
            Hide();
            editGroupWindow.ShowDialog();

            if (editGroupWindow.DialogResult == true)
            {
                GroupsWrapPanel.Children.Add(editGroupWindow.GroupCard);
                editGroupWindow.GroupCard.MouseUp += GroupCard_MouseLeftButtonDown;
                editGroupWindow.GroupCard.WasDeleted += DeleteGroupCard;
                SelectGroupCard(editGroupWindow.GroupCard);
            }

            Show();
        }

        private void Button_EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedGroupCard != null)
            {
                EditGroupWindow editGroupWindow = new EditGroupWindow(_selectedGroupCard);
                Hide();
                editGroupWindow.ShowDialog();
                Show();
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
            _studentServices.GetStudentsByGroup(_selectedGroupCard.Group.Id);
            _selectedGroupCard.Group.Students = _studentServices.Students;

            foreach (Student student in _studentServices.Students)
            {
                StudentCard studentCard = new StudentCard(student);
                GroupStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void DeleteGroupCard(object sender, EventArgs e)
        {
            GroupsWrapPanel.Children.Remove((GroupCard)sender);
        }

        private void GetLessonsAttendancesByGroup()
        {
            AttendancesStackPanel.Children.Clear();
            LessonsService lessonsLogic = new LessonsService(new LessonsAttendancesRepository());
            List<Lesson> lessons = lessonsLogic.GetLessonsAttendancesByGroup(_selectedGroupCard.Group);

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

        #region Attendances

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
            if (_selectedGroupCard != null)
            {
                Lesson lesson = new Lesson();
                lesson.IdGroup = _selectedGroupCard.Group.Id;

                foreach (var student in _selectedGroupCard.Group.Students)
                {
                    lesson.Attendances.Add(new Attendances(student));
                }

                AttendancesCard attendancesCard = new AttendancesCard(lesson);
                AttendancesStackPanel.Children.Insert(0, attendancesCard);
                LessonsService lessonsService = new LessonsService(new LessonsAttendancesRepository());
                lessonsService.AddLesson(lesson);
            }
        }

        #endregion

        #region Exercises

        private void Button_ExercisesAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedGroupCard != null)
            {
                Exercise exercise = new Exercise(_selectedGroupCard.Group);
                exercise.IdGroup = _selectedGroupCard.Group.Id;
                exercise.ExerciseType = (ExcerciseType)0;

                foreach (var student in _selectedGroupCard.Group.Students)
                {
                    exercise.StudentMarks.Add(new StudentMark(student));
                }

                ExercisesCard homeworkcard = new ExercisesCard(exercise);
                homeworkcard.Exercise.ExerciseType = (ExcerciseType)homeworkcard.ExcerciseTypeComboBox.SelectedItem;

                HomeworkStackPanel.Children.Insert(0, homeworkcard);

                ExercisesService exercisesService = new ExercisesService();
                exercisesService.AddExerciseToStudent(exercise);
            }
        }

        private void Button_ExercisesSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var child in HomeworkStackPanel.Children)
            {
                if (child is ExercisesCard)
                {
                    ExercisesCard homeWork = (ExercisesCard)child;

                    ExercisesService exerciseService = new ExercisesService();

                    if (homeWork.ExercisesDateDatePicker.SelectedDate != null)
                    {
                        homeWork.Exercise.Deadline = (DateTime)homeWork.ExercisesDateDatePicker.SelectedDate;
                    }

                    homeWork.Exercise.Description = homeWork.ExercisesTopicTextBox.Text.ToString();

                    homeWork.Exercise.ExerciseType = (ExcerciseType)homeWork.ExcerciseTypeComboBox.SelectedItem;

                    exerciseService.UpdateStudentExercise(homeWork.Exercise);
                }
            }
        }

        private void GetExercisesByGroup()
        {
            HomeworkStackPanel.Children.Clear();
            ExercisesService exercisesService = new ExercisesService();

            List<Exercise> exercises = exercisesService.GetExercisesByGroup(_selectedGroupCard.Group);
            foreach (var exercise in exercises)
            {
                HomeworkStackPanel.Children.Add(new ExercisesCard(exercise));
            }
        }

        #endregion

        #region Projects
        private void PrintStudentsFromProjectGroup(ProjectGroup projectGroup)
        {
            ProjectTeamsStudentsWrapPanel.Children.Clear();
            projectGroup.Students = new List<Student>();
            foreach (Student student in _studentServices.GetStudentsFromProjectGroups(projectGroup.Id))
            {
                projectGroup.Students.Add(student);
                projectGroup.IdProject = _selectedProjectCard.Project.Id;
                StudentCard studentCard = new StudentCard(student);
                studentCard.MouseDown += ProjectGroupCard_MouseLeftButtonDown;
                ProjectTeamsStudentsWrapPanel.Children.Add(studentCard);
            }
        }

        private void PrintAllProjectGroupsFromDB(int IdProject)
        {
            ProjectTeamsWrapPanel.Children.Clear();
            ProjectTeamsStudentsWrapPanel.Children.Clear();

            foreach (ProjectGroup projectGroup in _projectGroupServices.GetProjectGroups(IdProject))
            {
                ProjectGroupCard projectGroupCard = new ProjectGroupCard(projectGroup);
                projectGroupCard.MouseDown += ProjectGroupCard_MouseLeftButtonDown;
                ProjectTeamsWrapPanel.Children.Add(projectGroupCard);
            }
        }

        private void Button_CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProjectCard != null)
            {
                if (TeamNameTextBox.Text != string.Empty)
                {
                    ProjectGroup projectGroup = new ProjectGroup(TeamNameTextBox.Text);
                    projectGroup.IdProject = _selectedProjectCard.Project.Id;
                    projectGroup.Id = _projectGroupServices.AddProjectGroup(projectGroup);
                    ProjectGroupCard projectGroupCard = new ProjectGroupCard(projectGroup);
                    projectGroupCard.MouseUp += ProjectGroupCard_MouseLeftButtonDown;
                    ProjectTeamsWrapPanel.Children.Add(projectGroupCard);
                }

            }
        }

        private void Button_EditProjectGroup_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProjectGroupCard != null)
            {
                ProjectGroup projectGroup = _selectedProjectGroupCard.ProjectGroup;
                EditProjectGroupWindow groupWindow = new EditProjectGroupWindow(projectGroup);
                Hide();
                groupWindow.ShowDialog();
                PrintAllProjectGroupsFromDB(projectGroup.Id);
                SelectProjectCard(_selectedProjectCard);
                Show();
            }
        }

        private void Button_DeleteProjectGroup_Click(object sender, RoutedEventArgs e)
        {

            if (_selectedProjectGroupCard.ProjectGroup == null)
            {
                MessageBox.Show("Please select the team", "Select", MessageBoxButton.OK);
            }
            else
            {
                if (MessageBox.Show("Delete this team?", "Please select", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ProjectTeamsStudentsWrapPanel.Children.Clear();
                    _projectGroupServices.DeleteProjectGroup(_selectedProjectGroupCard.ProjectGroup.Id);
                    ProjectTeamsWrapPanel.Children.Remove(_selectedProjectGroupCard);
                }
            }
        }

        private void SelectProjectGroupCard(ProjectGroupCard projectGroupCard)
        {
            HighlightSelectedProjectGroup(projectGroupCard);
            PrintStudentsFromProjectGroup(projectGroupCard.ProjectGroup);
            Button_DeleteProjectGroup.IsEnabled = true;
            Button_DeleteProjectGroup.IsEnabled = true;
        }

        private void HighlightSelectedProjectGroup(ProjectGroupCard projectGroupCard)
        {
            if (_selectedProjectGroupCard != null)
            {
                _selectedProjectGroupCard.Background = Brushes.White;
            }

            _selectedProjectGroupCard = projectGroupCard;
            BrushConverter brushConverter = new BrushConverter();
            _selectedProjectGroupCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
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

        private void PrintAllProjectsFromDB()
        {
            ProjectsWrapPanel.Children.Clear();
            foreach (Project project in _projectServices.GetAllProjects())
            {
                ProjectCard projectCard = new ProjectCard(project);
                projectCard.MouseDown += ProjectCard_MouseLeftButtonDown;
                ProjectsWrapPanel.Children.Add(projectCard);
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
                if (_selectedProjectCard != null)
                {
                    _projectServices.DeleteProject(_selectedProjectCard.Project.Id);
                    ProjectsWrapPanel.Children.Remove(_selectedProjectCard);
                }
            }
        }

        private void SelectProjectCard(ProjectCard projectCard)
        {
            ProjectNameTextBox.Text = projectCard.Project.Name;
            ProjectDescriptionTextBox.Text = projectCard.Project.Description;
            HighlightSelectedProject(projectCard);
            PrintAllProjectGroupsFromDB(projectCard.Project.Id);
            EditProjectButton.IsEnabled = true;
            DeleteProjectButton.IsEnabled = true;
            _selectedProjectGroupCard = null;
            Button_DeleteProjectGroup.IsEnabled = false;
        }

        private void HighlightSelectedProject(ProjectCard projectCard)
        {
            if (_selectedProjectCard != null)
            {
                _selectedProjectCard.Background = Brushes.White;
            }

            _selectedProjectCard = projectCard;
            BrushConverter brushConverter = new BrushConverter();
            _selectedProjectCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
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
            if (_selectedProjectCard != null)
            {
                EditProjectWindow editProjectWindow = new EditProjectWindow();
                editProjectWindow.Project = _selectedProjectCard.Project;
                editProjectWindow.ProjectNameTextBox.Text = editProjectWindow.Project.Name;
                editProjectWindow.DescriptionTextBox.Text = editProjectWindow.Project.Description;

                if (editProjectWindow.ShowDialog() == true)
                {
                    ProjectService projectServices = new ProjectService();
                    projectServices.UpdateProject(_selectedProjectCard.Project);
                    _selectedProjectCard.UpdateFields();
                    SelectProjectCard(_selectedProjectCard);
                }
            }
        }

        #endregion

        #region Students
        private void Button_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            EditStudentWindow addStudentWindow = new EditStudentWindow();

            if (addStudentWindow.ShowDialog() == true)
            {
                _studentServices.AddStudent(addStudentWindow.Student);
                StudentCard studentCard = new StudentCard(addStudentWindow.Student);
                AllStudentCardsWrapPanel.Children.Add(studentCard);
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

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text;

            switch (SearchComboBox.SelectedItem)
            {
                case SearchType.Name:
                    {
                        AllStudentCardsWrapPanel.Children.Clear();
                        foreach (Student student in _studentServices.SearchStudentsByFullName(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            AllStudentCardsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case SearchType.Email:
                    {
                        AllStudentCardsWrapPanel.Children.Clear();
                        foreach (Student student in _studentServices.SearchStudentsByEmail(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            AllStudentCardsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case SearchType.Phone:
                    {
                        AllStudentCardsWrapPanel.Children.Clear();
                        foreach (Student student in _studentServices.SearchStudentsByPhone(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            AllStudentCardsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case SearchType.City:
                    {
                        AllStudentCardsWrapPanel.Children.Clear();
                        foreach (Student student in _studentServices.SearchStudentsByCity(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            AllStudentCardsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case SearchType.AgreementNumber:
                    {
                        AllStudentCardsWrapPanel.Children.Clear();
                        foreach (Student student in _studentServices.SearchStudentsAgreementNumbers(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            AllStudentCardsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case SearchType.Group:
                    {
                        AllStudentCardsWrapPanel.Children.Clear();
                        foreach (Student student in _studentServices.SearchStudentsGroup(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            AllStudentCardsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
                case SearchType.Course:
                    {
                        AllStudentCardsWrapPanel.Children.Clear();
                        foreach (Student student in _studentServices.SearchStudentsCourses(search))
                        {
                            StudentCard studentCard = new StudentCard(student);
                            AllStudentCardsWrapPanel.Children.Add(studentCard);
                        }
                        break;
                    }
            }
        }
        #endregion
    }
}