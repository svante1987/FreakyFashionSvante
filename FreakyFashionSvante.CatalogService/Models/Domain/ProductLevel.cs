using System.ComponentModel.DataAnnotations;

namespace FreakyFashionSvante.CatalogService.Models.Domain
{
    public class ProductLevel
    {
        public ProductLevel(int id, string name, string description, string imageUrl, int price, string articleNumber, string urlSlug)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.Price = price;
            this.ArticleNumber = articleNumber;
            this.UrlSlug = urlSlug;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public string ArticleNumber { get; set; }
        public string UrlSlug { get; set; }
    }
}
