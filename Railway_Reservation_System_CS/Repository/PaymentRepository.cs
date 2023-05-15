using Railway_Reservation_System_CS.Data;
using Railway_Reservation_System_CS.Interface;
using Railway_Reservation_System_CS.Models;
using Microsoft.EntityFrameworkCore;

namespace Railway_Reservation_System_CS.Repository
{
        public class PaymentRepository : IPayment
        {
            private readonly RailwayContext railwayContext;

            public PaymentRepository(RailwayContext railwayContext)
            {
                this.railwayContext = railwayContext;
            }

            public async Task<Payment> CancelPayment(Payment payment)
            {

                var pay = await railwayContext.Payments.FindAsync(payment);
                railwayContext.Payments.Remove(pay);
                await railwayContext.SaveChangesAsync();
                return pay;
            }

            public async Task<Payment> CheckPaymentStatus(string status)
            {
                return await railwayContext.Payments.FirstOrDefaultAsync(p => p.PaymentStatus == status);
            }

            public async Task<Payment> GetPaymentById(int id)
            {
                return await railwayContext.Payments.FirstOrDefaultAsync(p => p.Payment_id == id);
            }

            public async Task<List<Payment>> GetPayments()
            {
                return await railwayContext.Payments.ToListAsync();
            }

            public async Task<Payment> MakePayment(Payment payment)
            {
                await railwayContext.Payments.AddAsync(payment);
                await railwayContext.SaveChangesAsync();
                return payment;
            }
        }
    }

