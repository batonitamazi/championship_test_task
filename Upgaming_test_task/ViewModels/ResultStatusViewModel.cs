using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class ResultStatusViewModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("added")]
        public bool Added { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}

