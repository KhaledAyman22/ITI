namespace AppointmentService
{
    public class BookingStatus
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}