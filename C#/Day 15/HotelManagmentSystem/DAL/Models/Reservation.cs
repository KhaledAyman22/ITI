using System.Reflection;

namespace DAL.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; } = "1-1-1999";
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int NumberGuest { get; set; }
        public string StreetAddress { get; set; }
        public string AptSuite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string RoomType { get; set; }
        public string RoomFloor { get; set; }
        public string RoomNumber { get; set; }
        public float TotalBill { get; set; }
        public string PaymentType { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardExp { get; set; }
        public string CardCvc { get; set; }
        public DateTime ArrivalTime { get; set; } = DateTime.Now.AddMonths(-5);
        public DateTime LeavingTime { get; set; } = DateTime.Now.AddMonths(5);
        public bool CheckIn { get; set; }
        public int BreakFast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
        public bool Cleaning { get; set; }
        public bool Towel { get; set; }
        public bool SSurprise { get; set; }
        public bool SupplyStatus { get; set; }
        public int FoodBill { get; set; }

        public void Copy(Reservation res, bool withID)
        {
            if(withID) Id = res.Id;
            FirstName = res.FirstName;
            LastName = res.LastName;
            BirthDay = res.BirthDay;
            Gender = res.Gender;
            PhoneNumber = res.PhoneNumber;
            EmailAddress = res.EmailAddress;
            NumberGuest = res.NumberGuest;
            StreetAddress = res.StreetAddress;
            AptSuite = res.AptSuite;
            City = res.City;
            State = res.State;
            ZipCode = res.ZipCode;
            RoomType = res.RoomType;
            RoomFloor = res.RoomFloor;
            RoomNumber = res.RoomNumber;
            TotalBill = res.TotalBill;
            PaymentType = res.PaymentType;
            CardType = res.CardType;
            CardNumber = res.CardNumber;
            CardExp = res.CardExp;
            CardCvc = res.CardCvc;
            ArrivalTime = res.ArrivalTime;
            LeavingTime = res.LeavingTime;
            CheckIn = res.CheckIn;
            BreakFast = res.BreakFast;
            Lunch = res.Lunch;
            Dinner = res.Dinner;
            Cleaning = res.Cleaning;
            Towel = res.Towel;
            SSurprise = res.SSurprise;
            SupplyStatus = res.SupplyStatus;
            FoodBill = res.FoodBill;
        }
    }
}
