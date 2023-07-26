using MessageService.DAL.Models;

namespace MessageService.DAL.Repositories.MessageRepository
{
    public interface IMessageRepository
    {
        MessageModel SendMessage(string message, DateTime dateCreated);
        IEnumerable<MessageModel> GetAllMessages();
        void DeleteAllMessages();
    }
}
