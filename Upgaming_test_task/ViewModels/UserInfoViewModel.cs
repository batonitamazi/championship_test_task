using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class UserInfoViewModel
    {
        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("scores")]
        public int Scores { get; set; }
    }
}
