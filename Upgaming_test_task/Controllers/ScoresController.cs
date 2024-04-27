using Microsoft.AspNetCore.Mvc;
using Upgaming_test_task.Services;

namespace Upgaming_test_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        public readonly IScoreService scoreService;
        public ScoresController(IScoreService scoreService)
        {
            this.scoreService = scoreService;
        }

        [HttpGet("GetScoresByDay/{date}")]
        public async Task<IActionResult> GetScoresByDay(DateTime date)
        {
            var result = await scoreService.GetScoresByDay(date);
            return Ok(result);
        }


        [HttpGet("GetScoresByMonth/{month}")]
        public async Task<IActionResult> GetScoresByMonth(DateTime month)
        {
            var result = await scoreService.GetScoresByMonth(month);
            return Ok(result);
        }

        [HttpGet("GetStats")]
        public async Task<IActionResult> GetStats()
        {
            var result = await scoreService.GetStats();
            return Ok(result);
        }

        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            var result = await scoreService.GetAllData();
            return Ok(result);
        }
    }
}
