namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductAdvertListWithCategoryByEmployeeDtos
    {
        public int productID { get; set; }
        // Ürünün kimliğini (ID) temsil eden özellik. Bu özellik, her bir ürünün benzersiz kimliğini saklar.

        public string title { get; set; }
        // Ürünün başlığını temsil eden özellik. Bu özellik, bir ürünün adını saklar.

        public decimal price { get; set; }
        // Ürünün fiyatını temsil eden özellik. Decimal türü, kesirli sayıları doğru bir şekilde temsil edebilir.

        public string city { get; set; }
        // Ürünün bulunduğu şehri temsil eden özellik.

        public string district { get; set; }
        // Ürünün bulunduğu bölge veya ilçeyi temsil eden özellik.

        public string categoryName { get; set; }
        // Ürünün ait olduğu kategori adını temsil eden özellik. Bu özellik,
        // ürünlerin hangi kategoriye ait olduğunu belirtir ve ilişkili "Category" sınıfındaki "CategoryName" özelliği ile ilişkilendirilir.
        public string coverImage { get; set; }
        public string type { get; set; }
        public string address { get; set; }
        public bool dealoftheday { get; set; }
    }
}
