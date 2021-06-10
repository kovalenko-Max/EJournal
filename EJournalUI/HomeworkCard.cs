using EJournalBLL.Models;
using EJournalBLL.Services;
using EJournalDAL.Repository;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace EJournalUI
{
    public class HomeworkCard : Border
    {
        public DatePicker ExercisesDateDatePicker { get; set; }
        public TextBox ExercisesTopicTextBox { get; set; }
        public Exercise Exercise { get; set; }
        //enum Rate: int
        //{
        //    NotPassed = 0,
        //    NotInDeadline = 1,
        //    Passed = 2
        //}

        List<int> rate = new List<int>() { 0, 80, 100 };
        public HomeworkCard(Exercise exercise)
        {
            Exercise = exercise;
            Width = 200;
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(2);
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100, GridUnitType.Pixel) });
            grid.RowDefinitions.Add(new RowDefinition());
            Child = grid;

            ExercisesDateDatePicker = new DatePicker();
            ExercisesDateDatePicker.HorizontalAlignment = HorizontalAlignment.Center;
            ExercisesDateDatePicker.VerticalAlignment = VerticalAlignment.Top;
            ExercisesDateDatePicker.SelectedDate = Exercise.Deadline;
            ExercisesDateDatePicker.Margin = new Thickness(0, 2, 0, 0);

            ExercisesTopicTextBox = new TextBox();
            ExercisesTopicTextBox.HorizontalAlignment = HorizontalAlignment.Center;
            ExercisesTopicTextBox.Width = 180;
            ExercisesTopicTextBox.TextWrapping = TextWrapping.Wrap;
            ExercisesTopicTextBox.MaxLength = 86;
            ExercisesTopicTextBox.Text = Exercise.Description;
            ExercisesTopicTextBox.TextAlignment = TextAlignment.Center;
            ExercisesTopicTextBox.Margin = new Thickness(2, 28, 0, 2);
            Grid.SetRow(ExercisesTopicTextBox, 0);
            grid.Children.Add(ExercisesTopicTextBox);

            Button button = new Button();
            button.Name = "DeleteExercise";
            button.Background = Brushes.White;
            button.Content = "X";
            button.Width = 20;
            button.Height = 20;
            button.Margin = new Thickness(2);
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(button, 0);
            grid.Children.Add(button);

            Grid.SetRow(ExercisesDateDatePicker, 0);
            grid.Children.Add(ExercisesDateDatePicker);

            DataGrid dataGrid = new DataGrid();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = Exercise.GroupStudents;

            dataGrid.Columns.Add(new DataGridTextColumn()
            {
                Width = 130,
                Header = "Students Name",
                Binding = new Binding("Student"),
                IsReadOnly = true
            });

            dataGrid.Columns.Add(new DataGridComboBoxColumn() { Header = "Mark", ItemsSource = rate });

            Grid.SetRow(dataGrid, 1);
            grid.Children.Add(dataGrid);

            //button.Click += Button_DeleteExercise_Click;
        }

        //private void Button_DeleteHomework_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MessageBox.Show("Are you sure want to delete item?", "Delete confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //    {
        //        LessonsService lessonsLogic = new LessonsService(new LessonsAttendancesRepository());
        //        lessonsLogic.DeleteExercise(Exercise);
        //        ((StackPanel)(this.Parent)).Children.Remove(this);
        //    }
        //}
    }
}
