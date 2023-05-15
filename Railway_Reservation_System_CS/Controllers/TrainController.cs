using Microsoft.AspNetCore.Mvc;
using Railway_Reservation_System_CS.Interface;
using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Controllers

    {
        [Route("api/[controller]")]
        [ApiController]
        public class TrainController : ControllerBase
        {
            private readonly ITrain Itrain;

            public TrainController(ITrain trainRepository)
            {
                this.Itrain = trainRepository;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Train>>> GetAll()
            {
                return await Itrain.GetTrains();
            }

            [HttpGet("GetSearch")]
            public async Task<ActionResult<Train>> GetSearch([FromQuery] string source, [FromQuery] string destination, [FromQuery] DateTime departureTime)
            {
                return await Itrain.CheckAvailability(source, destination, departureTime);

            }

            [HttpPost]
            public async Task<ActionResult<Train>> AddTrain(Train train)
            {
                var addedTrain = await Itrain.AddTrain(train);
                //return CreatedAtAction(nameof(GetTrains), new { id = addedTrain.Id }, addedTrain);
                return Ok(addedTrain);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTrain(int id)
            {
                bool passenger = await Itrain.RemoveTrain(id);
                if (passenger)
                {
                    return Ok();
                }

                return NotFound();
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Train>> UpdateTrain(int id, Train train)
            {
                train = await Itrain.UpdateTrain(id, train);
                if (train == null)
                {
                    return NotFound();
                }
                return Ok(train);
            }
        }
    }