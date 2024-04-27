using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class UserRatingViewModel
    {
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }  
        
    }
}
