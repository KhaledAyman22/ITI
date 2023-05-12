using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace MVVM_Day1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        int clickTime;
        public int ClickTime {


            get { return clickTime; }


            set {  
                if(clickTime !=value)
                {
                    clickTime = value;
                    OnPropertyChanged("ClickTime");

                }


                    }
        }

       // public List<Employee> EmployeeList { get; set; }
        public ObservableCollection<Employee> EmployeeList { get; set; }



        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            EmployeeList = new ObservableCollection<Employee>()
            {
                new(){Name="Omar", Id=10,Salary=200,Gender="Male"},
                new(){Name="Mona", Id=20,Salary=100,Gender="Female"},
                new(){Name="Ali", Id=30,Salary=300,Gender="Male"},
                new(){Name="Hamada", Id=40,Salary=400,Gender="Male"},
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged( string prop)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(prop) );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClickTime++;
        }

        private void AddToList(object sender, RoutedEventArgs e)
        {
            EmployeeList.Add(new() { Name = "Anas", Id = 50, Salary = 700, Gender = "Male" });
        }
    }
}
