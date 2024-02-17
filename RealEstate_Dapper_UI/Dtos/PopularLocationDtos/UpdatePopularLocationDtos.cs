namespace RealEstate_Dapper_UI.Dtos.PopularLocationDtos
{
    public class UpdatePopularLocationDtos
    {
        public int LocationID { get; set; } //Veritabanından gelen verileri burada tutuyoruz.
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
    }
}
