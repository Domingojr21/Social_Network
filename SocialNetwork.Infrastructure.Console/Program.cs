using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .AddSingleton<ApiClient>()
                .AddSingleton<CommandManager>()
                .BuildServiceProvider();

            var commandManager = serviceProvider.GetService<CommandManager>();

            while (true)
            {
                Console.WriteLine("Enter command:");
                var command = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(command)) break;
                await commandManager.ExecuteCommandAsync(command);
            }
        }
    }
}
