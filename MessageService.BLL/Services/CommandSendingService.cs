using MediatR;
using MessageService.BLL.SendMessage.Commands;
using MessageService.BLL.Settings;
using MessageService.DAL.Repositories.MessageRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;

namespace MessageService.BLL.Services
{
    public class CommandSendingService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly AutoMessagesSettings autoMessagesSettings;

        public CommandSendingService(IServiceScopeFactory serviceScopeFactory, IOptions<AutoMessagesSettings> autoMessagesSettings)
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
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var messageRepository = scope.ServiceProvider.GetRequiredService<IMessageRepository>();

                    try
                    {
                        var command = new SendMessageCommand() { Message = autoMessagesSettings.CommandMessageText };
                        var result = await mediator.Send(command);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error sending the message: {Message}", ex.Message);
                    }
                }

                await Task.Delay(autoMessagesSettings.SendingTimer, stoppingToken);
            }
        }
    }
}
