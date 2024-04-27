using System.Globalization;
using Upgaming_test_task.Models;

namespace Upgaming_test_task.Helpers
{
    public static class ScoreServiceHelper
    {
        public static double AverageDailyScoreCalc(List<UserScore> scores)
        {
            var groupedScores = scores.GroupBy(s => s.Date.Date);
            return groupedScores.Average(g => g.Sum(s => s.Score));
        }

        public static double AverageMonthlyScore(List<UserScore> scores)
        {
            var groupedScores = scores.GroupBy(s => new { s.Date.Year, s.Date.Month });
            return groupedScores.Average(g => g.Sum(s => s.Score));
        }
        public static int MaximumDailyScore(List<UserScore> scores)
        {
            return scores.Max(s => s.Score);

        }
        public static int MaximumWeeklyScore(List<UserScore> scoresList)
        {
            var groupedScores = scoresList.GroupBy(s => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(s.Date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday));
            return groupedScores.Max(g => g.Sum(s => s.Score));
        }
        public static int MaximumMonthlyScore(List<UserScore> scores)
        {
            var groupedScoresByMonth = scores.GroupBy(s => new { s.Date.Year, s.Date.Month });
            return groupedScoresByMonth.Max(g => g.Sum(s => s.Score));

        }
    }
}
