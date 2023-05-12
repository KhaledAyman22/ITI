using MVVMDay23.Command;
using MVVMDay23.DataService;
using MVVMDay23.Model;
using MVVMDay23.Utilities;
using MVVMDay23.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMDay23.ViewModel
{
    public class Window2ViewModel
    {
        public ObservableCollection<User> UserList { get; set; }

       public ICommand NewCommand { get; set; }
        UserDataService userDataService;
        public Window2ViewModel()
        {
            userDataService = new();
            UserList = new();
            NewCommand = new RelayCommand(Navigate, null);

        }

        private void Navigate(object obj)
        {
            // MessageBox.Show(" ");
            var window = new DetailsWindow();
            Messenger.Default.Send<User>(obj as User);
            window.Show();
        }

        public void Load()
        {
            var Users = userDataService.GetAll();
            UserList.Clear();
            foreach (var User in Users)
                UserList.Add(User);
        }

    }
}
