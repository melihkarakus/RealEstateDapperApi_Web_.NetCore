using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // 1. ICategoryRepository arayüzünü kullanarak bir kategori veritabanı işlemcisini enjekte eden Controller sınıfı.
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            // 2. Constructor enjeksiyonu ile ICategoryRepository hizmetini alır ve özel alanına atar.
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        // 3. HTTP GET isteğine yanıt veren bir aksiyon metodu.
        public async Task<IActionResult> CategoryList()
        {
            // 4. Kategori verilerini _categoryRepository kullanarak asenkron bir şekilde alır.
            var values = await _categoryRepository.GetAllCategoryAsync();

            // 5. Alınan verileri HTTP isteğine yanıt olarak döndürür.
            return Ok(values);
        }
        // 1. HTTP POST isteğine yanıt veren bir aksiyon metodu; yeni bir kategori oluşturulur.
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            // 2. ICategoryRepository kullanarak yeni kategori oluşturulur.
            _categoryRepository.CreateCategory(createCategoryDto);

            // 3. İşlem başarılı ise HTTP 200 OK yanıtı döndürülür ve bir mesaj eklenir.
            return Ok("Kategori Başarılı Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            // 2. IcategoryRepository kullanarak silincek kategoriyi id şekilde sildi.
            _categoryRepository.DeleteCategory(id);
            // 3. İşlem başarılı ise HTTP 200 Ok yanıtı döndürüldü ve bir mesaj eklendi.
            return Ok("Kategori Başarılı Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            // 2. IcategoryRepository kullanarak günllecenek kategoriyi yazarak güncellendi
            _categoryRepository.UpdateCategory(updateCategoryDto);
            // 3. İşlem başarılı ise HTTP 200 ok yanıtı döndürüldü ve bir mesaj eklendi.
            return Ok("Kategori Başarılı Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDCategory(int id)
        {
            // 2. async kullanıldığı için await dönülmeliIcategoryRepository kullanarak kategoriyi id şeklide tek kimlikle 
            var values = await _categoryRepository.GetCategory(id);
            // 3. İşlem başarı bir şekilde gerçekleştiğinde bize ekranı 200 kodu yansıtarak göstericek
            return Ok(values);
        }
    }
}
