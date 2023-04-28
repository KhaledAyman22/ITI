using Microsoft.AspNetCore.SignalR.Client;
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
using System.Windows.Threading;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            //1- Declare hub
            connection = 
                new HubConnectionBuilder()
                .WithUrl("http://localhost:63823/MyChatHub").Build();
            //4- Recive
            connection.On<string, string>("NotifyNewMessage", (name, msg) => {
                //display msg hub in listview
                //      MessageBox.Show($"{name}:{msg}");
                Dispatcher.Invoke(() => { MsgList.Items.Add($"{name}:{msg}"); });
            });
            //2- Start connection
            connection.StartAsync();
          

        }
        //3- Send==>click button

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.InvokeAsync("NewMessage", "WPF", msgTxt.Text, 1);
        }
    }
}
