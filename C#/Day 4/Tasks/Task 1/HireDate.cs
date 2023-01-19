namespace Task_1
{
    internal partial class Program
    {
        public struct HireDate
        {
            public int Day;
            public int Month;
            public int Year;

            public HireDate(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }
            public override string ToString()
            {
                return $"{Day}/{Month}/{Year}\n";
            }

            public bool Equals(HireDate other)
            {
                return Day == other.Day && Month == other.Month && Year == other.Year;
            }
        }
    }
}