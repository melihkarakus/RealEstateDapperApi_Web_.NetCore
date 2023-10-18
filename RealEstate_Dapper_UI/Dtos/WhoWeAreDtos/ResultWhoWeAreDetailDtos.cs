namespace RealEstate_Dapper_UI.Dtos.WhoWeAreDtos
{
    public class ResultWhoWeAreDetailDtos
    {
        public int WhoWeAreDetailID { get; set; } //Veri tabanındaki bilgileri buraya getirip ınvoke taşıyoruz
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
