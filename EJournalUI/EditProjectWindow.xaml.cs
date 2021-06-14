using EJournalBLL.Models;
using System.Windows;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for EditProjectWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : Window
    {
        public Project Project { get; set; }
        public EditProjectWindow()
        {
            InitializeComponent();
        }

        private void Button_AcceptProject_Click(object sender, RoutedEventArgs e)
        {
            if (Project is null)
            {
                if (ProjectNameTextBox.Text != string.Empty)
                {
                    Project = new Project(ProjectNameTextBox.Text, DescriptionTextBox.Text);
                }
            }
            else
            {
                if (ProjectNameTextBox.Text != string.Empty)
                {
                    Project.Name = ProjectNameTextBox.Text;
                    Project.Description = DescriptionTextBox.Text;
                }
            }

            DialogResult = true;
        }
    }
}
