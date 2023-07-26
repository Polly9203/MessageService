using MediatR;
using MessageService.BLL.Models;
using System.Text.Json.Serialization;

namespace MessageService.BLL.SendMessage.Commands
{
    public class SendMessageCommand : IRequest<MessageResult>
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
