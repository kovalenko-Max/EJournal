using EJournalBLL.GroupsLogic;
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
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        Group Group;
        public GroupWindow(Group group)
        {
            InitializeComponent();
            Group = group;
            GroupNameTextBox.Text = Group.Name;
            GroupCourseTextBox.Text = Group.Course.Name;
        }
    }
}
