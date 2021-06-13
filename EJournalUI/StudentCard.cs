using EJournalBLL.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace EJournalUI
{
    public class StudentCard : Border
    {
        public Student Student { get; set; }
        private TextBlock _fullName;
        private TextBlock _email;
        private TextBlock _git;

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
            _fullName.Text = $"{Student.Surname} {Student.Name}";
            _fullName.Margin = new Thickness(5, 22, 0, 24);
            _fullName.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_fullName, 0);
            grid.Children.Add(_fullName);

            _email = new TextBlock();
            _email.Text = Student.Email;
            _email.Margin = new Thickness(5, 10, 5, 35);
            _email.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_email, 1);
            grid.Children.Add(_email);

            _git = new TextBlock();
            _git.Text = Student.Git;
            _git.Margin = new Thickness(5, 35, 5, 10);
            _git.TextAlignment = TextAlignment.Left;
            Grid.SetColumn(_git, 1);
            grid.Children.Add(_git);

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
            ((WrapPanel)(this.Parent)).Children.Remove(this);
        }

        public void UpdateFields()
        {
            _fullName.Text = $"{Student.Surname} {Student.Name}";
            _email.Text = Student.Email;
            _git.Text = Student.Git;
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