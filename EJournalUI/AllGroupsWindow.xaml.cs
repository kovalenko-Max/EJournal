using EJournalBLL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AllGroupsWindow : Window
    {
        GroupStorage GroupStorage;

        public AllGroupsWindow()
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            Name = "AllGroupsWindow";
            GroupStorage = new GroupStorage(ConnectionString);
            PrintAllGroupsFromDB();
        }

        private void Button_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupWindow addGroupWindow = new EditGroupWindow();

            if (addGroupWindow.ShowDialog() == true)
            {
                GroupStorage.Groups.Add(addGroupWindow.Group);
                GroupsWrapPanel.Children.Add(new GroupCard(addGroupWindow.Group));
                GroupStorage.AddGroupToDB(addGroupWindow.Group);
            }
            else
            {

            }
        }

        public void PrintAllGroupsFromDB()
        {
            GroupsWrapPanel.Children.Clear();
            foreach (Group group in GroupStorage.Groups)
            {
                GroupCard groupCard = new GroupCard(group);
                GroupsWrapPanel.Children.Add(groupCard);
            }
        }

        private void Button_CreateProject_Click(object sender, RoutedEventArgs e)
        {
            EditProjectWindow addProjectWindow = new EditProjectWindow();

            if (addProjectWindow.ShowDialog() == true)
            {

            }
        }
    }
}
