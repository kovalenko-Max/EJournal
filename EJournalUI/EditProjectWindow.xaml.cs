using EJournalBLL.Models;
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

            this.DialogResult = true;
        }
    }
}
