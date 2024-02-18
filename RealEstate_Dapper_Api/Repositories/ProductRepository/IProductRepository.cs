using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        // Tüm Product asenkron bir şekilde alınması için metod tanımı.
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory();
        // Kategorileriyle beraber getirilen async metot.

        void ProductDealOfTheDayStatusChangeToTrue(int id); // Günün Fırsatını aktif etmek için
        void ProductDealOfTheDayStatusChangeToFalse(int id); // Günün Fırsatını pasif etmek için
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
    }
}
