using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class ScorePerDateViewModel
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}
