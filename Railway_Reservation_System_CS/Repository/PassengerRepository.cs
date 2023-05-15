using Railway_Reservation_System_CS.Data;
using Railway_Reservation_System_CS.Interface;
using Railway_Reservation_System_CS.Models;
using Microsoft.EntityFrameworkCore;

namespace Railway_Reservation_System_CS.Repository
{
        public class PassengerRepository : IPassenger
        {
            private readonly RailwayContext railwayContext;

            public PassengerRepository(RailwayContext railwayContext)
            {
                this.railwayContext = railwayContext;
            }

            public async Task<Passenger> AddPassenger(Passenger passenger)
            {
                await railwayContext.Passengers.AddAsync(passenger);
                await railwayContext.SaveChangesAsync();
                return passenger;
            }

            public async Task<Passenger> DeletePassengerById(int id)
            {
                var passenger = await railwayContext.Passengers.FindAsync(id);
                if (passenger == null)
                {
                    return null;
                }
                railwayContext.Passengers.Remove(passenger);
                await railwayContext.SaveChangesAsync();

                return passenger;
            }


            public async Task<List<Passenger>> GetAllPassenger()
            {
                return await railwayContext.Passengers.ToListAsync();
            }

            public async Task<Passenger> GetPassengerById(int id)
            {
                return await railwayContext.Passengers.FirstOrDefaultAsync(a => a.PassengerId == id);
            }

            public async Task<Passenger> UpdatePassenger(int id, Passenger passenger)
            {
                var existingpass = await railwayContext.Passengers.FindAsync(id);

                if (existingpass == null)
                {
                    return null;
                }
                existingpass.PassengerId = id;
                existingpass.Name = passenger.Name;
                existingpass.EmailId = passenger.EmailId;
                existingpass.Password = passenger.Password;
                existingpass.Age = passenger.Age;
                existingpass.Gender = passenger.Gender;
                existingpass.Phone_no = passenger.Phone_no;
                await railwayContext.SaveChangesAsync();
                return existingpass;

            }
        }
    }
