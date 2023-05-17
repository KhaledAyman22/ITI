namespace AppointmentService
{
    public class BookingRequest
    {

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int SlotId { get; set; }
    }
}