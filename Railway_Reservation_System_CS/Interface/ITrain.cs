using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Interface

{
    public interface ITrain
    {
        Task<List<Train>> GetTrains(); //passenger and admin

        Task<Train> CheckAvailability(string source, string destination, DateTime departureTime); //passenger

        Task<Train> AddTrain(Train train);

        Task<Train> UpdateTrain(int id, Train train);

        Task<bool> RemoveTrain(int trainid);
    }
}
