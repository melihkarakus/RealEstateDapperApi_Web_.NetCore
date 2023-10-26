using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.Statisticsrepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            // Aktif kategorilerin sayısını döndüren işlev.
            string query = "select count(*) from Category where CategoryStatus = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            // Aktif çalışanların sayısını döndüren işlev.
            string query = "select count(*) from Employee where Status = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            // "Yazlık" içeren ürünlerin sayısını döndüren işlev.
            string query = "select count(*) from Product where Title like '%Yazlık%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int AverageRoomCount()
        {
            // Ürün detaylarında ortalama oda sayısını döndüren işlev.
            string query = "select avg(RoomCount) from ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AveregeProductPriceByRent()
        {
            // "Satılık" türündeki ürünlerin ortalama fiyatını döndüren işlev.
            string query = "select avg(price) from Product where type = 'Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AveregeProductPriceBySale()
        {
            // "Kiralık" türündeki ürünlerin ortalama fiyatını döndüren işlev.
            string query = "select avg(price) from Product where type = 'Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            // Toplam kategori sayısını döndüren işlev.
            string query = "select count(*) from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            // En fazla ürün içeren kategori adını döndüren işlev.
            string query = "select Top(1) CategoryName,Count(*) from Product inner join Category on " +
                "Product.ProductCategory=Category.CategoryID Group by CategoryName order by Count(*) desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount()
        {
            // En fazla ürün içeren şehir adını döndüren işlev.
            string query = "select top(1) City,Count(*) as 'ilanSayısı' from Product Group by City order by ilanSayısı desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCityCount()
        {
            // Farklı şehirlerin sayısını döndüren işlev.
            string query = "select count(distinct(City)) from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            // En fazla ürün ekleyen çalışanın adını döndüren işlev.
            string query = "select Name,Count(*) 'productcount' from Product Inner join Employee on " +
                "Product.EmployeeID = Employee.EmployeeID Group by Name order by productcount desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            // En son eklenen ürünün fiyatını döndüren işlev.
            string query = "select top(1) Price from Product order by  ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()
        {
            // En yeni yapı yılını döndüren işlev.
            string query = "select top(1) BuildYear from ProductDetails order by  BuildYear desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear()
        {
            // En eski yapı yılını döndüren işlev.
            string query = "select top(1) BuildYear from ProductDetails order by  BuildYear asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            // Pasif kategorilerin sayısını döndüren işlev.
            string query = "select count(*) from Category where CategoryStatus = 0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            // Toplam ürün sayısını döndüren işlev.
            string query = "select count(*) from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
