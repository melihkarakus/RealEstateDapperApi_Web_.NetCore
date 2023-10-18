using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDto;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            // 1. IHttpClientFactory'nin bir örneği oluşturuluyor.
            var client = _httpClientFactory.CreateClient();

            // 2. Belirtilen URL'ye GET isteği yapılıyor.
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Categories");

            // 3. Sunucudan başarılı bir yanıt alındığında devam ediliyor.
            if (responseMessage.IsSuccessStatusCode)
            {
                // 4. Sunucudan gelen yanıtın içeriği JSON veri olarak okunuyor.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // 5. JSON veri, bir List<ResultCategoryDto> türüne çözümleniyor.
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                // 6. Çözümlenen veriler View'e gönderiliyor ve sayfa görüntüleniyor.
                return View(values);
            }

            // 7. Eğer sunucudan başarısız bir yanıt alındıysa, boş bir sayfa görüntüleniyor.
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        // HTTP POST isteği ile yeni bir kategori oluşturuluyor.
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            // HTTP istemcisini oluştur
            var client = _httpClientFactory.CreateClient();

            // createCategoryDto nesnesini JSON formatına dönüştür
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);

            // JSON verisini içeren StringContent nesnesi oluştur
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // API'ye POST isteği gönder
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Categories", stringContent);

            // Eğer istek başarılıysa, kullanıcıyı "Index" eylemine yönlendir
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // İstek başarısızsa aynı görünümü tekrar göster
            return View();
        }
        // HTTP GET isteği ile bir kategori siliniyor.
        public async Task<IActionResult> DeleteCategory(int id)
        {
            // HTTP istemcisini oluştur
            var client = _httpClientFactory.CreateClient();

            // Belirli bir kategoriyi silmek için API'ye DELETE isteği gönder
            var responseMessage = await client.DeleteAsync($"https://localhost:44338/api/Categories/{id}");

            // Eğer istek başarılıysa, kullanıcıyı "Index" eylemine yönlendir
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // İstek başarısızsa aynı görünümü tekrar göster
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            // HTTP istemcisini oluştur
            var client = _httpClientFactory.CreateClient();

            // Belirli bir kategoriye ait bilgileri almak için API'ye GET isteği gönder
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Categories/{id}");

            // Eğer istek başarılıysa, API'den gelen JSON veriyi al, çözümle ve düzenleme için kullanılacak görünümü göster
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }

            // İstek başarısızsa aynı görünümü tekrar göster
            return View();
        }
        // HTTP POST isteği ile bir kategori güncelleniyor.
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            // HTTP istemcisini oluştur
            var client = _httpClientFactory.CreateClient();

            // updateCategoryDto nesnesini JSON formatına dönüştür
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);

            // JSON verisini içeren StringContent nesnesi oluştur
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // API'ye PUT isteği gönder
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Categories", stringContent);

            // Eğer istek başarılıysa, kullanıcıyı "Index" eylemine yönlendir
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // İstek başarısızsa aynı görünümü tekrar göster
            return View();
        }
    }
}
