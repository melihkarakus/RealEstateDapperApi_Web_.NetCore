using Microsoft.AspNetCore.Authentication.JwtBearer;
using RealEstate_Dapper_UI.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");//mapleme yapmadan direk id verisini getirmek i�in login i�leminde 62. Video izleyebilirsin.

// Add services to the container.
builder.Services.AddHttpClient();

/*JWT login i�lemi i�in program.cs girilmesi gereken kod*/
// Uygulama servislerine JWT tabanl� kimlik do�rulama ekleniyor.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

    // JWT tabanl� kimlik do�rulama i�in Cookie tabanl� kimlik do�rulama ekleniyor.
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        // Kullan�c� giri�i yap�lmas� gerekti�inde y�nlendirilecek sayfan�n yolu belirleniyor.
        opt.LoginPath = "/Login/Index/";

        // Kullan�c� ��k��� yap�ld���nda y�nlendirilecek sayfan�n yolu belirleniyor.
        opt.LogoutPath = "/Login/LogOut/";

        // Eri�im reddedildi�inde y�nlendirilecek sayfan�n yolu belirleniyor.
        opt.AccessDeniedPath = "/Pages/AccessDenied/";

        // Olu�turulan cookie'nin sadece HTTP istekleri �zerinden eri�ilebilir olmas� sa�lan�yor.
        opt.Cookie.HttpOnly = true;

        // Cookie'nin g�venlik politikas� belirleniyor.
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

        // Olu�turulan cookie'nin ad� belirleniyor.
        opt.Cookie.Name = "realestateJwt";
    });
/*JWT login i�lemi i�in program.cs girilmesi gereken kod*/

builder.Services.AddHttpContextAccessor();//JWT login i�in tan�mlanmas� gereken bir method.
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
