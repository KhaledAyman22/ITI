namespace AdapterDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee E = new Employee() {  FName = "Ahmed" , LName = "Ali" , Id = 1 , MonthlySalary = 5000};

            ///new Code , no access to Adaptee nor Client Source Code
            EmployeeAdapter adapter = new EmployeeAdapter(E);

            PersonEngine.ProcessPerson(adapter);

            ///Language Feature not OOP Desing , needs access to at least one type source code
            ///Casting implicit
            //PersonEngine.ProcessPerson(E);
            ///explicit
            //PersonEngine.ProcessPerson((Person)E);

        }
    }
}