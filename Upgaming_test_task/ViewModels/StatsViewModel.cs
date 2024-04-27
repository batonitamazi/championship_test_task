using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class StatsViewModel
    {
        [JsonPropertyName("average_daily_score")]
        public double AverageDailyScore { get; set; }

        [JsonPropertyName("average_monthly_score")]
        public double AverageMonthlyScore { get; set; }

        [JsonPropertyName("maximum_daily_score")]
        public int MaximumDailyScore { get; set; }

        [JsonPropertyName("maximum_weekly_score")]
        public int MaximumWeeklyScore { get; set; }

        [JsonPropertyName("maximum_monthly_score")]
        public int MaximumMonthlyScore { get; set; }
    }
}
