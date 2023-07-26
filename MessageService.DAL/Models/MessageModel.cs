namespace MessageService.DAL.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
