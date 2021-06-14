using EJournalBLL.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EJournalUI
{
    public class GroupCard : Border
    {
        private TextBlock _groupNameTextBox;
        private TextBlock _courseNameTextBox;
        private TextBlock _studentCountTextBox;

        public Group Group { get; set; }

        public event EventHandler WasDeleted;

        public GroupCard(Group group)
        {
            Group = group;
            Height = 70;
            Width = 400;
            CornerRadius = new CornerRadius(5);
            BorderThickness = new Thickness(3);
            Background = Brushes.White;
            BorderBrush = Brushes.Black;
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(220, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(180, GridUnitType.Star) });
            Child = grid;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Group name:";
            textBlock.Margin = new Thickness(15, 10, 0, 35);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            _groupNameTextBox = new TextBlock();
            _groupNameTextBox.Name = "GroupNameTextBlock";
            _groupNameTextBox.Text = Group.Name;
            _groupNameTextBox.Margin = new Thickness(100, 10, 5, 35);
            _groupNameTextBox.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_groupNameTextBox, 0);
            grid.Children.Add(_groupNameTextBox);

            textBlock = new TextBlock();
            textBlock.Text = "Course:";
            textBlock.Margin = new Thickness(15, 40, 0, 8);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            _courseNameTextBox = new TextBlock();
            _courseNameTextBox.Text = Group.Course.Name;
            _courseNameTextBox.Margin = new Thickness(100, 40, 5, 8);
            _courseNameTextBox.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_courseNameTextBox, 0);
            grid.Children.Add(_courseNameTextBox);


            textBlock = new TextBlock();
            textBlock.Text = "Students count:";
            textBlock.Margin = new Thickness(5, 23, 90, 23);
            textBlock.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);

            _studentCountTextBox = new TextBlock();
            _studentCountTextBox.Text = Group.StudentsCount.ToString();
            _studentCountTextBox.Margin = new Thickness(95, 23, 5, 23);
            _studentCountTextBox.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(_studentCountTextBox, 1);
            grid.Children.Add(_studentCountTextBox);

            MouseEnter += GroupCard_MouseEnter;
            MouseLeave += GroupCard_MouseLeave;
            Group.GrouChanged += UpdateFields;
        }

        public void DeleteGroupCard()
        {
            WasDeleted?.Invoke(this, new EventArgs());
        }

        private void UpdateFields(object sender, EventArgs e)
        {
            if (sender is Group)
            {
                Group group = (Group)sender;
                _groupNameTextBox.Text = group.Name;
                _courseNameTextBox.Text = group.Course.Name;
                _studentCountTextBox.Text = group.Students.Count.ToString();
            }
        }

        private void GroupCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is GroupCard)
            {
                GroupCard groupCard = (GroupCard)sender;
                groupCard.BorderBrush = Brushes.Blue;
            }
        }

        private void GroupCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is GroupCard)
            {
                GroupCard groupCard = (GroupCard)sender;
                groupCard.BorderBrush = Brushes.Black;
            }
        }
    }
}