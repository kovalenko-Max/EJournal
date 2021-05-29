using EJournalBLL.GroupsLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public Group Group;

        public GroupWindow(Group group)
        {
            InitializeComponent();
            Group = group;
            GroupNameTextBox.Text = Group.Name;
            GroupCourseTextBox.Text = Group.Course.Name;
        }

        private void Button_EditGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupWindow editGroupWindow = new EditGroupWindow();
            editGroupWindow.Group = Group;
            editGroupWindow.GroupNameTextBox.Text = editGroupWindow.Group.Name;
            int index = editGroupWindow.CourseComboBox.Items.IndexOf(Group.Course);
            editGroupWindow.CourseComboBox.SelectedItem = editGroupWindow.CourseComboBox.Items[index];

            if (editGroupWindow.ShowDialog() == true)
            {
                GroupStorage groupStorage = new GroupStorage(ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString);
                groupStorage.UpdateGroupInDB(Group);
                UpdateFields();
            }
            else
            {

            }
        }

        private void UpdateFields()
        {
            GroupNameTextBox.Text = Group.Name;
            GroupCourseTextBox.Text = Group.Course.Name;
            ((AllGroupsWindow)System.Windows.Application.Current.MainWindow).PrintAllGroupsFromDB();
        }
    }
}
