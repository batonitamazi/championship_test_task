using Dapper;
using System.Data;
using Upgaming_test_task.Models;

namespace Upgaming_test_task.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly IDbConnection _dbConnection;

        public ScoreRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<List<ScorePerDate>> GetScoresByDay(DateTime date)
        {
            string query = @"SELECT u.id AS UserId, u.username AS UserName, SUM(us.score) AS Score
                FROM users u
                INNER JOIN user_scores us ON u.id = us.user_id
                WHERE CONVERT(date, us.date) = @Date
                GROUP BY u.id, u.username
                ORDER BY SUM(us.score) DESC;";
            var result = await _dbConnection.QueryAsync<ScorePerDate>(query, new { Date = date });
            var resultList = result.ToList();
            return resultList;

        }
        public async Task<List<ScorePerDate>> GetScoresByMonth(DateTime date)
        {
            string query = @"SELECT u.id AS UserId, u.username AS UserName, SUM(us.score) AS Score
                FROM users u
                INNER JOIN user_scores us ON u.id = us.user_id
                WHERE YEAR(us.date) = @Year AND MONTH(us.date) = @Month
                GROUP BY u.id, u.username
                ORDER BY SUM(us.score) DESC;";

            var parameters = new { Year = date.Year, Month = date.Month };
            var result = await _dbConnection.QueryAsync<ScorePerDate>(query, parameters);
            return result.ToList();
        }
        public async Task<List<ScorePerDate>> GetAllData()
        {
            string query = @"SELECT u.id AS UserId, u.username AS UserName, us.score AS Score
                FROM users u
                INNER JOIN user_scores us ON u.id = us.user_id;";

            var result = await _dbConnection.QueryAsync<ScorePerDate>(query);
            return result.ToList();
        }
        public async Task<List<UserScore>> GetStats()
        {
            string query = @"SELECT score, date FROM user_scores";
            var result = await _dbConnection.QueryAsync<UserScore>(query);
            return result.ToList();
        }
    }
}
