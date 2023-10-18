namespace RealEstate_Dapper_Api.Dtos.TestimonialDtos
{
    public class ResultTestimonialDtos
    {
        public int TestimonialID { get; set; } //Veritabanı bağlantısı için gelen verileri
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
