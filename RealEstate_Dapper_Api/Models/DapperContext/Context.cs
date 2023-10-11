using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration; // IConfiguration nesnesini alarak Context sınıfını başlatır.
            _connectionString = _configuration.GetConnectionString("connection");
            // Veritabanı bağlantı dizesini IConfiguration aracılığıyla alır.
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        // IDbConnection türünde yeni bir SqlConnection oluşturarak, veritabanı bağlantısını oluşturur.
    }
}
