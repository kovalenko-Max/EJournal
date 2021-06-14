using EJournalBLL.Services;
using EJournalBLL.Models;
using System.Windows;
using EJournalDAL.Repository;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        private CoursesService _coursesService;

        public Group Group { get; set; }
        public DialogWindow(DialogWindowType dialogWindowType)
        {
            InitializeComponent();

            _coursesService = new CoursesService(new CoursesRepository());
            CourseComboBox.ItemsSource = _coursesService.Courses;
            ConfigWindow(dialogWindowType);
        }

        private void Butto_CreateGroup_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty
                && CourseComboBox.SelectedItem != null)
            {
                Group = new Group(NameTextBox.Text, (Course)CourseComboBox.SelectedItem);
                DialogResult = true;
            }
        }

        private void Butto_EditGroup_Accept_Click(object sender, RoutedEventArgs e)
        {
            Group.Name = NameTextBox.Text;
            Group.Course = (Course)CourseComboBox.SelectedItem;

            DialogResult = true;
        }

        private void Button_EditCourse_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty
                && CourseComboBox.SelectedItem != null)
            {
                Course course = (Course)CourseComboBox.SelectedItem;
                course.Name = NameTextBox.Text;
                _coursesService.UpdateCourse(course);
                DialogResult = true;
            }
        }

        private void Button_CreateCourse_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty)
            {
                _coursesService.AddCourse(new EJournalBLL.Models.Course(NameTextBox.Text));
                DialogResult = true;
            }
        }

        private void Button_DeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (CourseComboBox.SelectedItem != null)
            {
                Course course = (Course)CourseComboBox.SelectedItem;
                if (!_coursesService.IsGroupsContainsThisCourse(course))
                {
                    _coursesService.DeleteCourse(course);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Some groups are included in this course. Delete groups firstly or change course in this groups");
                }
            }
        }

        private void ConfigWindow(DialogWindowType dialogWindowType)
        {
            switch (dialogWindowType)
            {
                case DialogWindowType.AddGroup:
                    Title = "Create new Group";
                    TitleTextBlock.Text = "New group name";
                    AcceptButton.Click += Butto_CreateGroup_Accept_Click;
                    break;

                case DialogWindowType.EditGroup:
                    Title = "Edit group";
                    TitleTextBlock.Text = "New group name";
                    AcceptButton.Click += Butto_EditGroup_Accept_Click;
                    break;

                case DialogWindowType.AddCourse:
                    Title = "Create Course";
                    TitleTextBlock.Text = "New course name";
                    ComboBoxNameTextBlock.Visibility = Visibility.Hidden;
                    CourseComboBox.IsEditable = false;
                    CourseComboBox.Visibility = Visibility.Hidden;
                    AcceptButton.Click += Button_CreateCourse_Accept_Click;
                    break;

                case DialogWindowType.EditCourse:
                    Title = "Edit Course";
                    TitleTextBlock.Text = "New course name";
                    DeleteButton.Visibility = Visibility.Visible;
                    DeleteButton.IsEnabled = true;
                    AcceptButton.Click += Button_EditCourse_Accept_Click;
                    DeleteButton.Click += Button_DeleteCourse_Click;
                    break;
            }
        }
    }
}