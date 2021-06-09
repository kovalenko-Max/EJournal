using EJournalBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace EJournalUI
{
    public class HomeworksCard : Border
    {
        
            private TextBlock _homeworkDateTextBlock;
            public Exercise Exercise { get; set; }
        public HomeworksCard(Task task)
        {
            Exercise = Exercise;
            Width = 200;
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(2);
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
            grid.RowDefinitions.Add(new RowDefinition());
            Child = grid;

            TextBlock _homeworkDateTextBlock = new TextBlock();
            _homeworkDateTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            _homeworkDateTextBlock.VerticalAlignment = VerticalAlignment.Center;
            _homeworkDateTextBlock.Text = Exercise.DateExercise.ToString("dd/MM/yyyy");
            Grid.SetRow(_homeworkDateTextBlock, 0);
            grid.Children.Add(_homeworkDateTextBlock);

            DataGrid dataGrid = new DataGrid();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = Exercise.Exercise.Homework;

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
