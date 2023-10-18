using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        // Tüm kategorilerin asenkron bir şekilde alınması için metod tanımı.
        void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        // Kategori eklemek için tanımlanan metod.
        void DeleteBottomGrid(int id);
        // Kategori Silmek için tanımlanan metod
        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        // Kategori Güncellemek için tanımlanan metod
        Task<GetBottomGridDto> GetBottomGrid(int id);
        // Kategori sadece id ile getirilmesi için tanımlanan method
    }
}
