using EJournalBLL.GroupsLogic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace EJournalUI
{
    public class GroupCard : Border
    {
        public Group Group { get; set; }

        public GroupCard(Group group)
        {
            Group = group;
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
            textBlock.Text = "Group name:";
            textBlock.Margin = new Thickness(15, 10, 0, 35);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Name = "GroupNameTextBlock";
            textBlock.Text = Group.Name;
            textBlock.Margin = new Thickness(100, 10, 5, 35);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "Course:";
            textBlock.Margin = new Thickness(15, 40, 0, 8);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = Group.Course.Name;
            textBlock.Margin = new Thickness(100, 40, 5, 8);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);


            textBlock = new TextBlock();
            textBlock.Text = "Students count:";
            textBlock.Margin = new Thickness(5, 23, 90, 23);
            textBlock.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "20";
            textBlock.Margin = new Thickness(95, 23, 5, 23);
            textBlock.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);

            MouseEnter += GroupCard_MouseEnter;
            MouseLeave += GroupCard_MouseLeave;
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