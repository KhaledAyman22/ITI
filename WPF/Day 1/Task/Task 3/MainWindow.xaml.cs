using System.Windows;
using System.Windows.Controls;

namespace Task_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetTextClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Text = "Replace default text with initial text value";
        }

        private void SelectAllClick(object sender, RoutedEventArgs e)
        {
            tarea.SelectAll();
            tarea.Focus();
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Clear();
        }

        private void PrependClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Text = "*** Prepended text *** " + tarea.Text;
        }

        private void InsertClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Text = tarea.Text.Insert(tarea.SelectionStart, "*** inserted text ***"); 
        }
        
        private void AppendClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Text += "*** appended text ***";
        }
        
        private void CutClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Cut();
        }
        
        private void PasteClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Paste();   
        }
        
        private void UndoClick(object sender, RoutedEventArgs e)
        {
            if (tarea.IsReadOnly) return;
            tarea.Undo();   
        }

        private void OrientationChanged(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio)
            {
                tarea.TextAlignment = radio.Content.ToString() switch
                {
                    "Right" => TextAlignment.Right,
                    "Left" => TextAlignment.Left,
                    "Center" => TextAlignment.Center,
                    _ => TextAlignment.Left,
                };
            }
            tarea.Focus();
        }

        private void AcccessChanged(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio)
            {
                tarea.IsReadOnly = radio.Content.ToString() switch
                {
                    "Read Only" => true,
                    "Editable" => false,
                    _ => false,
                };
            }
            tarea.Focus();
        }
    }
}
