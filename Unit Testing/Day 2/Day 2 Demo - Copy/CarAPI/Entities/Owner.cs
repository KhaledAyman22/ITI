namespace CarAPI.Entities
{
    public class Owner
    {

        public int Id { get; }

        public string Name { get; set; }
        public Car Car { get; set; }

        public Owner(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Owner()
        {

        }
    }
}