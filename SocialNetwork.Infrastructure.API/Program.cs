
using SocialNetwork.Application;
using SocialNetwork.Domain.Interfaces.Repositories;
using SocialNetwork.Infrastructure.API.Extensions;
using SocialNetwork.Infrastructure.InMemory;
using SocialNetwork.Infrastructure.InMemory.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInMemoryLayer();
builder.Services.AddApplicationLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var friendRepository = services.GetRequiredService<IFriendRepository>();
        var userRepository = services.GetRequiredService<IUserRepository>();
        var postRepository = services.GetRequiredService<IPostRepository>();

        UsersSeed.CreateDefaultUsers(userRepository);
        FriendsSeed.CreateDefaultFriends(userRepository, friendRepository);
        PostsSeed.CreateDefaultPosts(userRepository, postRepository);
       
    }
    catch (Exception ex)
    {

    }
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseSwaggerExtension();
app.MapControllers();

app.Run();
