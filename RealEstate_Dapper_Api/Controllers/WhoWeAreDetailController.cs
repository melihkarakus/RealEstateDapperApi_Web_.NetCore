using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepostiory;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        // 1. ICategoryRepository arayüzünü kullanarak bir kategori veritabanı işlemcisini enjekte eden Controller sınıfı.
        private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

        public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
        {
            _whoWeAreDetailRepository = whoWeAreDetailRepository;
        }

        [HttpGet]
        // 3. HTTP GET isteğine yanıt veren bir aksiyon metodu.
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            // 4. Kategori verilerini _categoryRepository kullanarak asenkron bir şekilde alır.
            var values = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();

            // 5. Alınan verileri HTTP isteğine yanıt olarak döndürür.
            return Ok(values);
        }
        // 1. HTTP POST isteğine yanıt veren bir aksiyon metodu; yeni bir kategori oluşturulur.
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            // 2. ICategoryRepository kullanarak yeni kategori oluşturulur.
            _whoWeAreDetailRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);

            // 3. İşlem başarılı ise HTTP 200 OK yanıtı döndürülür ve bir mesaj eklenir.
            return Ok("Hakkımızda Kısmı Başarılı Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            // 2. IcategoryRepository kullanarak silincek kategoriyi id şekilde sildi.
            _whoWeAreDetailRepository.DeleteWhoWeAreDetail(id);
            // 3. İşlem başarılı ise HTTP 200 Ok yanıtı döndürüldü ve bir mesaj eklendi.
            return Ok("Hakkımızda Kısmı Başarılı Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            // 2. IcategoryRepository kullanarak günllecenek kategoriyi yazarak güncellendi
            _whoWeAreDetailRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            // 3. İşlem başarılı ise HTTP 200 ok yanıtı döndürüldü ve bir mesaj eklendi.
            return Ok("Hakkımızda Kısmı Başarılı Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            // 2. async kullanıldığı için await dönülmeliIcategoryRepository kullanarak kategoriyi id şeklide tek kimlikle 
            var values = await _whoWeAreDetailRepository.GetWhoWeAreDetail(id);
            // 3. İşlem başarı bir şekilde gerçekleştiğinde bize ekranı 200 kodu yansıtarak göstericek
            return Ok(values);
        }
    }

}
