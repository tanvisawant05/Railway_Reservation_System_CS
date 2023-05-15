using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Interface
{
        public interface IPayment
        {
            Task<List<Payment>> GetPayments();
            Task<Payment> GetPaymentById(int id);
            Task<Payment> MakePayment(Payment payment);
            Task<Payment> CheckPaymentStatus(string status);
            Task<Payment> CancelPayment(Payment payment);
        }
    }
