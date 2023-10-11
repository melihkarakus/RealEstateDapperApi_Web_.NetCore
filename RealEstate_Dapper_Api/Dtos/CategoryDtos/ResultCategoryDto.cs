namespace RealEstate_Dapper_Api.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }     // Kategori kimliği (ID) için özellik.
        public string CategoryName { get; set; } // Kategori adı için özellik.
        public bool CategoryStatus { get; set; } // Kategori durumu için özellik.
    }
}
