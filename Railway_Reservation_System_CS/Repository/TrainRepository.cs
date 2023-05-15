using Microsoft.EntityFrameworkCore;
using Railway_Reservation_System_CS.Data;
using Railway_Reservation_System_CS.Interface;
using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Repository
{ 
        public class TrainRepository : ITrain
        {
            private readonly RailwayContext railwayContext;

            public TrainRepository(RailwayContext railwayContext)
            {
                this.railwayContext = railwayContext;
            }

            public async Task<List<Train>> GetTrains()
            {
                return await railwayContext.Trains.ToListAsync();
            }

            public async Task<Train> CheckAvailability(string source, string destination, DateTime departureTime)
            {
                var train = await railwayContext.Trains.Where(t => (t.Source == source) && (t.Destination == destination) && (t.DepartureTime == departureTime)).FirstOrDefaultAsync();
                return train;
            }

            public async Task<Train> AddTrain(Train train)
            {
                await railwayContext.Trains.AddAsync(train);
                await railwayContext.SaveChangesAsync();
                return train;
            }

            public async Task<Train> UpdateTrain(int id, Train train)
            {
                Train t = await railwayContext.Trains.FindAsync(id);
                if (t == null)
                {
                    return null;
                }

                t.TrainId = id;
                t.TrainName = train.TrainName;
                t.Source = train.Source;
                t.Destination = train.Destination;
                t.DepartureTime = train.DepartureTime;
                t.ArrivalTime = train.ArrivalTime;
                t.AvailableSeats = train.AvailableSeats;
                t.Price = train.Price;

                await railwayContext.SaveChangesAsync();
                return t;
            }

            public async Task<bool> RemoveTrain(int trainid)
            {
                var train = await railwayContext.Trains.FindAsync(trainid);
                if (train != null)
                {
                    railwayContext.Trains.Remove(train);
                    railwayContext.SaveChanges();
                }
                return true;
            }
        }
    }