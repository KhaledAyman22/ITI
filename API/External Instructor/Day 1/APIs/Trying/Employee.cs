namespace Trying;

internal class Employee
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;

    public Employee(int id,string name)
    {
        Id = id;
        Name = name;
    }

    public static implicit operator int (Employee e)
    {
        return e.Id;
    }
}


public record EmployeeRec(int Id, string Name);