namespace RealEstate_Dapper_UI.Dtos.WhoWeAreDtos
{
    public class ResultServicesDtos
    {
        public int ServiceID { get; set; } //Veri tabanından bilgileri çekmek için tanımlanmıştır.
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
