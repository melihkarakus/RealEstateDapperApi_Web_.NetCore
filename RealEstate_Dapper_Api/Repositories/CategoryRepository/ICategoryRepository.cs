using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        // Tüm kategorilerin asenkron bir şekilde alınması için metod tanımı.
        void CreateCategory(CreateCategoryDto categoryDto);
        // Kategori eklemek için tanımlanan metod.
        void DeleteCategory(int id);
        // Kategori Silmek için tanımlanan metod
        void UpdateCategory(UpdateCategoryDto categoryDto);
        // Kategori Güncellemek için tanımlanan metod
        Task<GetByIDCategoryDto> GetCategory(int id);
        // Kategori sadece id ile getirilmesi için tanımlanan method
    }
}
