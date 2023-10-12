namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        // Ürünün kimliğini (ID) temsil eden özellik. Bu özellik, her bir ürünün benzersiz kimliğini saklar.

        public string Title { get; set; }
        // Ürünün başlığını temsil eden özellik. Bu özellik, bir ürünün adını saklar.

        public decimal Price { get; set; }
        // Ürünün fiyatını temsil eden özellik. Decimal türü, kesirli sayıları doğru bir şekilde temsil edebilir.

        public string City { get; set; }
        // Ürünün bulunduğu şehri temsil eden özellik.

        public string District { get; set; }
        // Ürünün bulunduğu bölge veya ilçeyi temsil eden özellik.

        public string CategoryName { get; set; }
        // Ürünün ait olduğu kategori adını temsil eden özellik. Bu özellik,
        // ürünlerin hangi kategoriye ait olduğunu belirtir ve ilişkili "Category" sınıfındaki "CategoryName" özelliği ile ilişkilendirilir.
    }
}
