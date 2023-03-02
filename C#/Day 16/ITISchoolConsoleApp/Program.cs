// See https://aka.ms/new-console-template for more information
using ITISchoolConsoleApp;

using SchoolContext Context = new();

//Context.Add(new Teacher() { FullName = "Ahmed Aly", Salary = 5000 });
//Context.Add(new Student() { FullName = "Sally Samier", EnrollmentDate = new DateTime(2022, 1, 1) });


//var T = Context.Teachers.First();
//T.Salary += 100;

Context.Add(new Teacher() { FullName = "Ramy Aly", Salary = 5000 });


foreach (var item in Context.Teachers)
{
    Console.WriteLine(item.FullName);
}


//var T = Context.People.OfType<Teacher>().First();

Console.WriteLine(

    Context.SaveChanges()

    ); ;
