using EJournalBLL.Logics;
using EJournalBLL.Models;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Group = EJournalBLL.GroupsLogic.Group;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AllGroupsWindow : Window
    {
        private GroupsLogic _groupStorage;
        private StudentsLogic _studentsLogic;

        public GroupCard SelectedGroupCard;

        private ProjectServices _projectServices;
        public AllGroupsWindow()
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            _groupStorage = new GroupsLogic(ConnectionString);
            _studentsLogic = new StudentsLogic(ConnectionString);
            _projectServices = new ProjectServices();
            PrintAllGroupsFromDB();
            PrintAllProjectsFromDB();
        }

        public void PrintAllProjectsFromDB()
        {
            ProjectsWrapPanel.Children.Clear();
            foreach (Project project in _projectServices.GetAllProjects())
            {
                ProjectCard projectCard = new ProjectCard(project);
                projectCard.MouseDown += GroupCard_MouseLeftButtonDown;
                ProjectsWrapPanel.Children.Add(projectCard);
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
            GetStudentsByGroup();
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

        private void GetStudentsByGroup()
        {
            GroupStudentsWrapPanel.Children.Clear();
            _studentsLogic.GetStudentsByGroup(SelectedGroupCard.Group.Id);
            SelectedGroupCard.Group.Students = _studentsLogic.Students;
            foreach(Student student in _studentsLogic.Students)
            {
                StudentCard studentCard = new StudentCard(student);
                GroupStudentsWrapPanel.Children.Add(studentCard);
            }
        }
    }
}
