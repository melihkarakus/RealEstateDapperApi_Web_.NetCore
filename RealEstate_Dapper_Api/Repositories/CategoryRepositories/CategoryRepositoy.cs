using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public class CategoryRepositoy : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepositoy(Context context)
        {
            _context = context; // Bağlam (context) nesnesini alarak CategoryRepositoy sınıfını başlatır.
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "select * from Category"; // SQL sorgusu, 'Category' tablosundaki tüm verileri alır.
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                // Veritabanından gelen sonuçları ResultCategoryDto türünde nesnelere dönüştürür.
                return values.ToList(); // Dönüştürülmüş sonuçları bir liste olarak döndürür.
            }
        }
    }
}
