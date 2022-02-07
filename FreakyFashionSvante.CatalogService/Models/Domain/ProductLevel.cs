using System.ComponentModel.DataAnnotations;

namespace FreakyFashionSvante.CatalogService.Models.Domain
{
    public class ProductLevel
    {
        public ProductLevel(string name, string description, string imageUrl, decimal price, string articleNumber, string urlSlug)
        {
            
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            ArticleNumber = articleNumber;
            UrlSlug = urlSlug;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string ArticleNumber { get; set; }
        public string UrlSlug { get; set; }
    }
}
