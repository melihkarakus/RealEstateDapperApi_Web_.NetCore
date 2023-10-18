using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        // Tüm kategorilerin asenkron bir şekilde alınması için metod tanımı.
        void CreateService(CreateServiceDto createServiceDto);
        // Kategori eklemek için tanımlanan metod.
        void DeleteService(int id);
        // Kategori Silmek için tanımlanan metod
        void UpdateService(UpdateServiceDto updateServiceDto);
        // Kategori Güncellemek için tanımlanan metod
        Task<GetByIDServiceDto> GetService(int id);
        // Kategori sadece id ile getirilmesi için tanımlanan method
    }
}
