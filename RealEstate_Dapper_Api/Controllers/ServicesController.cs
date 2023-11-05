using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            // 2. ICategoryRepository kullanarak yeni kategori oluşturulur.
            _serviceRepository.CreateService(createServiceDto);

            // 3. İşlem başarılı ise HTTP 200 OK yanıtı döndürülür ve bir mesaj eklenir.
            return Ok("Hakkımızda Kısmı Başarılı Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            // 2. IcategoryRepository kullanarak silincek kategoriyi id şekilde sildi.
            _serviceRepository.DeleteService(id);
            // 3. İşlem başarılı ise HTTP 200 Ok yanıtı döndürüldü ve bir mesaj eklendi.
            return Ok("Hakkımızda Kısmı Başarılı Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            // 2. IcategoryRepository kullanarak günllecenek kategoriyi yazarak güncellendi
            _serviceRepository.UpdateService(updateServiceDto);
            // 3. İşlem başarılı ise HTTP 200 ok yanıtı döndürüldü ve bir mesaj eklendi.
            return Ok("Hakkımızda Kısmı Başarılı Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            // 2. async kullanıldığı için await dönülmeliIcategoryRepository kullanarak kategoriyi id şeklide tek kimlikle 
            var values = await _serviceRepository.GetService(id);
            // 3. İşlem başarı bir şekilde gerçekleştiğinde bize ekranı 200 kodu yansıtarak göstericek
            return Ok(values);
        }
    }
}
