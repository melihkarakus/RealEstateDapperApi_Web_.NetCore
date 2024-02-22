using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Statistics/CategoryCount");
            var value = await responseMessage.Content.ReadAsStringAsync();

            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
