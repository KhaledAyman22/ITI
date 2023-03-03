using System.Windows;
using UI.MVVM.ViewModel;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void LoginClicked(object sender, RoutedEventArgs e)
        {
            (bool Bres, string mode) = ((LoginViewModel)DataContext).ValidateLogin(passwordBox.Password);

            if (Bres)
            {
                if (mode == "Kitchen")
                {
                    KitchenWindow k = new();
                    k.Show();
                    Close();
                }
                else
                {
                    FrontendWindow fe = new();
                    fe.Show();
                    Close();
                }
            }
            else
                MessageBox.Show("Wrong username or password");
        }

        private void passwordBoxText_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            passwordBoxText.Visibility = Visibility.Collapsed;
            passwordBox.Focus();
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(passwordBox.Password.Length == 0)
            {
                passwordBoxText.Visibility = Visibility.Visible;
            }
        }

    }
}
