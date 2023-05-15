namespace Railway_Reservation_System_CS.DTO
{
    public class PaymentDTO
    {
        public DateTime PaymentDateTime { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public float TotalAmount { get; set; }
        public int ReservationId { get; set; }
    }
}
