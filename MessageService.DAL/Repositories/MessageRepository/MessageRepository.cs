using MessageService.DAL.Models;

namespace MessageService.DAL.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext _applicationContext;
        public MessageRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public MessageModel SendMessage(string message, DateTime dateCreated)
        {
            var sendingMessage = new MessageModel() { Message = message, Created = dateCreated };
            _applicationContext.Messages.Add(sendingMessage);
            _applicationContext.SaveChanges();

            return sendingMessage;
        }

        public IEnumerable<MessageModel> GetAllMessages()
        {
            return _applicationContext.Messages.ToList();
        }

        public void DeleteAllMessages()
        {
            _applicationContext.RemoveRange(_applicationContext.Messages);
            _applicationContext.SaveChanges();
        }
    }
}
