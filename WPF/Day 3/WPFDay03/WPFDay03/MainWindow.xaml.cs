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

namespace WPFDay03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> Employees { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Employees = new List<Employee>()
            {
                new Employee(){Name="Ali",Id=10,Salary=2000,Image="/img12.jpg"},
                new Employee(){Name="Omar",Id=20,Salary=3000,Image="/img13.jpg"},
                new Employee(){Name="Anas",Id=30,Salary=4000,Image="/img14.jpg"},
                new Employee(){Name="Mai",Id=40,Salary=5000,Image="/img15.jpg"},
                new Employee(){Name="Mona",Id=50,Salary=6000,Image="/img4.jpg"},



            };
            lst.ItemsSource = Employees;
            
        }
    }
}
