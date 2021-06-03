using EJournalBLL.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace EJournalUI
{
    public class AttendancesCard : Border
    {
        private TextBlock _lessonDateTextBlock;
        public Lesson Lesson { get; set; }

        public AttendancesCard(Lesson lesson)
        {
            Lesson = lesson;
            Width = 200;
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(2);
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
            grid.RowDefinitions.Add(new RowDefinition());
            Child = grid;

            TextBlock _lessonDateTextBlock = new TextBlock();
            _lessonDateTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            _lessonDateTextBlock.VerticalAlignment = VerticalAlignment.Center;
            _lessonDateTextBlock.Text = Lesson.DateLesson.ToString("dd/MM/yyyy");
            Grid.SetRow(_lessonDateTextBlock, 0);
            grid.Children.Add(_lessonDateTextBlock);

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
        }
    }
}
