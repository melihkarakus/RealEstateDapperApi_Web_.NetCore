using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDtos>> GetAllTestimonialAsync();
        // Tüm kategorilerin asenkron bir şekilde alınması için metod tanımı.
    }
}
