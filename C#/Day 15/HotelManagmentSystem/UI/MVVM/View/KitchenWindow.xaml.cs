using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UI.MVVM.ViewModel;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for KitchenWindow.xaml
    /// </summary>
    public partial class KitchenWindow : Window
    {
        public KitchenWindow()
        {
            InitializeComponent();
            DataContext = new KitchenViewModel();
        }

        private void UpdateButtonnClick(object sender, RoutedEventArgs e)
        {
            if (((KitchenViewModel)DataContext).UpdateCurrent())
                MessageBox.Show("Entry updated successfully");
            else
                MessageBox.Show("Couldn't update");
        }

        private void FoodMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (((KitchenViewModel)DataContext).Reservation == null) return;

            var data = ((KitchenViewModel)DataContext).GetFoodMenuData();
            FoodMenuWindow foodMenuWindow = new(data);

            if (foodMenuWindow.ShowDialog() == true)
            {
                ((KitchenViewModel)DataContext).SetFoodMenuData(foodMenuWindow.Data);
            }
        }

        private void TabChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl t)
            {
                switch (t.SelectedIndex)
                {
                    case 1: ((KitchenViewModel)DataContext).ReloadGrid(); break;
                }
            }
        }
    }
}
