using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context; // Bağlam (context) nesnesini alarak CategoryRepositoy sınıfını başlatır.
        }
        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            // 2. SQL sorgusu, Category tablosuna yeni bir kategori eklemek için kullanılır.
            string query = "insert into Employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status) values (@name, @title, @mail, @phonenumber, @imageurl, @status)";

            // 3. SQL sorgusu için kullanılacak parametreler tanımlanır.
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDto.Name); // Kategori adı
            parameters.Add("@title", createEmployeeDto.Title); // Kategori adı
            parameters.Add("@mail", createEmployeeDto.Mail); // Kategori adı
            parameters.Add("@phonenumber", createEmployeeDto.PhoneNumber); // Kategori adı
            parameters.Add("@imageurl", createEmployeeDto.ImageUrl); // Kategori adı
            parameters.Add("@status", true); // Kategori durumu (varsayılan olarak true olarak ayarlanmış).

            // 4. Veritabanı bağlantısı oluşturulur.
            using (var connection = _context.CreateConnection())
            {
                // 5. Asenkron olarak SQL sorgusu çalıştırılır ve yeni kategori eklenir.
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            // 2. SQL sorgusu, Category tablosuna yeni bir kategori silmek için kullanılır
            string query = "delete from Employee Where EmployeeID = @employeeID";
            // 3. SQL sorgusu için kullanılacak parametreler tanımlar.
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id); // Kategori id
            using (var connection = _context.CreateConnection())// 4. Veritabanı bağlantısı oluşturulur.
            {
                await connection.ExecuteAsync(query, parameters);// 5. Asenkron olarak SQL sorgusu çalıştırılır ve kategori siler.
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "select * from Employee"; // SQL sorgusu, 'Category' tablosundaki tüm verileri alır.
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                // Veritabanından gelen sonuçları ResultCategoryDto türünde nesnelere dönüştürür.
                return values.ToList(); // Dönüştürülmüş sonuçları bir liste olarak döndürür.
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            // 2. SQL sorgusu, Category tablosundan sadece belirli bir kimlikle eşleşen kategoriyi getirir.
            string query = "SELECT * FROM Employee WHERE EmployeeID = @employeeID";

            var parameters = new DynamicParameters(); // 3. SQL sorgusu için kullanılacak parametreler tanımlanır.
            parameters.Add("@employeeID", id); // Kategori kimliği (ID)

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı oluşturulur.
            {
                // 5. Asenkron olarak SQL sorgusu çalıştırılır ve verilen kategori kimliği ile eşleşen kategoriyi alır.
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "UPDATE Employee SET Name = @name, Title = @title, Mail = @mail, PhoneNumber = @phonenumber, ImageUrl = @imageurl, Status = @status  WHERE EmployeeID = @employeeID";

            var parameters = new DynamicParameters(); // 2. SQL sorgusu için kullanılacak parametreler
            parameters.Add("@name", updateEmployeeDto.Name); // Kategori adı
            parameters.Add("@title", updateEmployeeDto.Title); // Kategori adı
            parameters.Add("@mail", updateEmployeeDto.Mail); // Kategori adı
            parameters.Add("@phonenumber", updateEmployeeDto.PhoneNumber); // Kategori adı
            parameters.Add("@imageurl", updateEmployeeDto.ImageUrl); // Kategori adı
            parameters.Add("@status", true); // Kategori durumu (varsayılan olarak true olarak ayarlanmış).
            parameters.Add("@employeeID", updateEmployeeDto.EmployeeID); // Kategori durumu (varsayılan olarak true olarak ayarlanmış).

            using (var connection = _context.CreateConnection()) // 4. Veritabanı bağlantısı
            {
                await connection.ExecuteAsync(query, parameters); // 5. Asenkron olarak SQL sorgusu çalıştırır ve kategoriyi günceller
            }
        }
    }
}
