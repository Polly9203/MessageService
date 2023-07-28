using MessageService.BLL;
using MessageService.BLL.Services;
using MessageService.BLL.Settings;
using MessageService.DAL;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.File("C:\\Logs\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMessageServiceBll();
builder.Services.AddMessageServiceDAL(builder.Configuration);

builder.Services.AddHostedService<MessageSenderService>();

builder.Services.Configure<AutoMessagesSettings>(builder.Configuration.GetSection("AutoMessagesSettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
