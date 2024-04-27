using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class ResultModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("added")]
        public bool Added { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}

