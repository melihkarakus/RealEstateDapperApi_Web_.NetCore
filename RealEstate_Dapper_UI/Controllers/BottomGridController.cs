using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class BottomGridController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BottomGridController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/BottomGrids");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBottomGridDtos>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBottomGrid()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDtos createBottomGridDtos)
        {
            // HTTP isteği göndermek için bir HttpClient örneği oluşturuyoruz.
            var client = _httpClientFactory.CreateClient();

            // createEmployeeDto nesnesini JSON formatına dönüştürüyoruz.
            var jsonData = JsonConvert.SerializeObject(createBottomGridDtos);

            // JSON verisini içeren StringContent öğesi oluşturuyoruz ve içeriği "application/json" olarak ayarlıyoruz.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Belirtilen URL'ye POST isteği gönderiyoruz ve yanıtı bekliyoruz.
            var responseMessage = await client.PostAsync("https://localhost:44338/api/BottomGrids", stringContent);

            // İsteğin başarıyla tamamlandığını kontrol ediyoruz.
            if (responseMessage.IsSuccessStatusCode)
            {
                // Başarı durumunda "Index" eylemine yönlendirme yapıyoruz.
                return RedirectToAction("Index");
            }

            // İsteğin başarısız olduğu durumda sayfayı tekrar görüntülüyoruz.
            return View();
        }

        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44338/api/BottomGrids/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateBottomGrid(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/BottomGrids/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBottomGridDtos>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDtos updateBottomGridDtos)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBottomGridDtos);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/BottomGrids", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
