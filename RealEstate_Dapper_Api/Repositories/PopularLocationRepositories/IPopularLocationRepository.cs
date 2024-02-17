using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        // Tüm kategorilerin asenkron bir şekilde alınması için metod tanımı.

        void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);

        void DeletePopularLocation(int id);

        void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);

        Task<GetByIDPopularLocationDto> GetPopularLocation(int id);
    }
}
