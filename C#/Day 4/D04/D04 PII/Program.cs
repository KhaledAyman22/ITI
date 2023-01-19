using static System.Runtime.InteropServices.JavaScript.JSType;

namespace D04_PII
{
    struct Employee
    {
        public int EmpID;

        string FullName;

        public string GetName () { return FullName.ToUpperInvariant(); }

        internal void SetName ( string _Name)
        { FullName = _Name.Length<=20?_Name:_Name.Substring(0,20); }

        decimal monthlysalary;

        public decimal Salary
        {
            internal set
            { monthlysalary = value >= 2700 ? value : 2700; }
            get 
            { return monthlysalary; }
        }

        public decimal Tax
        {
            get { return 0.1M * monthlysalary; }
        }

        public Employee(int _ID , string _Name , decimal _Salary)
        {
            EmpID = _ID;
            FullName = _Name;
            monthlysalary = _Salary;
        }


        public override string ToString()
        {
            return $"ID : {EmpID} , Name : {FullName} , Salary : {monthlysalary}";
        }
    }

    struct PhoneBook
    {
        string[] Names;
        long[] Numbers;
        readonly int size;

        public int Size { get { return size;} }

        public PhoneBook(int _Size)
        {
            size = _Size;
            Names = new string[size];
            Numbers= new long[size];
        }

        public void SetEntry (int index , string Name , long Number)
        {
            if ((index >=0)&&(index <size))
            {
                Names[index] = Name;
                Numbers[index] = Number;
            }
        }

        public long GetNumber (string Name)
        {
            for (int i=0; i < size; i++)
                if (Names[i] == Name)
                    return Numbers[i];
            return -1;
        }

        ///set (long value , string Name) ,, long get(string Name)
        public long this[string Name]
        {
            set 
            {
                for (int i = 0; i < size; i++)
                    if (Names[i] == Name)
                        Numbers[i] = value;
            }
            get {
                for (int i = 0; i < size; i++)
                    if (Names[i] == Name)
                        return Numbers[i];
                return -1;

            }
        }

        public string this[int index]
        {
            get
            {
                if ((index >= 0) && (index < size))
                    return $"{Names[index]}:::{Numbers[index]}";
                return "NA";
            }
        }

        public long this[int index , string Name]
        {
            set
            {
                if ((index >= 0) && (index < size))
                {
                    Names[index] = Name;
                    Numbers[index] = value;
                }
            }
        }

    }

    internal class Program
    {

        public static void Main ()
        {
            try
            {
                //DoSomeWork();
                DoSomeProtectiveWork();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Inside Main Catch Block");
            }
        }

        public static void DoSomeProtectiveWork ()
        {
            int X, Y, Z;

            do
            {
                Console.WriteLine("Enter First Number");
            }
            while (int.TryParse(Console.ReadLine(), out X) ==false);

            do
            {
                Console.WriteLine("Enter Second Number");
            }
            while ((!int.TryParse(Console.ReadLine(), out Y))||(Y==0));

            Z = X / Y;

            int[] Arr = { 1, 2, 3, 4, 5 };

            if (5 < Arr.Length) { Console.WriteLine(Arr[5]); }
        }

        public static void DoSomeWork()
        {
            int X = 1;
            int Y=1;
            int Z;

            try
            {
                X = int.Parse(Console.ReadLine());
                Y = Convert.ToInt32(Console.ReadLine());

                if (Y < 0)
                    throw new NegativeNumberException();

                Z = X / Y;
                Console.WriteLine($"Z = {Z}");

                int[] Arr = { 1, 2, 3, 4, 5 };

                Console.WriteLine(Arr[5]);///IndexoutofrangeException


                Console.WriteLine("End of try");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Y can't equals Zero");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //catch (Exception Ex)
            //{
            //    Console.WriteLine(Ex.Message);
            //    Console.WriteLine("inside Catch");
            //}
            catch (NegativeNumberException ex)
            {

            }
            finally
            {
                Console.WriteLine("Inside Finally Block");
            }
            Console.WriteLine("After Try/Catch");

        }


        static void OldMain(string[] args)
        {
            #region Properties
            //Employee E = new Employee(101, "Ali", 5000);
            //Console.WriteLine(E);

            //E.EmpID = -112;

            //Console.WriteLine(E.EmpID);

            //E.SetName("Ali");

            //Console.WriteLine(E.GetName());

            //E.Salary = 500; ///Call Set , value : 500

            //Console.WriteLine(E.Salary); /// Call Get

            //Console.WriteLine(E.Tax);

            ////E.Tax = 500; ///Compilation error 
            #endregion

            #region Indexer
            //PhoneBook phoneBook = new(5);

            //phoneBook.SetEntry(0, "ABC", 123);
            //phoneBook.SetEntry(1, "XYZ", 456);
            //phoneBook.SetEntry(2, "KLM", 789);
            //phoneBook[3, "DEF"] = 707;

            ////Console.WriteLine(phoneBook[3, "DEF"]);///Set Only

            //phoneBook["XYZ"] = 654;
            /////PhoneBook.MyProp = 654

            //Console.WriteLine(
            //    phoneBook.GetNumber("XYZ")
            //    );

            //Console.WriteLine(
            //    phoneBook["XYZ"]
            //    );


            //for (int i = 0; i < phoneBook.Size; i++)
            //    Console.WriteLine(phoneBook[i]); 
            #endregion

        }
    }
}