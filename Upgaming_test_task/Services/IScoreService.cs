using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.Services
{
    public interface IScoreService
    {
        Task<List<ScorePerDateViewModel>> GetScoresByDay(DateTime date);
        Task<List<ScorePerDateViewModel>> GetScoresByMonth(DateTime date);
        Task<List<ScorePerDateViewModel>> GetAllData();
        Task<StatsViewModel> GetStats();
    }
}
