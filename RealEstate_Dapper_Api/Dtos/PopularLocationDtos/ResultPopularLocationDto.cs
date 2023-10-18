namespace RealEstate_Dapper_Api.Dtos.PopularLocationDtos
{
    public class ResultPopularLocationDto
    {
        public int LocationID { get; set; } //Veritabanından gelen verileri burada tutuyoruz.
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
    }
}
