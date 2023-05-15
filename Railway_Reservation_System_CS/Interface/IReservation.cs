using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Interface
{
    public interface IReservation
    {
        Task<Reservation> MakeReservatation();

        Task<Reservation> GetReservationId();

        Task<Reservation> CancelReservation();

       
    }
}
