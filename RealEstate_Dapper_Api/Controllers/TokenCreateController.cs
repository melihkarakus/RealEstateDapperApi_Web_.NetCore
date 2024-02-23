using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateToken(GetCheckAppUserViewModel getCheckAppUserViewModel)
        {
            var values = JwtTokenGenerator.GenerateToken(getCheckAppUserViewModel);
            return Ok(values);
        }
    }
}
 