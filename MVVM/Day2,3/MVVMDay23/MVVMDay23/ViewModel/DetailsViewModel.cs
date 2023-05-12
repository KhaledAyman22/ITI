using MVVMDay23.Model;
using MVVMDay23.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.ViewModel
{
    internal class DetailsViewModel:ViewModelBase
    {
        User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged(); }
        }

        public DetailsViewModel()
        {
            SelectedUser=new User();
            Messenger.Default.Register<User>(this, Test);

        }

        private void Test(User obj)
        {
            SelectedUser=obj;
        }
    }
}
