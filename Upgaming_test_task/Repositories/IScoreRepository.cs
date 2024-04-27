using Upgaming_test_task.Models;

namespace Upgaming_test_task.Repositories
{
    public interface IScoreRepository
    {
        Task<List<ScorePerDate>> GetScoresByDay(DateTime date);
        Task<List<ScorePerDate>> GetScoresByMonth(DateTime date);
        Task<List<ScorePerDate>> GetAllData();
        Task<List<UserScore>> GetStats();
    }
}
