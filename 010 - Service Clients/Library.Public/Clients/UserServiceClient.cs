using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Library.Public.ViewModels;

namespace Library.Public.Clients
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly string _serviceBaseUrl;
        private readonly IHttpClientFactory _httpClientFactory;

        //Injecting a factory, rather than an http client per https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2
        public UserServiceClient(string serviceBaseUrl, IHttpClientFactory httpClientFactory)
        {
            _serviceBaseUrl = serviceBaseUrl;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserViewModel> GetUserAsync(Guid id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_serviceBaseUrl}/users/{id}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return await response.Content.ReadAsAsync<UserViewModel>().ConfigureAwait(false);
        }
    }
}
