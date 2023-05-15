using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Interface
{
    public interface IPassenger
    {
        //Task<List<Passenger>> GetAllPassenger();

        Task<Passenger> GetPassengerById(int id);

        Task<Passenger> AddPassenger(Passenger passenger);

        Task<Passenger> UpdatePassenger(int id, Passenger passenger);

        Task<Passenger> DeletePassengerById(int id);

    }
}
