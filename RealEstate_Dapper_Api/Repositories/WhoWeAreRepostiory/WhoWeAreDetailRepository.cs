using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepostiory
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            // 1. SQL sorgusu, WhoWeAreDetail tablosuna yeni bir kategori eklemek için kullanılır.
            string query = "INSERT INTO WhoWeAreDetail (Title, SubTitle, Description1, Description2) VALUES (@title, @subtitle, @description1, @description2)";

            var parameters = new DynamicParameters(); // 2. SQL sorgusu için kullanılacak parametreler tanımlanır.

            // 3. Parametreler eklenir:
            parameters.Add("@title", createWhoWeAreDetailDto.Title); // Kategori başlığı
            parameters.Add("@subtitle", createWhoWeAreDetailDto.SubTitle); // Kategori alt başlığı
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1); // İlk açıklama
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2); // İkinci açıklama

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı oluşturulur
            {
                // 5. Asenkron olarak SQL sorgusu çalıştırılır ve yeni kategori eklenir.
                await connection.ExecuteAsync(query, parameters);
            }   
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            // 2. SQL sorgusu, WhoWeAreDetail tablosundan bir kategori silmek için kullanılır.
            string query = "DELETE FROM WhoWeAreDetail WHERE WhoWeAreDetailID = @whowearedetailID";

            var parameters = new DynamicParameters(); // 3. SQL sorgusu için kullanılacak parametreler tanımlanır.
            parameters.Add("@whowearedetailID", id); // Silinecek kategori ID'si

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı oluşturulur.
            {
                // 5. Asenkron olarak SQL sorgusu çalıştırılır ve belirtilen kategori silinir.
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "SELECT * FROM WhoWeAreDetail"; // SQL sorgusu, 'WhoWeAreDetail' tablosundaki tüm verileri alır.

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                // Veritabanından gelen sonuçları ResultWhoWeAreDetailDto türünde nesnelere dönüştürür.

                return values.ToList(); // Dönüştürülmüş sonuçları bir liste olarak döndürür.
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            // 2. SQL sorgusu, WhoWeAreDetail tablosundan sadece belirli bir kimlikle eşleşen kategoriyi getirir.
            string query = "SELECT * FROM WhoWeAreDetail WHERE WhoWeAreDetailID = @whowearedetailID";

            var parameters = new DynamicParameters(); // 3. SQL sorgusu için kullanılacak parametreler tanımlanır.
            parameters.Add("@whowearedetailID", id); // Kategori kimliği (ID) parametresi

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı oluşturulur.
            {
                // 5. Asenkron olarak SQL sorgusu çalıştırılır ve verilen kategori kimliği ile eşleşen kategoriyi alır.
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            // 1. SQL sorgusu, "WhoWeAreDetail" tablosundaki bir satırın güncellenmesi için kullanılan SQL sorgusu.
            string query = "UPDATE WhoWeAreDetail SET Title = @title, SubTitle = @subtitle, Description1 = @description1, Description2 = @description2 WHERE WhoWeAreDetailID = @whowearedetailID";

            var parameters = new DynamicParameters(); // 2. SQL sorgusu için kullanılacak parametreler

            // 3. Parametreler ekleniyor:
            parameters.Add("@title", updateWhoWeAreDetailDto.Title); // Başlık (Title) parametresi
            parameters.Add("@subtitle", updateWhoWeAreDetailDto.SubTitle); // Alt Başlık (SubTitle) parametresi
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1); // Açıklama 1 (Description1) parametresi
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2); // Açıklama 2 (Description2) parametresi
            parameters.Add("@whowearedetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID); // Güncellenecek detayın kimliği (WhoWeAreDetailID) parametresi

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı oluşturuluyor

            {
                // 5. SQL sorgusu asenkron olarak veritabanında çalıştırılıyor ve belirtilen detayı güncelliyor.
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}