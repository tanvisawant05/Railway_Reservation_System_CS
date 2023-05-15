using Microsoft.AspNetCore.Mvc;
using Railway_Reservation_System_CS.DTO;
using Railway_Reservation_System_CS.Interface;
using Railway_Reservation_System_CS.Models;


namespace Railway_Reservation_System_CS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase

    {
        private readonly IPassenger Ipassenger;

        public PassengerController(IPassenger Ipassenger)
        {
            this.Ipassenger = Ipassenger;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(int id)
        {

            return await Ipassenger.GetPassengerById(id);
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(int id, PassengerDTO passengerdto)
        {
            var passenger = new Passenger();
            passenger.Name = passengerdto.Name;
            passenger.EmailId = passengerdto.EmailId;
            passenger.Password = passengerdto.Password;
            passenger.Phone_no = passengerdto.Phone_no;
            passenger.Age = passengerdto.Age;
            passenger.Gender = passengerdto.Gender;
            passenger.UserId = passengerdto.UserId;

            passenger = await Ipassenger.UpdatePassenger(id, passenger);
            if (passenger == null)
            {
                return NotFound();
            }
            else
            {
                passenger.Name = passengerdto.Name;
                passenger.EmailId = passengerdto.EmailId;
                passenger.Password = passengerdto.Password;
                passenger.Phone_no = passengerdto.Phone_no;
                passenger.Age = passengerdto.Age;
                passenger.Gender = passengerdto.Gender;
                passenger.UserId = passengerdto.UserId;
            }
            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostPassenger(PassengerDTO passengerdto)
        {
            var passenger = new Passenger();
            passenger.Name = passengerdto.Name;
            passenger.EmailId = passengerdto.EmailId;
            passenger.Password = passengerdto.Password;
            passenger.Phone_no = passengerdto.Phone_no;
            passenger.Age = passengerdto.Age;
            passenger.Gender = passengerdto.Gender;
            passenger.UserId = passengerdto.UserId;

            await Ipassenger.AddPassenger(passenger);


            return Ok(passenger);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var passenger = await Ipassenger.DeletePassengerById(id);

            if (passenger != null)
            {
                return Ok(passenger);
            }


            return NotFound();
        }



    }
}