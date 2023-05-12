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
using Task01.ViewModels;

namespace Task01.Views
{
    /// <summary>
    /// Interaction logic for StudentsWindow.xaml
    /// </summary>
    public partial class StudentsWindow : Window
    {
        private readonly StudentViewModel _studentsViewModel;

        public StudentsWindow(StudentViewModel studentsViewModel)
        {
            _studentsViewModel = studentsViewModel;
            DataContext = _studentsViewModel;

            InitializeComponent();

            Loaded += StudentsWindow_Load;
        }

        private void StudentsWindow_Load(object sender, RoutedEventArgs e)
        {
            _studentsViewModel.Load();
        }
    }
}
