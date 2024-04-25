using Microsoft.AspNetCore.Identity;
using Upgaming_test_task.Models;

namespace Upgaming_test_task.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
    }
}
