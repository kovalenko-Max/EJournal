using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EJournalBLL.Models;
using System.Windows.Media;

namespace EJournalUI
{
    public class ProjectGroupCard : Border
    {
        public ProjectGroup ProjectGroup { get; set; }

        private TextBlock _projectGroupNameTextBox;

        public ProjectGroupCard(ProjectGroup projectGroup)
        {
            ProjectGroup = projectGroup;
            Height = 70;
            Width = 380;
            CornerRadius = new CornerRadius(5);
            BorderThickness = new Thickness(3);
            Background = Brushes.White;
            BorderBrush = Brushes.Black;
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(350, GridUnitType.Star) });
            Child = grid;

            _projectGroupNameTextBox = new TextBlock();
            _projectGroupNameTextBox.Name = "ProjectGroupNameTextBlock";
            _projectGroupNameTextBox.Text = ProjectGroup.Name;
            _projectGroupNameTextBox.TextWrapping = TextWrapping.Wrap;
            _projectGroupNameTextBox.Width = 370;
            _projectGroupNameTextBox.FontSize = 14;
            _projectGroupNameTextBox.Foreground = Brushes.DarkRed;
            _projectGroupNameTextBox.Margin = new Thickness(5, 10, 5, 35);
            _projectGroupNameTextBox.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(_projectGroupNameTextBox, 0);
            grid.Children.Add(_projectGroupNameTextBox);

            MouseEnter += ProjectGroupCard_MouseEnter;
            MouseLeave += ProjectGroupCard_MouseLeave;
        }

        public void UpdateFields()
        {
            _projectGroupNameTextBox.Text = ProjectGroup.Name;
        }

        private void ProjectGroupCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ProjectGroupCard)
            {
                ProjectGroupCard projectCard = (ProjectGroupCard)sender;
                projectCard.BorderBrush = Brushes.Blue;
            }
        }

        private void ProjectGroupCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is ProjectGroupCard)
            {
                ProjectGroupCard projectCard = (ProjectGroupCard)sender;
                projectCard.BorderBrush = Brushes.Black;
            }
        }
    }
}
