using EJournalBLL.GroupsLogic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace EJournalUI
{
    public class GroupCard : Border
    {
        public GroupCard(Group group)
        {
            Height = 70;
            Width = 563;
            BorderThickness = new Thickness(3);
            Background = Brushes.White;
            BorderBrush = Brushes.Black;
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(220, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(150, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(190, GridUnitType.Star) });
            Child = grid;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Group name:";
            textBlock.Margin = new Thickness(15, 10, 125, 35);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = group.Name;
            textBlock.Margin = new Thickness(100, 10, 5, 35);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "Course:";
            textBlock.Margin = new Thickness(15, 40, 125, 8);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = group.Course.Name;
            textBlock.Margin = new Thickness(100, 40, 5, 8);
            textBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);


            textBlock = new TextBlock();
            textBlock.Text = "Students count:";
            textBlock.Margin = new Thickness(0, 23, 59, 23);
            textBlock.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "20";
            textBlock.Margin = new Thickness(89, 23, 1, 23);
            textBlock.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);

            Button button = new Button();
            button.Width = 40;
            button.Margin = new Thickness(140, 20, 4, 20);

            button.Content = "Edit";
            Grid.SetColumn(button, 2);

            grid.Children.Add(button);

            MouseEnter += GroupCard_MouseEnter;
            MouseLeave += GroupCard_MouseLeave;
            MouseLeftButtonDown += GroupCard_MouseLeftButtonDown;
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

        private void GroupCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                MessageBox.Show("Double Click");
            }
        }
    }
}