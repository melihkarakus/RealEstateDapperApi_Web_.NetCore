using Dapper;
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

        public void CreateService(CreateServiceDto createServiceDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
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

        public Task<GetByIDServiceDto> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateService(UpdateServiceDto updateServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}
