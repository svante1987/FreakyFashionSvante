namespace FreakyFashionSvante.CatalogService.Models.DTO
{
    public class UpdateProductDTO
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public string ImageUrl { get; set; }
       public decimal Price { get; set; }
       public string ArticleNumber { get; set; }
       public string UrlSlug { get; set; }
    }
}

