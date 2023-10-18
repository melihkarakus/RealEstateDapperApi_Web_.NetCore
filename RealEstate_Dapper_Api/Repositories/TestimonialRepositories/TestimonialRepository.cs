using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDtos>> GetAllTestimonialAsync()
        {
            string query = "select * from Testimonial";// SQL sorgusu, 'Category' tablosundaki tüm verileri alır.
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDtos>(query);
                // Veritabanından gelen sonuçları ResultCategoryDto türünde nesnelere dönüştürür.
                return values.ToList();// Dönüştürülmüş sonuçları bir liste olarak döndürür.
            }
        }
    }
}
