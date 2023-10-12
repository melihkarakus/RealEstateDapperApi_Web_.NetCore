namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        // Product kimliği (ID) için özellik. Bu özellik, her bir ürünün benzersiz kimliğini temsil eder.

        public string Title { get; set; }
        // Product başlığı için özellik. Bu özellik, bir ürünün başlığını (adını) saklar.

        public decimal Price { get; set; }
        // Ürünün fiyatını saklamak için kullanılan özellik. Decimal türü, kesirli sayıları doğru bir şekilde temsil edebilir.

        public string City { get; set; }
        // Ürünün bulunduğu şehri saklamak için kullanılan özellik.

        public string District { get; set; }
        // Ürünün bulunduğu bölge veya ilçeyi saklamak için kullanılan özellik.

        public int ProductCategory { get; set; }
        // Ürünün ait olduğu kategori kimliğini (ID) saklamak için kullanılan özellik. Bu özellik,
        // ürünlerin hangi kategoriye ait olduğunu belirler ve ilişkili kategori tablosuna referans sağlar.
    }
}
