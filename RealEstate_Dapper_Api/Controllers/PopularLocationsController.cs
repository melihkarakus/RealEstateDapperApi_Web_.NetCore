using Microsoft.AspNetCore.Mvc;
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
    }
}
