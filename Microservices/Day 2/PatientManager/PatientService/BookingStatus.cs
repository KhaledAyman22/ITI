namespace PatientService
{
    internal class BookingStatus
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public int PatientId { get; set; }
    }
}