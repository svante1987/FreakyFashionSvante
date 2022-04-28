using System.ComponentModel.DataAnnotations;

namespace FreakyFashionSvante.CatalogService.Models.Domain
{
    public class Product
    {
        public Product(int id, string name, string description, string imageUrl, decimal price, string articleNumber, string urlSlug)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            ArticleNumber = articleNumber;
            UrlSlug = urlSlug;
        }

        [Key]
        public int Id { get; protected set; }
        public string Name { get; protected set; }  
        public string Description { get; protected set; }
        public string ImageUrl { get; protected set; }
        public decimal Price { get; protected set; }
        public string ArticleNumber { get; protected set; }
        public string UrlSlug { get; protected set; }
    }
}
