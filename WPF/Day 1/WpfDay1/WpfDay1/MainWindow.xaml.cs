using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDay1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          //  btn1.Background = new SolidColorBrush(Colors.Red);
        }

        private void BtnClicked(object sender, RoutedEventArgs e)
        {
        //    MessageBox.Show();

        }

        private void hamada(object sender, DragEventArgs e)
        {

        }
    }
}
