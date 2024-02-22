using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepositories;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.Statisticsrepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepostiory;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný baðlantýsýný temsil eden Context sýnýfýný geçici bir hizmet olarak kaydet.
builder.Services.AddTransient<Context>();
// 2. ICategoryRepository arabirimini CategoryRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<ICategoryRepository, CategoryRepositoy>();

// 2. IProductRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// 2. IWhoWeAreDetailRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();

// 2. IWhoWeAreDetailRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();

// 2. IWhoWeAreDetailRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();

// 2. IWhoWeAreDetailRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();

// 2. IWhoWeAreDetailRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();

// 2. IWhoWeAreDetailRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

// 2. IWhoWeAreDetailRepository arabirimini ProductRepository sýnýfý ile eþle, 
// böylece bu arabirimi uygulayan nesneleri enjekte edebilirsiniz.
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();

builder.Services.AddTransient<IContactRepository, ContactRepository>();

builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();


//SignalR Konfigürasyonu
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddHttpClient(); //Bunu buraya eklemeliyiz çünkü Apiden veri çekmede bunu buraya eklememizi istiyor.
builder.Services.AddSignalR();
//SignalR Konfigürasyonu

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");//SignalR Konfigürasyonu

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");//SignalR Konfigürasyonu
//localhost:1234/swagger/category/index
//localhost:1234/signalrhub
app.Run();
