using MVVMDay23.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMDay23.ViewModel
{
    public class TestViewModel:ViewModelBase
    {
        public ICommand NewCommand { get; set; }
        int testProp;
        public int TestProp {
            get { return testProp; }
            set {
                testProp = value;
                OnPropertyChanged();
            }
        }


        public TestViewModel()
        {
            NewCommand = new RelayCommand(Test,null);
        }

        private void Test(object obj)
        {
            MessageBox.Show("Hi");
        }
    }
}
