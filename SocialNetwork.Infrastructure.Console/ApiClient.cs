using System.Net.Http.Json;
using SocialNetwork.Application.Dtos.Body;
using SocialNetwork.Application.Wrappers;

namespace SocialNetwork.ConsoleApp
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7133/api/v1/");
        }

        public async Task<string> PostMessageAsync(string userName, string message)
        {
            var payload = new PostDto { UserName = userName, Message = message };
            return await SendPostRequestAsync("Post/PostMessage", payload);
        }

        public async Task<string> CreateUserAsync(string userName)
        {
            var payload = new UserDto { UserName = userName };
            return await SendPostRequestAsync("User/Add", payload); 
        }

        public async Task<string> FollowUserAsync(string userNameOfUser, string userNameOfFriend)
        {
            var url = $"Friend/FollowUser?userNameOfUser={userNameOfUser}&userNameOfFriend={userNameOfFriend}";
            return await SendGetRequestAsync(url);
        }

        public async Task<List<string>> GetUserWallAsync(string userName)
        {
            var url = $"Wall/GetUserWall?userName={userName}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Response<List<string>>>();
                if (result?.Succeeded == true)
                {
                    return result.Data ?? new List<string>();
                }
                else
                {
                    return new List<string> { $"{result?.Message}" };
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new List<string> { $"{response.ReasonPhrase} - {errorContent}" };
            }
        }

        private async Task<string> SendPostRequestAsync<T>(string url, T payload)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, payload);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<string>>();
                    return result?.Succeeded == true ? result.Data : $"{result?.Message}";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return $"{response.ReasonPhrase} - {errorContent}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }

        private async Task<string> SendGetRequestAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<string>>();
                    return result?.Succeeded == true ? result.Data : $"{result?.Message}";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return $"{response.ReasonPhrase} - {errorContent}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }
    }
}
