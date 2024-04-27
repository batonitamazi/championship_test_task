using Microsoft.AspNetCore.Mvc;
using Upgaming_test_task.NewFolder;
using Upgaming_test_task.Repositories;
using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("UploadUserData")]
        public async Task<IActionResult> UploadUserScores([FromBody] List<UserViewModel> users)
        {
            var result = await userService.UploadUserData(users);
            return Ok(result);
        }
        [HttpPost("UploadUserScores")]
        public async Task<IActionResult> UploadUserScores([FromBody] List<UserScoreViewModel> scores)
        {
            var result = await userService.UploadUserScores(scores);
            return Ok(result);
        }



        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("GetUserInfo/{user_id}")]
        public async Task<IActionResult> GetUserInfo(int user_id)
        {
            if(user_id == 0)
            {
                return NotFound();
            }
            var result = await userService.GetUserInfo(user_id);
            return Ok(result);
        }
    }
}
