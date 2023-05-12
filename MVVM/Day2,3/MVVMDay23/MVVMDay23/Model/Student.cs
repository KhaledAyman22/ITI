using MVVMDay23.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.Model
{
    public class Student:ViewModelBase
    {
        //public int Id { get; set; }
        //public int Age { get; set; }
        //public String Name { get; set; }
        //public String Address { get; set; }
        int id;
        string name;
        string address;
        int age;
        public int Id

        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
        }


    }
}
