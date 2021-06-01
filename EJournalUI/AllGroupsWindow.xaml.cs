using EJournalBLL.GroupsLogic;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AllGroupsWindow : Window
    {
        private GroupStorage _groupStorage;

        public GroupCard SelectedGroupCard;
        public AllGroupsWindow()
        {
            InitializeComponent();
            string ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
            Name = "AllGroupsWindow";
            _groupStorage = new GroupStorage(ConnectionString);
            PrintAllGroupsFromDB();
        }
        
        public void PrintAllGroupsFromDB()
        {
            GroupsWrapPanel.Children.Clear();
            foreach (Group group in _groupStorage.Groups)
            {
                GroupCard groupCard = new GroupCard(group);
                groupCard.MouseDown += GroupCard_MouseLeftButtonDown;
                GroupsWrapPanel.Children.Add(groupCard);
            }
        }

        public void Select(GroupCard groupCard)
        {
            HighlightSelected(groupCard);
            GroupNameTextBox.Text = groupCard.Group.Name;
            GroupCourseTextBox.Text = groupCard.Group.Course.Name;
        }

        private void Button_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupWindow addGroupWindow = new EditGroupWindow();

            if (addGroupWindow.ShowDialog() == true)
            {
                _groupStorage.Groups.Add(addGroupWindow.Group);
                GroupsWrapPanel.Children.Add(new GroupCard(addGroupWindow.Group));
                _groupStorage.AddGroupToDB(addGroupWindow.Group);
            }
            else
            {

            }
        }

        private void GroupCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is GroupCard)
            {
                if (e.ClickCount == 1)
                {
                    Select((GroupCard)sender);
                }
            }
        }
        
        private void HighlightSelected(GroupCard groupCard)
        {
            if (SelectedGroupCard != null)
            {
                SelectedGroupCard.Background = Brushes.White;
            }

            SelectedGroupCard = groupCard;
            BrushConverter brushConverter = new BrushConverter();
            SelectedGroupCard.Background = (Brush)brushConverter.ConvertFrom("#FFCBCBCB");
        }

        private void Button_EditGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupWindow editGroupWindow = new EditGroupWindow();
            editGroupWindow.Group = SelectedGroupCard.Group;
            editGroupWindow.GroupNameTextBox.Text = editGroupWindow.Group.Name;
            int index = editGroupWindow.CourseComboBox.Items.IndexOf(SelectedGroupCard.Group.Course);
            editGroupWindow.CourseComboBox.SelectedItem = editGroupWindow.CourseComboBox.Items[index];

            if (editGroupWindow.ShowDialog() == true)
            {
                GroupStorage groupStorage = new GroupStorage(ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString);
                groupStorage.UpdateGroupInDB(SelectedGroupCard.Group);
                SelectedGroupCard.UpdateFields();
            }
            else
            {

            }
        }
    }
}
