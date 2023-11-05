using Dapper;
using Microsoft.VisualBasic;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createServiceDto)
        {
            string query = "insert into Services (ServiceName, ServiceStatus) values (@serviceName, @serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createServiceDto.ServiceName);
            parameters.Add("@serviceStatus", createServiceDto.ServiceStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "Delete from Services where ServiceID = @serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            // 1. SQL sorgusunu oluştur
            string query = "select * from Services"; // SQL sorgusu, "Service" tablosundaki tüm verileri çekmek için tasarlanmıştır.

            // 2. SQL bağlantısı oluştur
            using (var connection = _context.CreateConnection())
            {
                // 3. SQL sorgusunu veritabanına gönder ve sonuçları al
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                // Bu adımda, SQL sorgusu "Service" tablosunu sorgular ve sonuçları "ResultServiceDto" türünde nesnelere dönüştürür.

                // 4. Sonuçları bir liste haline getir ve döndür
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = "select * from Services where ServiceID = @serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto)
        {
            string query = "Update Services Set ServiceName = @serviceName, ServiceStatus = @serviceStatus Where ServiceID = @serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", updateServiceDto.ServiceName);
            parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
            parameters.Add("@serviceID", updateServiceDto.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
