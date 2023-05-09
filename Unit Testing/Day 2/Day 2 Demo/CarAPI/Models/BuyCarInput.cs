namespace CarAPI.Models
{
    public enum PaymentMethod
    {
        Cash = 1,
        Card = 2
    }
    public class BuyCarInput
    {
        public int CarId { get; set; }
        public int OwnerId { get; set; }
        public int Amount { get; set; }
        public PaymentMethod Method { get; set; }
    }
}