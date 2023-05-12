using MVVMDay23.ViewModel;
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
using System.Windows.Shapes;

namespace MVVMDay23.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Window1ViewModel Window1VM;
        public Window1(Window1ViewModel _windowVM)
        {
            Window1VM = _windowVM;
            DataContext= Window1VM;
            InitializeComponent();
            Loaded += Window1_Load;
        }

        private void Window1_Load(object sender, RoutedEventArgs e)
        {
            Window1VM.Load();
        }
    }
}
