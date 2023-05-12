using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfWithMvvM.Command;
using WpfWithMvvM.Model;

namespace WpfWithMvvM.ViewModel
{
    public class FirstViewModel
    {
        public ObservableCollection<Employee> EmployeeList { get; set; }
        public ICommand AddCommand { get; set; }
        public Employee NewEmployee { get; set; }
        public FirstViewModel()
        {
            AddCommand = new FirstCommand(Add, CanAdd);

            NewEmployee = new();
            EmployeeList = new ObservableCollection<Employee>()
              {
                new() { Name = "Omar", Id = 10, Salary = 200, Gender = "Male" },
                new() { Name = "Mona", Id = 20, Salary = 100, Gender = "Female" },
                new() { Name = "Ali", Id = 30, Salary = 300, Gender = "Male" },
                new() { Name = "Hamada", Id = 40, Salary = 400, Gender = "Male" },

            };
        }

        private bool CanAdd(object obj)
        {
            return true;
        }

        private void Add(object obj)
        {
            Employee NEmp = obj as Employee;
            var o = new Employee();
            o.Name = NEmp.Name;
            EmployeeList.Add(o);
            MessageBox.Show("Added");

        }
    }
}
