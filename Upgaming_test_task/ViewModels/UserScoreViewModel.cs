using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class UserScoreViewModel
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}
