using EventManagement.DataAccess.Interfaces.Comments;
using EventManagement.DataAccess.Interfaces.EventRegistrations;
using EventManagement.DataAccess.Interfaces.Events;
using EventManagement.DataAccess.Interfaces.EventTickets;
using EventManagement.DataAccess.Interfaces.Notifications;
using EventManagement.DataAccess.Interfaces.Users;
using EventManagement.DataAccess.Repositories.Comments;
using EventManagement.DataAccess.Repositories.EventRegistrations;
using EventManagement.DataAccess.Repositories.Events;
using EventManagement.DataAccess.Repositories.EventTickets;
using EventManagement.DataAccess.Repositories.Notifications;
using EventManagement.DataAccess.Repositories.Users;
using EventManagement.Service.Interfaces.Auth;
using EventManagement.Service.Interfaces.Comments;
using EventManagement.Service.Interfaces.Common;
using EventManagement.Service.Interfaces.EvenTickets;
using EventManagement.Service.Interfaces.EventRegistrations;
using EventManagement.Service.Interfaces.Events;
using EventManagement.Service.Interfaces.Notifications;
using EventManagement.Service.Services.Auth;
using EventManagement.Service.Services.Comments;
using EventManagement.Service.Services.Common;
using EventManagement.Service.Services.EventRegistrations;
using EventManagement.Service.Services.Events;
using EventManagement.Service.Services.EventTickets;
using EventManagement.Service.Services.Notifications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventTicketRepository, EventTicketRepository>();
builder.Services.AddScoped<IEventRegistrationRepository, EventRegistrationRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventTicketService, EventTicketService>();
builder.Services.AddScoped<IEventRegistrationService, EventRegistrationService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<IMailSender, MailSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();