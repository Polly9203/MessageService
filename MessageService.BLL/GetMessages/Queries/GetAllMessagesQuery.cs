using MediatR;
using MessageService.BLL.Models;

namespace MessageService.BLL.GetMessages.Queries
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<MessageResult>>
    {
    }
}
