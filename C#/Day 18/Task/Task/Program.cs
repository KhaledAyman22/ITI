using Task;

Console.WriteLine("Creating ResourcePool1");
ResourcePool resourcePool1 = new();
Console.WriteLine("Created ResourcePool1");

Console.WriteLine("\n\n");

Console.WriteLine("Creating ResourcePool2");
ResourcePool resourcePool2 = new();
Console.WriteLine("Created ResourcePool2");


Console.WriteLine("\n\n");

Resource? R01 = resourcePool1.GetResource();

Console.WriteLine($"R01 {R01.GetHashCode()}");

R01.UseResource();

R01.Dispose();

Console.WriteLine("Do Some Work");

Console.WriteLine($"Pool Size {resourcePool1.PoolSize}");

Resource R02 = resourcePool1.GetResource();

Console.WriteLine($"R02 {R02.GetHashCode()}");

Resource R03 = resourcePool2.GetResource();
Console.WriteLine($"R03 {R03.GetHashCode()}");
