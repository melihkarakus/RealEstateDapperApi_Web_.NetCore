namespace RealEstate_Dapper_UI.Dtos.ServiceDtos
{
    public class UpdateServiceDtos
    {
        public int ServiceID { get; set; } //Veritabanındaki bilgilerden gelicek proplar
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
