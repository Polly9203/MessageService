using System.Text.Json.Serialization;

namespace MessageService.BLL.Models
{
    public class MessageResult
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
    }
}
