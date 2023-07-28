using MessageService.BLL.Settings;
using MessageService.DAL.Repositories.MessageRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;

namespace MessageService.BLL.Services
{
    public class MessageSenderService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly AutoMessagesSettings autoMessagesSettings;

        public MessageSenderService(IServiceScopeFactory serviceScopeFactory, IOptions<AutoMessagesSettings> autoMessagesSettings)
        {
            _serviceScopeFactory = serviceScopeFactory;
            this.autoMessagesSettings = autoMessagesSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var messageRepository = scope.ServiceProvider.GetRequiredService<IMessageRepository>();
                    var dateCreated = DateTime.Now;

                    try
                    {
                        SendMessage(messageRepository, autoMessagesSettings.MessageText, dateCreated);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error sending the message: {Message}", ex.Message);
                    }
                }

                await Task.Delay(autoMessagesSettings.SendingTimer, stoppingToken);
            }
        }

        private void SendMessage(IMessageRepository messageRepository, string message, DateTime dateCreated)
        {
            messageRepository.SendMessage(message, dateCreated);
        }
    }
}