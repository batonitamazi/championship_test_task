using Microsoft.AspNetCore.Mvc;

namespace Upgaming_test_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        [HttpGet("GetScoresByDay/{date}")]
        public IActionResult GetScoresByDay(DateTime date)
        {
            return Ok();
        }

        [HttpGet("GetScoresByMonth/{month}")]
        public IActionResult GetScoresByMonth(int month)
        {
            return Ok();
        }

        [HttpGet("GetStats")]
        public IActionResult GetStats()
        {
            return Ok();
        }

        [HttpGet("GetAllData")]
        public IActionResult GetAllData()
        {
            return Ok();
        }
    }
}
