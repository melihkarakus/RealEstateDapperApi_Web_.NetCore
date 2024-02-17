namespace RealEstate_Dapper_UI.Dtos.BottomGridDtos
{
    public class UpdateBottomGridDtos
    {
        public int BottomGridID { get; set; } //Veritabanındaki verileri burada çekmek için veritabanındaki gibi tanımladık
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
