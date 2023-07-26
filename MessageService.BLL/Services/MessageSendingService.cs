using MessageService.DAL.Repositories.MessageRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageService.BLL.Services
{
    public class MessageSenderService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MessageSenderService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var messageRepository = scope.ServiceProvider.GetRequiredService<IMessageRepository>();

                    var message = "Auto message";
                    var dateCreated = DateTime.Now;

                    SendMessage(messageRepository, message, dateCreated);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }

        private void SendMessage(IMessageRepository messageRepository, string message, DateTime dateCreated)
        {
            messageRepository.SendMessage(message, dateCreated);
        }
    }
}