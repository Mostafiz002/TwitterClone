using Scalar.AspNetCore;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register
//user
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//tweet
builder.Services.AddSingleton<ITweetRepository, TweetRepository>();
builder.Services.AddScoped<ITweetService, TweetService>();
//retweet
builder.Services.AddScoped<IRetweetService, RetweetService>();
builder.Services.AddSingleton<IRetweetRepository, RetweetRepository>();
//notification
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddSingleton<INotificationRepository, NotificationRepository>();
//message
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddSingleton<IMessageRepository, MessageRepository>();
//like
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddSingleton<ILikeRepository, LikeRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();