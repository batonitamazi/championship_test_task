using System.Text.Json.Serialization;

namespace Upgaming_test_task.ViewModels
{
    public class UserViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
