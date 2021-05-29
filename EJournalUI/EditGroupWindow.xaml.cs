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
    public partial class EditGroupWindow : Window
    {
        public Group Group;
        public EditGroupWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            CoursesStorage coursesStorage = new CoursesStorage(connectionString);
            CourseComboBox.ItemsSource = coursesStorage.Courses;
        }

        private void Button_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (Group is null)
            {
                Group = new Group(GroupNameTextBox.Text, (Course)CourseComboBox.SelectedItem);
            }
            else
            {
                Group.Name = GroupNameTextBox.Text;
                Group.Course = (Course)CourseComboBox.SelectedItem;
            }

            this.DialogResult = true;
        }
    }
}