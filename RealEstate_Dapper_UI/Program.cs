using Microsoft.AspNetCore.Authentication.JwtBearer;
using RealEstate_Dapper_UI.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");//mapleme yapmadan direk id verisini getirmek için login iþleminde 62. Video izleyebilirsin.

// Add services to the container.
builder.Services.AddHttpClient();

/*JWT login iþlemi için program.cs girilmesi gereken kod*/
// Uygulama servislerine JWT tabanlý kimlik doðrulama ekleniyor.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

    // JWT tabanlý kimlik doðrulama için Cookie tabanlý kimlik doðrulama ekleniyor.
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        // Kullanýcý giriþi yapýlmasý gerektiðinde yönlendirilecek sayfanýn yolu belirleniyor.
        opt.LoginPath = "/Login/Index/";

        // Kullanýcý çýkýþý yapýldýðýnda yönlendirilecek sayfanýn yolu belirleniyor.
        opt.LogoutPath = "/Login/LogOut/";

        // Eriþim reddedildiðinde yönlendirilecek sayfanýn yolu belirleniyor.
        opt.AccessDeniedPath = "/Pages/AccessDenied/";

        // Oluþturulan cookie'nin sadece HTTP istekleri üzerinden eriþilebilir olmasý saðlanýyor.
        opt.Cookie.HttpOnly = true;

        // Cookie'nin güvenlik politikasý belirleniyor.
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

        // Oluþturulan cookie'nin adý belirleniyor.
        opt.Cookie.Name = "realestateJwt";
    });
/*JWT login iþlemi için program.cs girilmesi gereken kod*/

builder.Services.AddHttpContextAccessor();//JWT login için tanýmlanmasý gereken bir method.
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
