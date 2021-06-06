using EJournalBLL.Models;
using EJournalBLL.Services;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace EJournalUI
{
    public class AttendancesCard : Border
    {
        public DatePicker LessonDateDatePicker { get; set; }
        public TextBox LessonsTopicTexBox { get; set; }
        public Lesson Lesson { get; set; }

        public AttendancesCard(Lesson lesson)
        {
            Lesson = lesson;
            Width = 200;
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(2);
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100, GridUnitType.Pixel) });
            grid.RowDefinitions.Add(new RowDefinition());
            Child = grid;

            LessonDateDatePicker = new DatePicker();
            LessonDateDatePicker.HorizontalAlignment = HorizontalAlignment.Center;
            LessonDateDatePicker.VerticalAlignment = VerticalAlignment.Top;
            LessonDateDatePicker.SelectedDate = Lesson.DateLesson;
            LessonDateDatePicker.Margin = new Thickness(0, 2, 0, 0);

            LessonsTopicTexBox = new TextBox();
            LessonsTopicTexBox.HorizontalAlignment = HorizontalAlignment.Center;
            LessonsTopicTexBox.Width = 180;
            LessonsTopicTexBox.TextWrapping = TextWrapping.Wrap;
            LessonsTopicTexBox.MaxLength = 86;
            LessonsTopicTexBox.Text = Lesson.Topic;
            LessonsTopicTexBox.TextAlignment = TextAlignment.Center;
            LessonsTopicTexBox.Margin = new Thickness(2, 28, 0, 2);
            Grid.SetRow(LessonsTopicTexBox, 0);
            grid.Children.Add(LessonsTopicTexBox);

            Button button = new Button();
            button.Name = "DeleteAttendanse";
            button.Background = Brushes.White;
            button.Content = "X";
            button.Width = 20;
            button.Height = 20;
            button.Margin = new Thickness(2);
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(button, 0);
            grid.Children.Add(button);

            Grid.SetRow(LessonDateDatePicker, 0);
            grid.Children.Add(LessonDateDatePicker);

            DataGrid dataGrid = new DataGrid();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = Lesson.Attendances;

            dataGrid.Columns.Add(new DataGridTextColumn()
            {
                Width = 130,
                Header = "Students Name",
                Binding = new Binding("Student"),
                IsReadOnly = true
            });

            dataGrid.Columns.Add(new DataGridCheckBoxColumn() { Header = "IsPresent", Binding = new Binding("isPresent"), Width = 58 });

            Grid.SetRow(dataGrid, 1);
            grid.Children.Add(dataGrid);

            button.Click += Button_DeleteAttendanse_Click;
        }

        private void Button_DeleteAttendanse_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete item?", "Delete confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LessonsService lessonsLogic = new LessonsService(ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString);
                lessonsLogic.DeleteLesson(Lesson);
                ((StackPanel)(this.Parent)).Children.Remove(this);
            }
        }
    }
}
