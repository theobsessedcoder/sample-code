using System;
using System.Net.Http;
using Users.Client.Dtos;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Users.Client
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly string _serviceBaseUrl;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserServiceClient(string serviceBaseUrl, IHttpClientFactory httpClientFactory)
        {
            _serviceBaseUrl = serviceBaseUrl;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_serviceBaseUrl}/users/{id}");
            var response = await httpClient.SendAsync(request);
            var responseBodyJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseBodyJson);
        }

        public async Task AddOrUpdateUserAsync(UserDto user)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"{_serviceBaseUrl}/users");
            request.Content = new StringContent(JsonConvert.SerializeObject(user));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.SendAsync(request);

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"An error occurred when creating or updating user {user.Id}.");
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"{_serviceBaseUrl}/users/{id}");

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"An error occurred when creating or deleting user {id}.");
            }
        }
    }
}
