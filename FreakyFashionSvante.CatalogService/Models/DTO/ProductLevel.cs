using System.ComponentModel.DataAnnotations;

namespace FreakyFashionSvante.CatalogService.Models.DTO
{
    public class ProductLevel
    {
        public ProductLevel(int id, string name, string description, string imageUrl, int price, string articleNumber, string urlSlug)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.imageUrl = imageUrl;
            this.price = price;
            this.articleNumber = articleNumber;
            this.urlSlug = urlSlug;
        }

        [Key]
        int id { get; set; }
        string name { get; set; }  
        string description { get; set; }
        string imageUrl { get; set; }
        int price { get; set; }
        string articleNumber { get; set; }
        string urlSlug { get; set; }
    }
}
