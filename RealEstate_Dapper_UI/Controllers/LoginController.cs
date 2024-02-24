using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Models;
using System.Drawing.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstate_Dapper_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult SignIn()
        {          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            // HTTP isteği yapmak için HttpClient örneği oluşturuluyor.
            var client = _httpClientFactory.CreateClient();

            // Gönderilecek JSON verisi hazırlanıyor.
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");

            // Belirtilen URL'ye POST isteği yapılıyor.
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Login", content);

            // İsteğin başarılı olup olmadığı kontrol ediliyor.
            if (responseMessage.IsSuccessStatusCode)
            {
                // Sunucudan dönen JSON verisi okunuyor.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON verisi JwtResponseModel sınıfına deserialization ediliyor.
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                // TokenModel'in null olup olmadığı kontrol ediliyor.
                if (tokenModel != null)
                {
                    // JWT token'ı çözümleniyor.
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);

                    // Token'dan alınan iddialar (claims) listeye ekleniyor.
                    var claims = token.Claims.ToList();

                    // Token'ın null olup olmadığı kontrol ediliyor.
                    if (tokenModel.Token != null)
                    {
                        // Yeni bir iddia ("realestatetoken") ekleniyor.
                        claims.Add(new Claim("realestatetoken", tokenModel.Token));

                        // Yeni bir iddia listesiyle ClaimsIdentity oluşturuluyor.
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                        // Kimlik doğrulama özellikleri ayarlanıyor.
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        // HttpContext üzerinden kullanıcı oturumu başlatılıyor.
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                        // Yönlendirme yapılıyor.
                        return RedirectToAction("Index", "MyAdverts");
                    }
                }
            }

            // Başarısız durumda, ilgili view sayfasına dönülüyor.
            return View();
        }
    }
}
