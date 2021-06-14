using EJournalBLL.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace EJournalUI
{
    public class StudentCard : Border
    {
        private TextBlock _fullName;
        private TextBlock _agreementNumberTextBlock;
        private TextBlock _cityTexBlock;
        
        public Student Student { get; set; }

        public StudentCard(Student student)
        {
            Student = student;
            Height = 70;
            Width = 450;
            CornerRadius = new CornerRadius(5);
            BorderThickness = new Thickness(3);
            BorderBrush = Brushes.Black;
            Background = Brushes.White;
            Margin = new Thickness(2);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(120, GridUnitType.Pixel) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Child = grid;
            TextBlock textBlock = new TextBlock();

            _fullName = new TextBlock();
            _fullName.Text = $"{Student.Name} {Student.Surname}";
            _fullName.Margin = new Thickness(5, 22, 0, 24);
            _fullName.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_fullName, 0);
            grid.Children.Add(_fullName);

            _agreementNumberTextBlock = new TextBlock();
            _agreementNumberTextBlock.Text = Student.Email;
            _agreementNumberTextBlock.Margin = new Thickness(5, 10, 5, 35);
            _agreementNumberTextBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_agreementNumberTextBlock, 1);
            grid.Children.Add(_agreementNumberTextBlock);

            _cityTexBlock = new TextBlock();
            _cityTexBlock.Text = Student.City;
            _cityTexBlock.Margin = new Thickness(5, 35, 5, 10);
            _cityTexBlock.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_cityTexBlock, 1);
            grid.Children.Add(_cityTexBlock);

            MouseEnter += StudentCard_MouseEnter;
            MouseLeave += StudentCard_MouseLeave;
            MouseLeftButtonDown += StudentCard_MouseLeftDoubleClick;
        }

        private void StudentCard_MouseLeftDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                StudentCard studentCard = (StudentCard)sender;
                StudentWindow studentWindow = new StudentWindow(studentCard);
                studentWindow.StudentDeleted += StudentWindow_StudentDeleted;
                studentWindow.Show();
            }
        }

        private void StudentWindow_StudentDeleted(object sender, System.EventArgs e)
        {
            ((WrapPanel)(Parent)).Children.Remove(this);
        }

        public void UpdateFields()
        {
            _fullName.Text = $"{Student.Surname} {Student.Name}";
            _agreementNumberTextBlock.Text = Student.Email;
            _cityTexBlock.Text = Student.Git;
        }

        private void StudentCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is StudentCard)
            {
                StudentCard studentCard = (StudentCard)sender;
                studentCard.BorderBrush = Brushes.Blue;
            }
        }

        private void StudentCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is StudentCard)
            {
                StudentCard studentCard = (StudentCard)sender;
                studentCard.BorderBrush = Brushes.Black;
            }
        }
    }
}