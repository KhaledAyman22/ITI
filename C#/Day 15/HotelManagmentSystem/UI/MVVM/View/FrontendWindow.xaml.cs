using DAL.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UI.MVVM.ViewModel;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for Frontend.xaml
    /// </summary>
    public partial class FrontendWindow : Window
    {
        public FrontendWindow()
        {
            InitializeComponent();

            DataContext = new FrontendViewModel();
        }

        private void UpdateButtonnClick(object sender, RoutedEventArgs e)
        {
            if (((FrontendViewModel)DataContext).UpdateCurrent())
                MessageBox.Show("Entry updated successfully");
            else
                MessageBox.Show("Couldn't update");

            updateBtn.IsEnabled = false;
        }

        private void DeleteButtonnClick(object sender, RoutedEventArgs e)
        {
            if (existing.SelectedIndex >= 0)
            {
                if (((FrontendViewModel)DataContext).DeleteWithID(existing.SelectedValue))
                    MessageBox.Show("Reservation Deleted Successfully");
                else 
                    MessageBox.Show("Couldn't delete reservation");

                existing.Text = "Select reservation to edit";
            }
        }

        private void EditButtonnClick(object sender, RoutedEventArgs e)
        {
            ((FrontendViewModel)DataContext).EditingMode();
            existing.Text = "Select reservation to edit";
        }

        private void NewButtonnClick(object sender, RoutedEventArgs e)
        {
            ((FrontendViewModel)DataContext).AddingMode();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            ((FrontendViewModel)DataContext).SearchFor(searchBox.Text);
        }

        private void TabChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.Source is TabControl t)
            {
                switch (t.SelectedIndex)
                {
                    case 2: ((FrontendViewModel)DataContext).SetTab3Grid(); break;
                    case 3: ((FrontendViewModel)DataContext).SetTab4ListBoxes(); break;
                }
            }

        }

        private void FoodMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            var data = ((FrontendViewModel)DataContext).GetFoodMenuData();
            FoodMenuWindow foodMenuWindow = new(data);

            if (foodMenuWindow.ShowDialog() == true)
            {
                ((FrontendViewModel)DataContext).SetFoodMenuData(foodMenuWindow.Data);
            }
        }

        private void FinalizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!((FrontendViewModel)DataContext).ValidateData())
            {
                MessageBox.Show("Invalid data");
                return;
            }

            var data = ((FrontendViewModel)DataContext).GetPaymentData();
            FinalizePaymentWindow finalizePaymentWindow = new(data);

            if(finalizePaymentWindow.ShowDialog() == true)
            {
                ((FrontendViewModel)DataContext).SetPaymentData(finalizePaymentWindow.Data);
            }
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (((FrontendViewModel)DataContext).SaveNew())
                MessageBox.Show("Reservation added successfully");
            else
                MessageBox.Show("Reservation couldn't be added");
        }
    }
}
