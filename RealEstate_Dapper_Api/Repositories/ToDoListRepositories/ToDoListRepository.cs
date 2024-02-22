using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async void CreateToDoList(CreateToDoListDtos createToDoListDtos)
        {
            string query = "insert into ToDoList (Description, ToDoListStatus) values (@descripton, @toDoListStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", createToDoListDtos.Description);
            parameters.Add("@toDoListStatus", createToDoListDtos.ToDoListStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
            
        public void DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * from ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDoList(UpdateToDoListDtos updateToDoListDtos)
        {
            throw new NotImplementedException();
        }
    }
}
