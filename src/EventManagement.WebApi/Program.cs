using EventManagement.DataAccess.Interfaces.Events;
using EventManagement.DataAccess.Repositories.Events;
using EventManagement.Service.Interfaces.Common;
using EventManagement.Service.Interfaces.Events;
using EventManagement.Service.Services.Common;
using EventManagement.Service.Services.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IEventService, EventService>();

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