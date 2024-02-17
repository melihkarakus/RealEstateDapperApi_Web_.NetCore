using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
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

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation(CityName, ImageUrl) values (@cityName, @imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopularLocationDto.CityName);
            parameters.Add("@imageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete from PopularLocation where LocationID = @popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
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

        public async Task<GetByIDPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "Select * from PopularLocation where LocationID = @popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, parameters);
                return values;

            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation Set CityName = @cityName, ImageUrl = @imageUrl where LocationID = @popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopularLocationDto.CityName);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("@popularLocationID", updatePopularLocationDto.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
