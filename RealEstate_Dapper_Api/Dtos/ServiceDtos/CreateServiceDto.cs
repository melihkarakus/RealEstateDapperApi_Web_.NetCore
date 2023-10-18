namespace RealEstate_Dapper_Api.Dtos.ServiceDtos
{
    public class CreateServiceDto
    {
        //Veritabanındaki bilgilerden gelicek proplar
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
