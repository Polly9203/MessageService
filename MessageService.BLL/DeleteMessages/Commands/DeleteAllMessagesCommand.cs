using MediatR;

namespace MessageService.BLL.DeleteMessages.Commands
{
    public class DeleteAllMessagesCommand : IRequest<Unit>
    {
    }
}
