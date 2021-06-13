using EJournalBLL;
using EJournalBLL.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EJournalBLL.Services;

namespace EJournalUI
{
    public class CommentCard : Border
    {
        public Comment Comment { get; set; }

        ComboBox CommentTypeComboBox { get; set; }

        TextBox CommentTextBox { get; set; }

        public CommentCard(Comment comment)
        {
            Comment = comment;

            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(2);
            CornerRadius = new CornerRadius(5);
            Padding = new Thickness(2);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(85, GridUnitType.Pixel) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            Child = grid;

            StackPanel stackPanel = new StackPanel();
            Grid.SetColumn(stackPanel, 0);
            grid.Children.Add(stackPanel);

            CommentTypeComboBox = new ComboBox();
            CommentTypeComboBox.Height = 20;
            CommentTypeComboBox.Width = 80;
            CommentTypeComboBox.Margin = new Thickness(2, 2, 1, 1);
            CommentTypeComboBox.ItemsSource = Enum.GetValues(typeof(CommentType)).Cast<CommentType>();
            CommentTypeComboBox.SelectedItem = Comment.CommentTypeValue;
            stackPanel.Children.Add(CommentTypeComboBox);

            Button saveButton = new Button();
            saveButton.Content = "Save";
            saveButton.Height = 20;
            saveButton.Width = 80;
            saveButton.Margin = new Thickness(2, 1, 1, 1);
            saveButton.Click += Button_Save_Click;
            stackPanel.Children.Add(saveButton);


            Button DeleteButton = new Button();
            DeleteButton.Content = "Delete";
            DeleteButton.Height = 20;
            DeleteButton.Width = 80;
            DeleteButton.Margin = new Thickness(2, 1, 1, 2);
            DeleteButton.Click += Button_Delete_Click;
            stackPanel.Children.Add(DeleteButton);

            CommentTextBox = new TextBox();
            CommentTextBox.TextWrapping = TextWrapping.Wrap;
            CommentTextBox.BorderBrush = Brushes.Black;
            CommentTextBox.Margin = new Thickness(1, 2, 2, 2);
            CommentTextBox.Text = Comment.Comments;
            Grid.SetColumn(CommentTextBox, 1);
            grid.Children.Add(CommentTextBox);
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete item?", "Delete confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new CommentsService().DeleteComment(Comment);
                ((StackPanel)Parent).Children.Remove(this);
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            Comment.Comments = CommentTextBox.Text;
            Comment.CommentTypeValue = (CommentType)CommentTypeComboBox.SelectedItem;
            new CommentsService().UpdateComment(Comment);
        }
    }
}
