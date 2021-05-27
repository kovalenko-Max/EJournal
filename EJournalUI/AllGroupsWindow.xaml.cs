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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AllGroupsWindow : Window
    {
        List<Group> Groups;
        public AllGroupsWindow()
        {
            InitializeComponent();
            Name = "AllGroupsWindow";
            Groups = new List<Group>();
        }

        private void Button_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            AddGroupWindow addGroupWindow = new AddGroupWindow();

            if (addGroupWindow.ShowDialog() == true)
            {
                Groups.Add(addGroupWindow.Group);
                GroupsWrapPanel.Children.Add(new GroupCard(addGroupWindow.Group));
            }
            else
            {

            }

        }

        
    }
}
