using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for FinalizePayment.xaml
    /// </summary>
    public partial class FinalizePaymentWindow : Window
    {
        public Dictionary<string, string>? Data { get; set; }

        public FinalizePaymentWindow(Dictionary<string, string> data)
        {
            InitializeComponent();
            DataContext = new FinalizePaymentViewModel();

            var dc = (FinalizePaymentViewModel)DataContext;
            int tot, fp = 0, rp = 0;
            int.TryParse(data["FoodPrice"], out fp);
            int.TryParse(data["RoomPrice"], out rp);
            tot = fp + rp;

            dc.CardType = data["CardType"] ?? "";
            dc.CardNumber = data["CardNumber"] ?? "";
            dc.CCV = data["CCV"] ?? "";
            dc.PaymentType = data["PaymentType"]?? "";

            if (!data["CardExp"].IsNullOrEmpty())
            {
                dc.Month = data["CardExp"].Substring(0, 2);
                dc.Year = data["CardExp"].Substring(3, 2);
            }

            
            foodBill.Text = Convert.ToDecimal(data["FoodPrice"]).ToString("C");
            crntBill.Text = Convert.ToDecimal(data["RoomPrice"]).ToString("C");
            tax.Text = "Tax: " + Convert.ToDecimal((tot * 0.07)).ToString("C");
            total.Text = "Total: " + Convert.ToDecimal((tot * 1.07)).ToString("C");
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (((FinalizePaymentViewModel)DataContext).Validate())
            {
                Data = ((FinalizePaymentViewModel)DataContext).ProcessInput();
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }
    }
}
