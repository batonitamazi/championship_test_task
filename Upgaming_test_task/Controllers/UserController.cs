using Microsoft.AspNetCore.Mvc;
using Upgaming_test_task.Models;
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
            if(users.Count  <1 )
            {
                return NotFound("users list is empty");   
            }
            var result = await userService.UploadUserData(users);
            return Ok(result);
        }

        [HttpPost("UploadUserScores")]
        public async Task<IActionResult> UploadUserScores([FromBody] List<UserScoreViewModel> scores)
        {
            if (scores.Count < 1)
            {
                return NotFound("scores list is empty");
            }
            var result = await userService.UploadUserScores(scores);
            return Ok(result);
        }



        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            if(users.Count <1)
            {
                return NotFound("Users not exist");
            }
            return Ok(users);
        }

        [HttpGet("GetUserInfo/{user_id}")]
        public async Task<IActionResult> GetUserInfo(int user_id)
        {
            
            var result = await userService.GetUserInfo(user_id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
