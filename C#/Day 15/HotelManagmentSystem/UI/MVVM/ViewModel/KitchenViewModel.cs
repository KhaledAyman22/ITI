using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.MVVM.ViewModel
{
    public class KitchenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Reservation? _Reservation;
        List<Reservation>? _OverviewSrc;
        List<ReservationKeyValue>? _QueueSrc;

        public Reservation? Reservation
        {
            get => _Reservation;
            set
            {
                _Reservation = value;
                OnPropertyChanged(nameof(Reservation));
            }
        }
        public List<Reservation>? OverviewSrc
        {
            get => _OverviewSrc;
            set
            {
                _OverviewSrc = value;
                OnPropertyChanged(nameof(OverviewSrc));
            }
        }
        public List<ReservationKeyValue>? QueueSrc
        {
            get => _QueueSrc;
            set
            {
                _QueueSrc = value;
                OnPropertyChanged(nameof(QueueSrc));
            }
        }


        public KitchenViewModel()
        {
            using HotelContext context = new();

            SetQueueSrc(context.Reservations.Where(i => i.CheckIn == true && i.SupplyStatus == false).ToList());
        }

        public bool UpdateCurrent()
        {
            if (Reservation == null) return false;

            using HotelContext context = new();

            var res = context.Reservations.Where(i => i.Id == Reservation.Id).SingleOrDefault();

            if (res == null) return false;

            res.Copy(Reservation);

            context.SaveChanges();

            SetQueueSrc(context.Reservations.Where(i => i.CheckIn == true && i.SupplyStatus == false).ToList());

            return true;
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

            float tot = Reservation.TotalBill - Reservation.FoodBill;
            int food = (Reservation?.BreakFast ?? 0) * 7 + (Reservation?.Lunch ?? 0) * 15 + (Reservation?.Dinner ?? 0) * 15;

            Reservation.FoodBill = food;
            Reservation.TotalBill = tot + food;

            OnPropertyChanged(nameof(Reservation));
        }
        
        public Dictionary<string, string>? GetFoodMenuData()
        {
            return new()
            {
                { "Breakfast", Reservation?.BreakFast.ToString()?? "0" },
                { "Lunch", Reservation?.Lunch.ToString()?? "0" },
                { "Dinner", Reservation?.Dinner.ToString()?? "0" },
            };
        }

        private void SetQueueSrc(List<Reservation> reservations)
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
            QueueSrc = tmp;
        }

        public void ReloadGrid()
        {
            using HotelContext context = new();
            OverviewSrc = context.Reservations.ToList();
        }
    }
}
