using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = "select * from AppUser Where Username = @username and Password = @password";
            string query2 = "select UserId from AppUser Where Username = @username and Password = @password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", createLoginDto.Username);
            parameters.Add("@password", createLoginDto.Password);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                var values2 = await connection.QueryFirstAsync<GetAppUserIdDto>(query2, parameters);
                
                if(values != null)
                {
                    GetCheckAppUserViewModel getCheckAppUserViewModel = new GetCheckAppUserViewModel();
                    getCheckAppUserViewModel.Username = values.Username;
                    getCheckAppUserViewModel.Id = values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(getCheckAppUserViewModel);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
