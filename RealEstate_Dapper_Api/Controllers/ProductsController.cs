using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // 1. ProductsController sınıfı, ürün işlemlerini gerçekleştirmek için kullanılır ve IProductRepository enjeksiyonu yapar.
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            // 2. Constructor enjeksiyonu ile IProductRepository hizmetini alır ve özel bir alanda saklar.
            _productRepository = productRepository;
        }

        [HttpGet]
        // 3. HTTP GET isteğine yanıt veren bir aksiyon metodu; tüm ürünleri getirir.
        public async Task<IActionResult> ProductList()
        {
            // 4. _productRepository kullanarak tüm ürünleri asenkron olarak alır.
            var values = await _productRepository.GetAllProductAsync();

            // 5. Alınan ürünleri HTTP isteğine yanıt olarak döndürür.
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        // 6. HTTP GET isteğine yanıt veren bir aksiyon metodu; ürünleri kategorilerle birlikte getirir.
        public async Task<IActionResult> ProductListWithCategory()
        {
            // 7. _productRepository kullanarak ürünleri kategorileriyle birlikte asenkron olarak alır.
            var values = await _productRepository.GetAllProductWithCategory();

            // 8. Alınan ürünleri HTTP isteğine yanıt olarak döndürür.
            return Ok(values);
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Durumu Güncellendi");
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Durumnu Güncellendi");
        }
    }
}
