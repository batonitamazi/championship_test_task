using Microsoft.AspNetCore.Mvc;
using Upgaming_test_task.Repositories;
using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("UploadUserScores")]
        public IActionResult UploadUserScores([FromBody] List<UserScoreViewModel> scores)
        {
            return Ok();
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllusers()
        {
            return Ok(userRepository.GetAllUsers());
        }

        [HttpPost("UploadUserData")]
        public IActionResult UploadUserData([FromBody] List<UserViewModel> usersData)
        {
            return Ok();
        }
        [HttpGet("GetUserInfo/{userId}")]
        public IActionResult GetUserInfo(int userId)
        {
            UserViewModel archasda = new UserViewModel() { Name = "Tazo", Surname = "mirianashvili", UserName = "BatoniTamazi" };
            return Ok(archasda);
        }
    }
}
