using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservation_System_CS.DTO;
using Railway_Reservation_System_CS.Interface;
using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _paymentRepository;

        public PaymentController(IPayment paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _paymentRepository.GetPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _paymentRepository.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment(PaymentDTO paymentdto)
        {
            var payment = new Payment();
            payment.PaymentDateTime = paymentdto.PaymentDateTime;
            payment.PaymentMethod = paymentdto.PaymentMethod;
            payment.PaymentStatus = paymentdto.PaymentStatus;
            payment.TotalAmount = paymentdto.TotalAmount;
            payment.ReservationId = paymentdto.ReservationId;

            payment = await _paymentRepository.MakePayment(payment);
            return Ok(payment);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> CheckPaymentStatus(string status)
        {
            var payment = await _paymentRepository.CheckPaymentStatus(status);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CancelPayment(int id, Payment payment)
        {
            if (id != payment.Payment_id)
            {
                return BadRequest();
            }
            var result = await _paymentRepository.CancelPayment(payment);
            return Ok(result);
        }
    }
}

