
using SocialNetwork.Application.Enums;

namespace SocialNetwork.ConsoleApp
{
    public class CommandManager
    {
        private readonly ApiClient _apiClient;

        public CommandManager(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task ExecuteCommandAsync(string command)
        {
            var parts = command.Split(' ', 3);
            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid command.");
                return;
            }

            var actionString = parts[0].ToLower();
            var userPart = parts[1];

            if (!Enum.TryParse<Commands>(actionString, true, out var action))
            {
                Console.WriteLine("Unknown command.");
                return;
            }

            switch (action)
            {
                case Commands.post:
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Invalid post command. Usage: post @user message");
                        return;
                    }
                    var message = parts[2];
                    Console.WriteLine(await _apiClient.PostMessageAsync(userPart.Replace("@", ""), message));
                    break;

                case Commands.follow:
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Invalid follow command. Usage: follow @user @friend");
                        return;
                    }
                    var friendName = parts[2];
                    Console.WriteLine(await _apiClient.FollowUserAsync(userPart.Replace("@", ""), friendName.Replace("@", "")));
                    break;

                case Commands.wall:
                    var wall = await _apiClient.GetUserWallAsync(userPart.Replace("@", ""));
                    Console.WriteLine($"> dashboard {userPart}");
                    foreach (var post in wall)
                    {
                        Console.WriteLine(post);
                    }
                    break;

                case Commands.create:

                    if (parts.Length < 2)
                    {
                        Console.WriteLine("Invalid create command. Usage: create @user");
                        return;
                    }
                    var newUser = parts[1];
                    Console.WriteLine(await _apiClient.CreateUserAsync(newUser.Replace("@", "")));
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
