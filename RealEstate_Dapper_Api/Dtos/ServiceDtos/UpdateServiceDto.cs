namespace RealEstate_Dapper_Api.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; } //Veritabanındaki bilgilerden gelicek proplar
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
