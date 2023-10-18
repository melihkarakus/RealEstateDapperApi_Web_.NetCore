namespace RealEstate_Dapper_UI.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }     // Kategori kimliği (ID) için özellik.
        public string CategoryName { get; set; } // Kategori adı için özellik.
        public bool CategoryStatus { get; set; } // Kategori durumu için özellik.
    }
}
