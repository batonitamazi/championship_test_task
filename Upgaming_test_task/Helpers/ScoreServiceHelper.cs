using Upgaming_test_task.Models;

namespace Upgaming_test_task.Helpers
{
    public static class ScoreServiceHelper
    {
        public static double AverageDailyScoreCalc(List<UserScore> scores)
        {
            DateTime today = DateTime.Today;
            var scoresByDay = scores.GroupBy(s => s.Date.Date).ToList();
            double averageDaily = scoresByDay.Where(g => g.Key == today).SelectMany(g => g.Select(s => s.Score)).Average();

            return averageDaily;

        }

        public static double AverageMonthlyScore(List<UserScore> scores)
        {
            DateTime today = DateTime.Today;
            DateTime currentMonth = new DateTime(today.Year, today.Month, 1);
            var scoresByMonth = scores.GroupBy(s => new { s.Date.Year, s.Date.Month });

            double averageMonthly = scoresByMonth.Where(g => g.Key.Year == currentMonth.Year && g.Key.Month == currentMonth.Month).SelectMany(g => g.Select(s => s.Score)).Average();
            return averageMonthly;
        }
        public static int MaximumDailyScore(List<UserScore> scores)
        {
            DateTime today = DateTime.Today;
            var scoresByDay = scores.GroupBy(s => s.Date.Date).ToList();
            int maxDaily = scoresByDay.Where(g => g.Key == today).SelectMany(g => g.Select(s => s.Score)).Max();

            return maxDaily;
        }
        public static int MaximumMonthlyScore(List<UserScore> scores)
        {
            DateTime today = DateTime.Today;
            DateTime currentMonth = new DateTime(today.Year, today.Month, 1);
            var scoresByMonth = scores.GroupBy(s => new { s.Date.Year, s.Date.Month });
            int maxMonthly = scoresByMonth.Where(g => g.Key.Year == currentMonth.Year && g.Key.Month == currentMonth.Month).SelectMany(g => g.Select(s => s.Score)).Max();
            return maxMonthly;

        }
    }
}
