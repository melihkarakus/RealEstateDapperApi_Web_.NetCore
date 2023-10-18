using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            // 1. HTTP istemcisi oluştur
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();

            // 2. Belirtilen URL'ye HTTP GET isteği gönder
            var responseMessage = await client.GetAsync("https://localhost:44338/api/WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync("https://localhost:44338/api/Services");

            // 3. İstek başarılı bir şekilde tamamlandı mı kontrol et
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                // 4. HTTP yanıt içeriğini bir dizeye çevir
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                // 5. JSON veriyi C# nesnelerine dönüştür
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDtos>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServicesDtos>>(jsonData2);

                // 6. JSON nesnelerinden "Title" özelliğini seç ve ViewBag.Title'a ata
                ViewBag.Title = value.Select(x => x.Title).FirstOrDefault();

                // 7. Aynı şekilde "SubTitle", "Description1" ve "Description2" özelliklerini seç ve ViewBag'e ata
                ViewBag.SubTitle = value.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.Description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = value.Select(x => x.Description2).FirstOrDefault();

                // 8. Sonuç görünümünü döndür
                return View(value2);
            }

            // 9. Eğer istek başarısızsa veya herhangi bir hata oluşursa, yine sonuç görünümünü döndür
            return View();
        }
    }
}
