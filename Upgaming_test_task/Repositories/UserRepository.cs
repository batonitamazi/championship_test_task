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
        public async Task<List<string>> GetUniqueUsernames(List<string> usernames)
        {
            string query = "SELECT LOWER(username) FROM users WHERE LOWER(username) IN @Usernames";
            var users = await _dbConnection.QueryAsync<string>(query, new { Usernames = usernames });
            return users.ToList();
        }
        public async Task AddUsers(List<User> users)
        {
            string query = @"INSERT INTO users (name, surname, username) VALUES (@Name, @Surname, @UserName)";
            await _dbConnection.ExecuteAsync(query, users);
        }

        public async Task<List<int>> CheckUsersExist(List<int> userIds)
        {
            string query = "SELECT id FROM users WHERE id IN @Ids";
            var existingUserIds = await _dbConnection.QueryAsync<int>(query, new { Ids = userIds });
            return existingUserIds.ToList();
        }
        public async Task AddUserScores(List<UserScore> userScores)
        {
            string query = @"INSERT INTO user_scores (user_id, date, score) 
                         VALUES (@UserId, @Date, @Score)";
            await _dbConnection.ExecuteAsync(query, userScores);
        }


    }
}
     