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

        // 1. Yeni bir kategori oluşturmak için kullanılan metot.
        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            // 2. SQL sorgusu, Category tablosuna yeni bir kategori eklemek için kullanılır.
            string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";

            // 3. SQL sorgusu için kullanılacak parametreler tanımlanır.
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName); // Kategori adı
            parameters.Add("@categoryStatus", true); // Kategori durumu (varsayılan olarak true olarak ayarlanmış).

            // 4. Veritabanı bağlantısı oluşturulur.
            using (var connection = _context.CreateConnection())
            {
                // 5. Asenkron olarak SQL sorgusu çalıştırılır ve yeni kategori eklenir.
                await connection.ExecuteAsync(query, parameters);
            }
        }
      
        // 1. Kategori Silme oluşturmak için kullanılan method
        public async void DeleteCategory(int id)
        {
            // 2. SQL sorgusu, Category tablosuna yeni bir kategori silmek için kullanılır
            string query = "delete from Category Where CategoryID = @categoryID";
            // 3. SQL sorgusu için kullanılacak parametreler tanımlar.
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id); // Kategori id
            using (var connection = _context.CreateConnection())// 4. Veritabanı bağlantısı oluşturulur.
            {
                await connection.ExecuteAsync(query, parameters);// 5. Asenkron olarak SQL sorgusu çalıştırılır ve kategori siler.
            }
        }
        
        // 1. Kategorilerin tamamını getirmek için kullanılan method
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

        // 1. Belirli bir kategori kimliği (ID) ile bir kategori getirmek için kullanılan metot.
        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            // 2. SQL sorgusu, Category tablosundan sadece belirli bir kimlikle eşleşen kategoriyi getirir.
            string query = "SELECT * FROM Category WHERE CategoryID = @categoryID";

            var parameters = new DynamicParameters(); // 3. SQL sorgusu için kullanılacak parametreler tanımlanır.
            parameters.Add("@categoryID", id); // Kategori kimliği (ID)

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı oluşturulur.
            {
                // 5. Asenkron olarak SQL sorgusu çalıştırılır ve verilen kategori kimliği ile eşleşen kategoriyi alır.
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }

        //1. Kategorileri Güncellemek için kullanılan metot.
        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            // 1. SQL sorgusu, "Category" tablosundaki bir sütunun güncellenmesi için kullanılan SQL sorgusu.
            string query = "UPDATE Category SET CategoryName = @categoryName, CategoryStatus = @categoryStatus WHERE CategoryID = @categoryID";

            var parameters = new DynamicParameters(); // 2. SQL sorgusu için kullanılacak parametreler
            parameters.Add("@categoryName", categoryDto.CategoryName); // Kategori adı
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus); // Kategori durumu (categoryStatus)
            parameters.Add("@categoryID", categoryDto.CategoryID); // Kategori kimliği (CategoryID)

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı
            {
                await connection.ExecuteAsync(query, parameters); // 5. Asenkron olarak SQL sorgusu çalıştırır ve kategoriyi günceller
            }
        }
    }
}
