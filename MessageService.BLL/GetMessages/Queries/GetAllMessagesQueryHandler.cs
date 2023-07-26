using AutoMapper;
using MediatR;
using MessageService.BLL.Models;
using MessageService.DAL.Repositories.MessageRepository;

namespace MessageService.BLL.GetMessages.Queries
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<MessageResult>>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public GetAllMessagesQueryHandler(IMapper mapper, IMessageRepository messageRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public async Task<IEnumerable<MessageResult>> Handle(GetAllMessagesQuery query, CancellationToken cancellationToken)
        {
            var result = _messageRepository.GetAllMessages();
            return _mapper.Map<IEnumerable<MessageResult>>(result);
        }
    }
}
