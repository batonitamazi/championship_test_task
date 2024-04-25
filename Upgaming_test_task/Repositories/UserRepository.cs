using Dapper;
using System.Data;
using Upgaming_test_task.Models;

namespace Upgaming_test_task.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;
        
        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbConnection.Query<User>("SELECT * FROM dbo.users");
        }
    }
}
