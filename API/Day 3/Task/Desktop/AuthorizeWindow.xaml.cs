using Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : Window
    {
        RequestMaker requestMaker;
        public AuthorizeWindow()
        {
            InitializeComponent();
            requestMaker = new("Account");
        }

        private void registerBtnLog_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Collapsed;
            register.Visibility = Visibility.Visible;
        }
        
        private void loginBtnReg_Click(object sender, RoutedEventArgs e)
        {
            register.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Visible;
        }

        private async void loginBtnLog_Click(object sender, RoutedEventArgs e)
        {
            var body = new LoginDTO()
            {
                Email = emailLog.Text,
                Password = passwordLog.Text
            };

            var res = await requestMaker.MakeRequest(body, typeof(LoginDTO), HttpMethod.Post, "Login", false);

            if (res.IsSuccessStatusCode)
            {
                string contetnt = await res.Content.ReadAsStringAsync();
                var JWT = JsonSerializer.Deserialize(contetnt, typeof(JWTToken));

                CurrentJWT.Token = ((JWTToken)JWT).Token;
                CurrentJWT.Expiration = ((JWTToken)JWT).Expiration;

                this.Hide();
                MainWindow mainWindow = new();
                mainWindow.Show();

            }
        }

        private async void registerBtnReg_Click(object sender, RoutedEventArgs e)
        {
            var body = new RegisterDTO()
            {
                Name = name.Text,
                Email = emailReg.Text,
                Password = passwordReg.Text
            };

            var res = await requestMaker.MakeRequest(body, typeof(RegisterDTO), HttpMethod.Post, "Register", false);

            if (res.IsSuccessStatusCode)
            {
                string contetnt = await res.Content.ReadAsStringAsync();
                var JWT = JsonSerializer.Deserialize(contetnt, typeof(JWTToken));

                CurrentJWT.Token = ((JWTToken)JWT).Token;
                CurrentJWT.Expiration = ((JWTToken)JWT).Expiration;

                register.Visibility = Visibility.Collapsed;
                login.Visibility = Visibility.Visible;
                MessageBox.Show("Registered Successfully, Please login");
            }
        }
    }
}
