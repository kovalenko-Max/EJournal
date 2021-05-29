using EJournalBLL;
using EJournalBLL.CoursesLogic;
using EJournalBLL.GroupsLogic;
using System.Configuration;
using System.Windows;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public Group Group;
        public AddGroupWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            CoursesStorage coursesStorage = new CoursesStorage(connectionString);
            CourseComboBox.ItemsSource = coursesStorage.Courses;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Group = new Group(GroupNameTextBox.Text, (Course)CourseComboBox.SelectedItem);
            this.DialogResult = true;
        }
    }
}