using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel getCheckAppUserViewModel)
        {
            // Boş bir "Claim" listesi oluşturuluyor.
            var claims = new List<Claim>();

            // Eğer "getCheckAppUserViewModel.Role" boş değilse, bir "Claim" nesnesi oluşturulup "claims" listesine ekleniyor.
            if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.Role))
                claims.Add(new Claim(ClaimTypes.Role, getCheckAppUserViewModel.Role));

            // "getCheckAppUserViewModel.Id" değeri "ClaimTypes.NameIdentifier" tipinde bir "Claim" oluşturularak "claims" listesine ekleniyor.
            claims.Add(new Claim(ClaimTypes.NameIdentifier, getCheckAppUserViewModel.Id.ToString()));

            // Eğer "getCheckAppUserViewModel.Username" boş değilse, bir "Claim" nesnesi oluşturulup "claims" listesine ekleniyor.
            if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.Username))
                claims.Add(new Claim("Username", getCheckAppUserViewModel.Username));

            // SymmetricSecurityKey kullanılarak bir anahtar oluşturuluyor.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokeDefault.Key));

            // Oluşturulan anahtar ve algoritma bilgisi kullanılarak bir "SigningCredentials" nesnesi oluşturuluyor.
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Token'ın geçerlilik süresi belirleniyor (şu anki zaman üzerine "JwtTokeDefault.Expier" gün ekleniyor).
            var expireDate = DateTime.UtcNow.AddDays(JwtTokeDefault.Expier);

            // JwtSecurityToken sınıfı kullanılarak bir JWT oluşturuluyor.
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokeDefault.ValidIssuer,      // Token'ın yayımlandığı yer
                audience: JwtTokeDefault.ValidAudience,  // Token'ın kullanılacağı hedef
                claims: claims,                          // Token'a eklenen talepler (claims)
                notBefore: DateTime.UtcNow,              // Token'ın ne zaman geçerli olacağı
                expires: expireDate,                     // Token'ın ne zaman geçerliliğini yitireceği
                signingCredentials: signinCredentials   // Token'ı imzalamak için kullanılan bilgiler
            );

            // JwtSecurityTokenHandler sınıfı kullanılarak JWT string'e dönüştürülüyor ve bir TokenResponseViewModel nesnesi oluşturuluyor.
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
