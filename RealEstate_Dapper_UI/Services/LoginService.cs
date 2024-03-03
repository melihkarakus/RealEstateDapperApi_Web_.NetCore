using System.Security.Claims;

namespace RealEstate_Dapper_UI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        /*ClaimsTypes kullanarak kullanıcının isim id sini yani id olarak getirmeye yarayabilir*/
        public string GetUserID => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
    }
}
