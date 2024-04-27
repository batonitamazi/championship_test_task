using Upgaming_test_task.Helpers;
using Upgaming_test_task.Models;
using Upgaming_test_task.Repositories;
using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.Services
{
    public class ScoreService : IScoreService
    {
        public readonly IScoreRepository scoreRepository;
        public ScoreService(IScoreRepository scoreRepository)
        {
            this.scoreRepository = scoreRepository;
        }
        public async Task<List<ScorePerDateViewModel>> GetScoresByDay(DateTime date)
        {
            var scoresList = await scoreRepository.GetScoresByDay(date);
            var result = scoresList.Select(k => new ScorePerDateViewModel { Score = k.Score, UserId = k.UserId, UserName = k.UserName }).ToList();
            return result;
        }
        public async Task<List<ScorePerDateViewModel>> GetScoresByMonth(DateTime date)
        {
            var scoresList = await scoreRepository.GetScoresByMonth(date);
            var result = scoresList.Select(k => new ScorePerDateViewModel { Score = k.Score, UserId = k.UserId, UserName = k.UserName }).ToList();
            return result;
        }
        public async Task<List<ScorePerDateViewModel>> GetAllData()
        {
            var scoresList = await scoreRepository.GetAllData();
            var result = scoresList.Select(k => new ScorePerDateViewModel { Score = k.Score, UserId = k.UserId, UserName = k.UserName }).ToList();
            return result;
        }
        public async Task<StatsViewModel> GetStats()
        {
            List<UserScore> scoresList = await scoreRepository.GetStats();

            if(scoresList.Count > 0)
            {
                var result = new StatsViewModel
                {
                    AverageDailyScore = ScoreServiceHelper.AverageDailyScoreCalc(scoresList),
                    AverageMonthlyScore = ScoreServiceHelper.AverageMonthlyScore(scoresList),
                    MaximumDailyScore = ScoreServiceHelper.MaximumDailyScore(scoresList),
                    MaximumMonthlyScore = ScoreServiceHelper.MaximumMonthlyScore(scoresList),
                    MaximumWeeklyScore = ScoreServiceHelper.MaximumWeeklyScore(scoresList),
                };
                return result;
            }
            return new StatsViewModel{ };
        }
    }
}
