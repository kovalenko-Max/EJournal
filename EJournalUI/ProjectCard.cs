using EJournalBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EJournalUI
{
    public class ProjectCard : Border
    {
        public Project Project { get; set; }

        private TextBlock _projectNameTextBox;
        private TextBlock _projectDescriptionTextBox;

        public ProjectCard(Project project)
        {
            Project = project;
            Height = 70;
            Width = 400;
            CornerRadius = new CornerRadius(5);
            BorderThickness = new Thickness(3);
            Background = Brushes.White;
            BorderBrush = Brushes.Black;
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(320, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Star) });
            Child = grid;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Project name:";
            textBlock.Margin = new Thickness(15, 10, 0, 35);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            _projectNameTextBox = new TextBlock();
            _projectNameTextBox.Name = "ProjectNameTextBlock";
            _projectNameTextBox.Text = Project.Name;
            _projectNameTextBox.Margin = new Thickness(100, 10, 5, 35);
            _projectNameTextBox.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_projectNameTextBox, 0);
            grid.Children.Add(_projectNameTextBox);

            textBlock = new TextBlock();
            textBlock.Text = "Description:";
            textBlock.MaxWidth = 300;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Margin = new Thickness(15, 40, 0, 8);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            _projectDescriptionTextBox = new TextBlock();
            _projectDescriptionTextBox.Text = Project.Description;
            _projectDescriptionTextBox.Margin = new Thickness(100, 40, 5, 8);
            _projectDescriptionTextBox.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_projectDescriptionTextBox, 0);
            grid.Children.Add(_projectDescriptionTextBox);

            MouseEnter += ProjectCard_MouseEnter;
            MouseLeave += ProjectCard_MouseLeave;
        }

        public void UpdateFields()
        {
            _projectNameTextBox.Text = Project.Name;
            _projectDescriptionTextBox.Text = Project.Description;
        }

        private void ProjectCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ProjectCard)
            {
                ProjectCard projectCard = (ProjectCard)sender;
                projectCard.BorderBrush = Brushes.Blue;
            }
        }

        private void ProjectCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is ProjectCard)
            {
                ProjectCard projectCard = (ProjectCard)sender;
                projectCard.BorderBrush = Brushes.Black;
            }
        }
    }
}
