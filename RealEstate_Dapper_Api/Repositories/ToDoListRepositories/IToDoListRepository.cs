using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        void CreateToDoList(CreateToDoListDtos createToDoListDtos);
        void DeleteToDoList(int id);
        void UpdateToDoList(UpdateToDoListDtos updateToDoListDtos);
        Task<GetByIDToDoListDto> GetToDoList(int id);
    }
}
