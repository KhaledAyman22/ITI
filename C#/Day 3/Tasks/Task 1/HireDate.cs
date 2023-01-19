namespace Task_1
{
    internal partial class Program
    {
        public struct HireDate
        {
            private int _day;
            private int _month;
            private int _year;

            public HireDate(int day, int month, int year)
            {
                _day = day;
                _month = month;
                _year = year;
            }

            public int GetDay()
            {
                return _day;
            }

            public int GetMonth(){
                return _month;
            }
            
            public int GetYear(){
                return _year;
            }


            public void SetDay(int day)
            {
                _day = day;
            }

            public void SetMonth(int month)
            {
                _month = month;
            }

            public void SetYear(int year)
            {
                _year = year;
            }

            public override string ToString()
            {
                return $"{_day}/{_month}/{_year}\n";
            }
        }
    }
}