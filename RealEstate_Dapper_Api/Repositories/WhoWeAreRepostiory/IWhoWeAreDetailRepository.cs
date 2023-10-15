using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepostiory
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        // Tüm kategorilerin asenkron bir şekilde alınması için metod tanımı.
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        // Kategori eklemek için tanımlanan metod.
        void DeleteWhoWeAreDetail(int id);
        // Kategori Silmek için tanımlanan metod
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
        // Kategori Güncellemek için tanımlanan metod
        Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
        // Kategori sadece id ile getirilmesi için tanımlanan method
    }
}
