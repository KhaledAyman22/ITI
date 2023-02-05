using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace Task_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio)
            {
                InkCan.DefaultDrawingAttributes.Color = radio.Content.ToString() switch
                {
                    "Red" => Colors.Red,
                    "Green" => Colors.Green,
                    "Blue" => Colors.Blue,
                    _ => Colors.Black,
                };
            }
        }

        private void ChangeMode(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio)
            {
                InkCan.EditingMode = radio.Content.ToString() switch
                {
                    "Ink" => InkCanvasEditingMode.Ink,
                    "Select" => InkCanvasEditingMode.Select,
                    "Erase" => InkCanvasEditingMode.EraseByPoint,
                    "Erase by strock" => InkCanvasEditingMode.EraseByStroke,
                    _ => InkCanvasEditingMode.Ink
                };
            }
        }

        private void ChangeDrawShape(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio)
            {
                InkCan.DefaultDrawingAttributes.StylusTip = radio.Content.ToString() switch
                {
                    "Ellipse" => StylusTip.Ellipse,
                    "Rectangle" => StylusTip.Rectangle,
                    _ => StylusTip.Rectangle
                };
            }
        }

        private void ChangeBrushSize(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio)
            {
                double s = radio.Content.ToString() switch
                {
                    "Small" => 1,
                    "Normal" => 5,
                    "Large" => 10,
                    _ => 5
                };

                InkCan.DefaultDrawingAttributes.Width = s;
                InkCan.DefaultDrawingAttributes.Height = s;
            }
        }

        private void NewClick(object sender, RoutedEventArgs e)
        {
            InkCan.Strokes.Clear();
        }
       
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog diag = new();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using var fs = new FileStream(diag.SelectedPath + "/canvas", FileMode.Create);
                InkCan.Strokes.Save(fs);
            }
        }
       
        private void LoadClick(object sender, RoutedEventArgs e){

            Microsoft.Win32.OpenFileDialog dlg = new();

            if (dlg.ShowDialog() is true)
            {
                using var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                StrokeCollection strokes = new(fs);
                InkCan.Strokes = strokes;
            }
        }
       
        private void CopyClick(object sender, RoutedEventArgs e)
        {
            InkCan.CopySelection();
        }

        private void CutClick(object sender, RoutedEventArgs e){
            InkCan.CutSelection();
        }
        private void PasteClick(object sender, RoutedEventArgs e){
            InkCan.Paste();
        }

        
    }

}
