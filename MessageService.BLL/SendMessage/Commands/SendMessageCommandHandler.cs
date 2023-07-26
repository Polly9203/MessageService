using AutoMapper;
using MediatR;
using MessageService.BLL.Models;
using MessageService.DAL.Repositories.MessageRepository;

namespace MessageService.BLL.SendMessage.Commands
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, MessageResult>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public SendMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public async Task<MessageResult> Handle(SendMessageCommand command, CancellationToken cancellationToken)
        {
            var result = _messageRepository.SendMessage(command.Message, DateTime.UtcNow);
            return _mapper.Map<MessageResult>(result);
        }
    }
}
