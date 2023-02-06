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

namespace Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students{ get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Students = new()
            {
                new(1, "John Doe", 25, 89.5),
                new(2, "Jane Doe", 28, 92.1),
                new(3, "Bob Smith", 30, 75.6),
                new(4, "Emily Johnson", 27, 83.2),
                new(5, "William Brown", 29, 65.9),
                new(6, "Amy Davis", 24, 95.3),
                new(7, "Michael Wilson", 26, 68.2),
                new(8, "Sarah Davis", 31, 80.5),
                new(9, "David Anderson", 32, 71.3),
                new(10, "Jessica Thompson", 29, 88.1),
                new(11, "Thomas Harris", 35, 64.8),
                new(12, "Elizabeth Smith", 27, 94.5),
                new(13, "Brian Wilson", 33, 72.4),
                new(14, "Jennifer Johnson", 26, 87.3),
                new(15, "Richard Lee", 28, 63.9),
                new(16, "Daniel Martinez", 32, 75.5),
                new(17, "Karen Smith", 30, 89.1),
                new(18, "Mark Johnson", 33, 76.2),
                new(19, "Amy Wilson", 29, 91.3),
                new(20, "Michael Davis", 34, 70.6)
            };
            std_lst.ItemsSource = Students;
        }

    }
}
