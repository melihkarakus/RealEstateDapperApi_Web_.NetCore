using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        // IPopularLocationRepository türünde bir arayüz enjekte edilmiş bir hizmeti temsil eden bir özel alan tanımlanmıştır.
        // Bu özel alan, PopularLocationsController sınıfının tüm yöntemlerinde kullanılabilir.
        private readonly IPopularLocationRepository _locationRepository;

        // PopularLocationsController sınıfının yapıcı metodu, IPopularLocationRepository bağımlılığını enjekte eder.
        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository; // Bağımlılığın enjekte edildiği yer
        }

        // HTTP GET isteği karşılayan ve popüler konumların listesini döndüren bir eylem yöntemi.
        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            // IPopularLocationRepository'den GetAllPopularLocationAsync yöntemi kullanılarak popüler konumların listesi alınır.
            var values = await _locationRepository.GetAllPopularLocationAsync();

            // Dönen veriler, HTTP 200 (Başarılı) yanıtı ile birlikte döndürülür.
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            _locationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Lokasyon Başarı İle Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _locationRepository.DeletePopularLocation(id);
            return Ok("Lokasyon Başarı Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _locationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Lokasyon Başarı Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var values = await _locationRepository.GetPopularLocation(id);
            return Ok(values);
        }
    }
}
