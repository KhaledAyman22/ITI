using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System;
using System.Threading.Tasks;

namespace UI.MVVM.ViewModel
{
    public class FinalizePaymentViewModel : INotifyPropertyChanged
    {
        public string? CurrentBill { get; set; }
        public string? FoodBill { get; set; }
        public string? Tax { get; set; }
        public string? Total { get; set; }

        List<string> _MonthSrc, _YearSrc, _PaymentTypeSrc;
        string? _PaymentType, _CardNumber, _CCV, _CardType, _Month, _Year;

        public List<string> MonthSrc
        {
            get => _MonthSrc;
            set
            {
                _MonthSrc = value;
                OnPropertyChanged(nameof(MonthSrc));
            }
        }
        public List<string> YearSrc
        {
            get => _YearSrc;
            set
            {
                _YearSrc = value;
                OnPropertyChanged(nameof(YearSrc));
            }
        }
        public List<string> PaymentTypeSrc
        {
            get => _PaymentTypeSrc;
            set
            {
                _PaymentTypeSrc = value;
                OnPropertyChanged(nameof(PaymentTypeSrc));
            }
        }
        public string? PaymentType
        {
            get => _PaymentType;
            set
            {
                _PaymentType = value;
                OnPropertyChanged(nameof(PaymentType));
            }
        }
        public string? CardNumber{
            get => _CardNumber;
            set
            {
                _CardNumber = value;
                SetCardType();
                OnPropertyChanged(nameof(CardNumber));
            }
        }
        public string? CCV{
            get => _CCV;
            set
            {
                _CCV = value;
                OnPropertyChanged(nameof(CCV));
            }
        }
        public string? CardType{
            get => _CardType;
            set
            {
                _CardType = value;
                OnPropertyChanged(nameof(CardType));
            }
        }
        public string? Month
        {
            get => _Month;
            set
            {
                _Month = value;
                OnPropertyChanged(nameof(Month));
            }
        }
        public string? Year
        {
            get => _Year;
            set
            {
                _Year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FinalizePaymentViewModel()
        {
            MonthSrc = Enumerable.Range(1, 12).ToList().ConvertAll(n=>n.ToString("D2"));
            YearSrc = Enumerable.Range(18, 20).ToList().ConvertAll(n => n.ToString("D2"));
            PaymentTypeSrc = new()
            {
                "Debit     ",
                "Credit    "
            };
        }

        public Dictionary<string, string>? ProcessInput()
        {

            return new()
            {
                { "CardType", CardType },
                { "CardNumber", CardNumber },
                { "CCV", CCV },
                { "CardExp", $"{Month}/{Year}" },
                { "PaymentType", PaymentType },
            };
        }

        public bool Validate()
        {
            return !(CardType.IsNullOrEmpty() && CardNumber.IsNullOrEmpty() && CCV.IsNullOrEmpty() && Month.IsNullOrEmpty() && Year.IsNullOrEmpty() && PaymentType.IsNullOrEmpty());
        }

        private void SetCardType()
        {
            if((CardNumber??"").Length > 0 )
                CardType = CardNumber[0] switch
                {
                    '3' => "AmericanExpress",
                    '4' => "Visa",
                    '5' => "MasterCard",
                    '6' => "Discover",
                    _ => "Unknown",
                };
        }
    }
}
