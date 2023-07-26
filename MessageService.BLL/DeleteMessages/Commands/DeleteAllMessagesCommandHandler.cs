using MediatR;
using MessageService.DAL.Repositories.MessageRepository;

namespace MessageService.BLL.DeleteMessages.Commands
{
    public class DeleteAllMessagesCommandHandler : IRequestHandler<DeleteAllMessagesCommand, Unit>
    {
        private readonly IMessageRepository _messageRepository;

        public DeleteAllMessagesCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public async Task<Unit> Handle(DeleteAllMessagesCommand command, CancellationToken cancellationToken)
        {
            _messageRepository.DeleteAllMessages();
            return Unit.Value;
        }
    }
}
