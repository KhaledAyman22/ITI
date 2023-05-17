namespace Schedular
{
    public class ShipmentRequest
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public IEnumerable<ShipmentItem> Items { get; set; }
    }
}