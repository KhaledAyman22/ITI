// See https://aka.ms/new-console-template for more information
using Trying;

Console.WriteLine("Hello, World!");

Console.WriteLine(GetEmployee());

var e1 = new EmployeeRec(10, "E1");
var e2 = new EmployeeRec(10, "E1");

Console.WriteLine(e1 == e2);

Console.WriteLine(e1.ToString());

static int GetEmployee()
{
    return new Employee(10, "");
}