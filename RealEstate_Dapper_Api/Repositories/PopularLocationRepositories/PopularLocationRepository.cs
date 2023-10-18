using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            // SQL sorgusu. "PopularLocation" tablosundan tüm verileri seçer.
            string query = "select * from PopularLocation";

            // Entity Framework veya Dapper gibi bir ORM (Object-Relational Mapping) kullanıyorsanız, 
            // bağlantı oluşturmak için bu API'nin özelliklerini kullanmanız gerekebilir.
            // Aşağıdaki kod, bir bağlantı oluşturur ve bu bağlantıyı kullanarak veritabanından verileri çeker.

            // Veritabanı bağlantısının oluşturulması ve yönetilmesi için bir bağlantı nesnesi oluşturulur.
            using (var connection = _context.CreateConnection())
            {
                // SQL sorgusunu veritabanına gönderir ve sonuçları ResultPopularLocationDto türündeki nesnelere dönüştürür.
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);

                // Sonuçları bir liste halinde döndürür.
                return values.ToList();
            }
        }
    }
}
