using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BLL.UIModels
{
    public class Student_UI : UIModelBase
    {
        int id;
        int age;
        string name = string.Empty;
        string address = string.Empty;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
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
    }
}
