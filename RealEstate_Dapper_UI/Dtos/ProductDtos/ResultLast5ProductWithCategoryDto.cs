namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultLast5ProductWithCategoryDto
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

        public string CategoryName { get; set; }

        public DateTime AdvertisementDate { get; set; }
    }
}
