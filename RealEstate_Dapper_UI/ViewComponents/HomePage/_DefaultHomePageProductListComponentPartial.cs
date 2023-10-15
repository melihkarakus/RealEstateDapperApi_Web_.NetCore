using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Constructor, IHttpClientFactory bağımlılığı enjekte edilir.
        public _DefaultHomePageProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // View bileşeni çağrıldığında bu metod çalışır.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // HttpClient nesnesi oluşturulur.
            var client = _httpClientFactory.CreateClient();

            // Belirtilen URL'e HTTP GET isteği gönderilir.
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/ProductListWithCategory");

            // İsteğin başarılı bir şekilde tamamlanıp tamamlanmadığı kontrol edilir.
            if (responseMessage.IsSuccessStatusCode)
            {
                // Sunucudan gelen veri JSON formatından okunur.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON verisi bir listeye dönüştürülür.
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);

                // Elde edilen veriler bir görünüm (View) ile birlikte döndürülür.
                return View(values);
            }

            // İsteğin başarısız olduğu durumda boş bir görünüm döndürülür.
            return View();
        }
    }
}
