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

        public async Task<bool> IsUsernameUnique(string username)
        {
            string query = "SELECT COUNT(*) FROM users WHERE username = @Username";

            int count = await _dbConnection.ExecuteScalarAsync<int>(query, new { Username = username });

            return count == 0;
        }
        public async Task AddUser(User user)
        {
            string query = @"INSERT INTO users (name, surname, username) 
                         VALUES (@Name, @Surname, @UserName)";

            await _dbConnection.ExecuteAsync(query, user);
        }
        //this is a test function 
        public async Task<List<User>> GetAllUsers()
        {
            var rows = await _dbConnection.QueryAsync<User>("SELECT * FROM dbo.users");
            var usersList = rows.ToList();
            return usersList;
        }
        public async Task AddUserScore(UserScore userScore)
        {
            string query = @"INSERT INTO user_scores (user_id, date, score) 
                         VALUES (@UserId, @Date, @Score)";
            await _dbConnection.ExecuteAsync(query, userScore);
        }
        public async Task<bool> CheckUserExist(int userId)
        {
            string query = "SELECT COUNT(*) FROM users WHERE id = @UserId";
            int count = await _dbConnection.ExecuteScalarAsync<int>(query, new { UserId = userId });
            return count > 0;
        }
        public async Task<List<UserRating>> GetUsersInfo()
        {
            var sql = @"
                SELECT
                    u.username AS UserName,
                    u.id AS UserId,
                    SUM(CASE WHEN MONTH(us.date) = MONTH(GETDATE()) AND YEAR(us.date) = YEAR(GETDATE()) THEN us.score ELSE 0 END) AS Score
                FROM users u
                INNER JOIN user_scores us ON u.id = us.user_id
                GROUP BY u.id, u.username;";
            var usersInfo = await _dbConnection.QueryAsync<UserRating>(sql);
            return usersInfo.ToList();
        }
    }
}
     