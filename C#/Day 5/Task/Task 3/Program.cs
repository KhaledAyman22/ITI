namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NIC nic1 = NIC.GetInstance();
            NIC nic2 = NIC.GetInstance();

            Console.WriteLine(nic1.GetHashCode() == nic2.GetHashCode());
        }
    }
}