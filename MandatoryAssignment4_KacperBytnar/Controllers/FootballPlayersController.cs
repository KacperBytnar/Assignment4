using Assignment1_KacperBytnar;
using MandatoryAssignment4_KacperBytnar.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MandatoryAssignment4_KacperBytnar.Controllers
{
    [Route("FootballPlayers")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: api/<FootballPlayersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<FootballPlayer> Get()
        {
            IEnumerable<FootballPlayer> result = new List<FootballPlayer>(_manager.GetAll());
            if (result.Any()) return Ok(result);
            return NoContent();
        }

        // GET api/<FootballPlayersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer? result = _manager.GetById(id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        // POST api/<FootballPlayersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public FootballPlayer Post([FromBody] FootballPlayer value)
        {

            return _manager.Add(value);
        }

        // PUT api/<FootballPlayersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer? value)
        {
            if (value == null) return BadRequest();
            try
            {
                var updatedPlayer = _manager.Update(id, value);
                return Ok(updatedPlayer);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            try
            {
                _manager.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
