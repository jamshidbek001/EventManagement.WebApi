using EventManagement.DataAccess.Interfaces.EventRegistrations;
using EventManagement.DataAccess.Interfaces.Events;
using EventManagement.DataAccess.Interfaces.EventTickets;
using EventManagement.DataAccess.Repositories.EventRegistrations;
using EventManagement.DataAccess.Repositories.Events;
using EventManagement.DataAccess.Repositories.EventTickets;
using EventManagement.Service.Interfaces.Common;
using EventManagement.Service.Interfaces.EvenTickets;
using EventManagement.Service.Interfaces.EventRegistrations;
using EventManagement.Service.Interfaces.Events;
using EventManagement.Service.Services.Common;
using EventManagement.Service.Services.EventRegistrations;
using EventManagement.Service.Services.Events;
using EventManagement.Service.Services.EventTickets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventTicketRepository,EventTicketRepository>();
builder.Services.AddScoped<IEventRegistrationRepository, EventRegistrationRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventTicketService,EventTicketService>();
builder.Services.AddScoped<IEventRegistrationService, EventRegistrationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();