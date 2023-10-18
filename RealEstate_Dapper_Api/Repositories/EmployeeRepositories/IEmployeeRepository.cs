using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        // Tüm kategorilerin asenkron bir şekilde alınması için metod tanımı.
        void CreateEmployee(CreateEmployeeDto createEmployeeDto);
        // Kategori eklemek için tanımlanan metod.
        void DeleteEmployee(int id);
        // Kategori Silmek için tanımlanan metod
        void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        // Kategori Güncellemek için tanımlanan metod
        Task<GetByIDEmployeeDto> GetEmployee(int id);
        // Kategori sadece id ile getirilmesi için tanımlanan method
    }
}
