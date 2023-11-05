using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            /* her biri apiye istek gönderip bunları ekrana yansıtması için apiden gelen mesajşarı alır ve uıdaki admin
             * paneline verilerimizi yazar.*/
            #region Aktive Kategori
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activecategoryCount = jsonData;
            #endregion
            #region Aktive Çalışan
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44338/api/Statistics/ActiveEmployeeCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData1;
            #endregion
            #region Daire Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44338/api/Statistics/ApartmentCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonData2;
            #endregion
            #region OrtalamaKiraSayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44338/api/Statistics/AveregeProductPriceByRent");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.AveregeProductPriceByRent = jsonData3.Substring(0, jsonData3.Length - 7);
            #endregion

            #region DüşükKiraSayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client.GetAsync("https://localhost:44338/api/Statistics/AveregeProductPriceBySale");
            var jsonData4 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.AveregeProductPriceBySale = jsonData;
            #endregion
            #region OrtalamaOdaSayısı
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44338/api/Statistics/AverageRoomCount");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.AverageRoomCount = jsonData5;
            #endregion
            #region KategoriSayısı
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44338/api/Statistics/CategoryCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData6;
            #endregion
            #region KategoriMaxsimumSayısı
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44338/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonData7;
            #endregion

            #region EnİyiŞehirAdıSayısı
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44338/api/Statistics/CityNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonData8;
            #endregion
            #region FarklıŞehirSayısı
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44338/api/Statistics/DifferentCityCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData9;
            #endregion
            #region EnÇokİlanVerenÇalışan
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync("https://localhost:44338/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData10;
            #endregion
            #region SonÜrünFiyatı
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync("https://localhost:44338/api/Statistics/LastProductPrice");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData11;
            #endregion

            #region EnYeniİnşaat
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync("https://localhost:44338/api/Statistics/NewestBuildingYear");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsonData12;
            #endregion
            #region EnEskiİnşaat
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync("https://localhost:44338/api/Statistics/OldestBuildingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsonData13;
            #endregion
            #region PasifKategoriSayısı
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync("https://localhost:44338/api/Statistics/PassiveCategoryCount");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonData14;
            #endregion
            #region KategoriSayısı
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:44338/api/Statistics/ProductCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData15;
            #endregion

            return View();
        }
    }
}
