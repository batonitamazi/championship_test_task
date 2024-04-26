using Microsoft.AspNetCore.Identity;
using Upgaming_test_task.Models;
using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsUsernameUnique(string username);
        Task AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task AddUserScore(UserScore userScore);
        Task<bool> CheckUserExist(int id);
    }
}
