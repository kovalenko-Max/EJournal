using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Width = 400;
            BorderThickness = new Thickness(3);
            Background = Brushes.White;
            BorderBrush = Brushes.Black;
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(220, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(180, GridUnitType.Star) });
            Child = grid;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Project group name:";
            textBlock.Margin = new Thickness(15, 10, 0, 35);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            _projectGroupNameTextBox = new TextBlock();
            _projectGroupNameTextBox.Name = "ProjectGroupNameTextBlock";
            _projectGroupNameTextBox.Text = ProjectGroup.Name;
            _projectGroupNameTextBox.Margin = new Thickness(100, 10, 5, 35);
            _projectGroupNameTextBox.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_projectGroupNameTextBox, 0);
            grid.Children.Add(_projectGroupNameTextBox);

            MouseEnter += ProjectGroupCard_MouseEnter;
            MouseLeave += ProjectGroupCard_MouseLeave;
        }

        public void UpdateFields()
        {
            _projectGroupNameTextBox.Text = ProjectGroup.Name;
            //_projectDescriptionTextBox.Text = Project.Description;
        }

        private void ProjectGroupCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ProjectCard)
            {
                ProjectCard projectCard = (ProjectCard)sender;
                projectCard.BorderBrush = Brushes.Blue;
            }
        }

        private void ProjectGroupCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is ProjectCard)
            {
                ProjectGroupCard projectCard = (ProjectGroupCard)sender;
                projectCard.BorderBrush = Brushes.Black;
            }
        }
    }
}
