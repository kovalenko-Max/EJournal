using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace EJournalUI
{
    class DataGridNumericColumn : DataGridTextColumn
    {
        protected override object PrepareCellForEdit(System.Windows.FrameworkElement editingElement,
            System.Windows.RoutedEventArgs editingEventArgs)
        {
            TextBox edit = editingElement as TextBox;
            edit.PreviewTextInput += OnPreviewTextInput;

            return base.PrepareCellForEdit(editingElement, editingEventArgs);
        }

        private void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9][0-9]?$|^100$");
            string futureText = ((TextBox)sender).Text + e.Text;

            if (regex.IsMatch(futureText))
            {
                e.Handled = !regex.IsMatch(e.Text);
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
