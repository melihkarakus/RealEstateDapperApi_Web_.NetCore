using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "select * from Product"; // SQL sorgusu, 'Product' tablosundaki tüm verileri alır.
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                // Veritabanından gelen sonuçları ResultProductDto türünde nesnelere dönüştürür.
                return values.ToList(); // Dönüştürülmüş sonuçları bir liste olarak döndürür.
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory()
        {
            // SQL sorgusu, 'Product' tablosundaki tüm verileri alır ve ilgili kategori adını ekler.
            string query = "SELECT ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address, DealOfTheDay FROM Product INNER JOIN Category ON Product.ProductCategory = Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                // Veritabanından gelen sonuçları ResultProductDto türünde nesnelere dönüştürür.
                return values.ToList(); // Dönüştürülmüş sonuçları bir liste olarak döndürür.
            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay = 0 where ProductID = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay = 1 where ProductID = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
