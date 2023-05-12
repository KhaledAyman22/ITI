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
using System.Windows.Shapes;
using Task02.ViewModels;

namespace Task02.Views
{
    /// <summary>
    /// Interaction logic for StudentsWindow.xaml
    /// </summary>
    public partial class DevelopersWindow : Window
    {
        private readonly DeveloperViewModel _developersViewModel;

        public DevelopersWindow(DeveloperViewModel developersViewModel)
        {
            _developersViewModel = developersViewModel;
            DataContext = _developersViewModel;

            InitializeComponent();

            Loaded += DevelopersWindow_Load;
        }

        private void DevelopersWindow_Load(object sender, RoutedEventArgs e)
        {
            _developersViewModel.Load();
        }
    }
}
