using EJournalBLL;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public Group Group;
        public List<Course> Courses;

        public AddGroupWindow()
        {
            InitializeComponent();
            Courses = new List<Course>();
            Courses.Add(new Course("C#"));
            Courses.Add(new Course("JAVA"));
            Courses.Add(new Course("QA"));
            Courses.Add(new Course("PM"));

            CourseComboBox.ItemsSource = Courses;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Group = new Group(GroupNameTextBox.Text, (Course)CourseComboBox.SelectedItem);
            this.DialogResult = true;
        }
    }
}
