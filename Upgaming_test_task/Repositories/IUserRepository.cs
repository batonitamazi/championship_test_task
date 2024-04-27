using Microsoft.AspNetCore.Identity;
using Upgaming_test_task.Models;
using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<List<UserRating>> GetUsersInfo();
        Task<List<string>> GetUniqueUsernames(List<string> usernames);
        Task AddUsers(List<User> users);
        Task<List<int>> CheckUsersExist(List<int> userIds);
        Task AddUserScores(List<UserScore> userScore);

    }
}
