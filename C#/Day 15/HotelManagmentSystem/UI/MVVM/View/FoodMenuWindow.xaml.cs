using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.MVVM.ViewModel;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for FoodMenu.xaml
    /// </summary>
    public partial class FoodMenuWindow : Window
    {
        public Dictionary<string, string>? Data { get; set; }
        
        public FoodMenuWindow(Dictionary<string, string>? data)
        {
            InitializeComponent();
            DataContext = new FoodMenuViewModel();

            {
                int tmp;
                
                if(int.TryParse(data["Breakfast"], out tmp))
                {
                    ((FoodMenuViewModel)DataContext).Breakfast = tmp;
                    if (tmp > 0) breakfastCheck.IsChecked = true;
                }

                if (int.TryParse(data["Lunch"], out tmp))
                {
                    ((FoodMenuViewModel)DataContext).Lunch = tmp;
                    if (tmp > 0) lunchCheck.IsChecked = true;
                }

                if (int.TryParse(data["Dinner"], out tmp))
                {
                    ((FoodMenuViewModel)DataContext).Dinner = tmp;
                    if (tmp > 0) dinnerCheck.IsChecked = true;
                }

            }

            

            {
                try
                {
                    bool tmp;
                    ((FoodMenuViewModel)DataContext).Cleaning = bool.TryParse(data["Cleaning"], out tmp) ? tmp : false;
                    ((FoodMenuViewModel)DataContext).Towels = bool.TryParse(data["Towels"], out tmp) ? tmp : false;
                    ((FoodMenuViewModel)DataContext).SweetSurprise = bool.TryParse(data["SweetSurprise"], out tmp) ? tmp : false;
                }
                catch
                {
                    checkboxPanel.Visibility = Visibility.Collapsed;
                }
            }
        }


        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            Data = ((FoodMenuViewModel)DataContext).ProcessInput();
            DialogResult = true;
        }
    }
}
