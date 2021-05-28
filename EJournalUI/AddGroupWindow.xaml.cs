using EJournalBLL.CoursesLogic;
using System.Configuration;
using System.Windows;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        string ConnectionString;
        public AddGroupWindow()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;

            CoursesStorage coursesStorage = new CoursesStorage(ConnectionString);
            CourseComboBox.ItemsSource = coursesStorage.Courses;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}