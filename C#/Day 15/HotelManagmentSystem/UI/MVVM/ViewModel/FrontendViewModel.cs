using DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using DAL.Models;
using System;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Diagnostics;

namespace UI.MVVM.ViewModel
{
    class FrontendViewModel : INotifyPropertyChanged
    {
        #region Vars

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != "IsNew") IsNew = Visibility.Hidden;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Reservation? _Reservation;
        List<ReservationKeyValue>? _ComboSrc;
        List<string>? _State, _RoomType, _RoomFloor, _RoomNumber, _Gender, _OccupiedSrc, _ReservedSrc;
        List<Reservation>? _ReservationsSrc, _SearchSrc;
        List<int>? _NumberGuests;
        Visibility _IsEdit = Visibility.Hidden;
        Visibility _IsNew = Visibility.Hidden;


        public Reservation? Reservation
        {
            get => _Reservation;
            set
            {
                _Reservation = value;
                OnPropertyChanged(nameof(Reservation));
            }
        }
        public List<ReservationKeyValue>? ComboSrc
        {
            get => _ComboSrc;
            set
            {
                _ComboSrc = value;
                OnPropertyChanged(nameof(ComboSrc));
            }
        }
        public List<string>? State
        {
            get => _State;
            set
            {
                _State = value;
                OnPropertyChanged(nameof(State));
            }
        }
        public List<string>? RoomType
        {
            get => _RoomType;
            set
            {
                _RoomType = value;
                OnPropertyChanged(nameof(RoomType));
            }
        }
        public List<string>? RoomFloor
        {
            get => _RoomFloor;
            set
            {
                _RoomFloor = value;
                OnPropertyChanged(nameof(RoomFloor));
            }
        }
        public List<string>? RoomNumber
        {
            get => _RoomNumber;
            set
            {
                _RoomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        public List<string>? Gender
        {
            get => _Gender;
            set
            {
                _Gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public List<int>? NumberGuests
        {
            get => _NumberGuests;
            set
            {
                _NumberGuests = value;
                OnPropertyChanged(nameof(NumberGuests));
            }
        }
        public List<string>? OccupiedSrc
        {
            get => _OccupiedSrc;
            set
            {
                _OccupiedSrc = value;
                OnPropertyChanged(nameof(OccupiedSrc));
            }
        }
        public List<string>? ReservedSrc
        {
            get => _ReservedSrc;
            set
            {
                _ReservedSrc = value;
                OnPropertyChanged(nameof(ReservedSrc));
            }
        }
        public List<Reservation>? ReservationsSrc
        {
            get => _ReservationsSrc;
            set
            {
                _ReservationsSrc = value;
                OnPropertyChanged(nameof(ReservationsSrc));
            }
        }
        public List<Reservation>? SearchSrc
        {
            get => _SearchSrc;
            set
            {
                _SearchSrc = value;
                OnPropertyChanged(nameof(SearchSrc));
            }
        }
        public Visibility IsEdit
        {
            get => _IsEdit;
            set
            {
                _IsEdit = value;
                OnPropertyChanged(nameof(IsEdit));
            }
        }
        public Visibility IsNew
        {
            get => _IsNew;
            set
            {
                _IsNew = value;
                OnPropertyChanged(nameof(IsNew));
            }
        }

        #endregion

        public FrontendViewModel()
        {
            using HotelContext context = new();

            InitComboBoxes(context);
            Reservation = new();
        }

        public void SetTab3Grid()
        {
            using HotelContext context = new();
            ReservationsSrc = context.Reservations.ToList();
        }

        public void SetTab4ListBoxes()
        {
            using HotelContext context = new();
            OccupiedSrc = context.Reservations.Where(i => i.CheckIn == true).Select(i => $"{i.Id} | {i.FirstName} | {i.LastName} | {i.PhoneNumber}").ToList();
            ReservedSrc = context.Reservations.Where(i => i.CheckIn == false).Select(i => $"{i.Id} | {i.FirstName} | {i.LastName} | {i.PhoneNumber}").ToList();
        }

        public List<Reservation> EditingMode()
        {
            if (IsEdit == Visibility.Hidden)
            {
                IsEdit = Visibility.Visible;
                using HotelContext context = new();
                var tmp = context.Reservations.ToList();

                SetComboSrc(tmp);

                return tmp;
            }
            else return new();
        }

        public void AddingMode()
        {
            Reservation = new();

            if (IsEdit == Visibility.Visible)
            {
                IsEdit = Visibility.Hidden;
            }
        }

        public void SearchFor(string text)
        {
            using HotelContext context = new();
            text = text.ToLower();
            Regex regex = new($"^.*{text}.*$");
            SearchSrc = context.Reservations.AsEnumerable()
                               .Where(p => p.GetType().GetProperties().Any(prop => regex.IsMatch(prop?.GetValue(p)?.ToString()?.ToLower() ?? "")))
                               .ToList();
        }

        public bool DeleteWithID(object obj)
        {
            if (obj is Reservation reservation)
            {
                using HotelContext context = new();
                var res = context.Reservations.Where(i => i.Id == reservation.Id).Single();
                context.Reservations.Remove(res);

                context.SaveChanges();
                
                SetComboSrc(context.Reservations.ToList());
                Reservation = new();

                return true;
            }
            return false;
        }

        public bool UpdateCurrent()
        {
            if(Reservation == null) return false;

            using HotelContext context = new();

            var res = context.Reservations.Where(i=>i.Id == Reservation.Id).SingleOrDefault();

            if (res == null) return false;

            res.Copy(Reservation, false);

            context.SaveChanges();

            SetComboSrc(context.Reservations.ToList());
            
            return true;
        }

        public Dictionary<string, string>? GetFoodMenuData()
        {
            return new()
            {
                { "Breakfast", Reservation?.BreakFast.ToString()?? "0" },
                { "Lunch", Reservation?.Lunch.ToString()?? "0" },
                { "Dinner", Reservation?.Dinner.ToString()?? "0" },
                { "Cleaning", Reservation?.Cleaning.ToString()?? "False" },
                { "Towels", Reservation?.Towel.ToString()?? "False" },
                { "SweetSurprise", Reservation ?.SSurprise.ToString() ?? "False" }
            };
        }
       
        public void SetFoodMenuData(Dictionary<string, string>? data)
        {
            if (data == null) return;

            Reservation ??= new();

            {
                int tmp;
                Reservation.BreakFast = int.TryParse(data["Breakfast"], out tmp) ? tmp : 0;
                Reservation.Lunch = int.TryParse(data["Lunch"], out tmp) ? tmp : 0;
                Reservation.Dinner = int.TryParse(data["Dinner"], out tmp) ? tmp : 0;
            }
            
            {
                bool tmp;
                Reservation.Cleaning = bool.TryParse(data["Cleaning"], out tmp) ? tmp : false;
                Reservation.Towel = bool.TryParse(data["Towels"], out tmp) ? tmp : false;
                Reservation.SSurprise = bool.TryParse(data["SweetSurprise"], out tmp) ? tmp : false;
            }

        }

        public Dictionary<string, string> GetPaymentData()
        {
            return new()
            {
                { "CardType", Reservation?.CardType ?? "" },
                { "CardNumber", Reservation?.CardNumber ?? "" },
                { "CCV", Reservation?.CardCvc ?? "" },
                { "CardExp", Reservation?.CardExp ?? "" },
                { "PaymentType", Reservation?.PaymentType?? "" },
                { "FoodPrice", CalcFoodPrice() },
                { "RoomPrice", CalcRoomPrice() },
            };
        }

        public void SetPaymentData(Dictionary<string, string>? data)
        {
            if (data == null) return;
            
            Reservation ??= new();

            Reservation.CardType = data["CardType"];
            Reservation.CardNumber = data["CardNumber"];
            Reservation.CardCvc = data["CCV"];
            Reservation.CardExp = data["CardExp"];
            Reservation.PaymentType = data["PaymentType"];

            if(IsEdit == Visibility.Hidden)
            {
                IsNew = Visibility.Visible;
            }
        }
       
        public bool SaveNew()
        {
            bool ret;
            using HotelContext context = new();
            
            try
            {
                Reservation.RoomFloor = (RoomType?.IndexOf(Reservation.RoomType) + 1)?.ToString()??"";
                context.Reservations.Add(Reservation);

                context.SaveChanges();
                ret = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                ret = false;
            }
            finally
            {
                IsNew = Visibility.Hidden;
                SetComboSrc(context.Reservations.ToList());
                Reservation = new();
            }

            return ret;
        }

        private void InitComboBoxes(HotelContext context)
        {
            State = context.Reservations.Select(i => i.State).Distinct().ToList();
            RoomType = new() { "Single    ", "Double    ", "Twin      ", "Duplex    ", "Suite     " };
            NumberGuests = Enumerable.Range(1, 6).ToList();
            RoomFloor = Enumerable.Range(1, 5).ToList().ConvertAll(i=>i.ToString());
            RoomNumber = context.Reservations.Select(i => i.RoomNumber).Distinct().ToList();
            Gender = context.Reservations.Select(i => i.Gender).Distinct().ToList();
        }
        
        private void SetComboSrc(List<Reservation> reservations)
        {
            List<ReservationKeyValue> tmp = new();
            foreach (var i in reservations)
            {
                tmp.Add(new()
                {
                    DisplayText = $"{i.Id} | {i.FirstName} | {i.LastName} | {i.PhoneNumber}",
                    Value = i
                });
            }
            ComboSrc = tmp;
        }

        private string CalcFoodPrice()
        {
            return ((Reservation?.BreakFast?? 0) * 7 + (Reservation?.Lunch?? 0) * 15 + (Reservation?.Dinner ?? 0) * 15).ToString();
        }

        private string CalcRoomPrice()
        {
            return ((Reservation?.RoomType?.Trim() ?? "") switch
            {
                "Single" => "149",
                "Double" => "299",
                "Twin" => "349",
                "Duplex" => "399",
                "Suite" => "499",
                _ => "0"
            });
        }

        public bool ValidateData()
        {
            return
                Reservation != null &&
                !Reservation.FirstName.IsNullOrEmpty() &&
                !Reservation.FirstName.IsNullOrEmpty() &&
                !Reservation.LastName.IsNullOrEmpty() &&
                !Reservation.BirthDay.IsNullOrEmpty() &&
                !Reservation.Gender.IsNullOrEmpty() &&
                !Reservation.PhoneNumber.IsNullOrEmpty() &&
                !Reservation.EmailAddress.IsNullOrEmpty() &&
                !Reservation.StreetAddress.IsNullOrEmpty() &&
                !Reservation.AptSuite.IsNullOrEmpty() &&
                !Reservation.City.IsNullOrEmpty() &&
                !Reservation.State.IsNullOrEmpty() &&
                !Reservation.ZipCode.IsNullOrEmpty() &&
                !Reservation.RoomType.IsNullOrEmpty() &&
                !Reservation.RoomNumber.IsNullOrEmpty();
                /*!Reservation.PaymentType.IsNullOrEmpty() &&
                !Reservation.CardType.IsNullOrEmpty() &&
                !Reservation.CardNumber.IsNullOrEmpty() &&
                !Reservation.CardExp.IsNullOrEmpty() &&
                !Reservation.CardCvc.IsNullOrEmpty();*/
        }
    }
}
