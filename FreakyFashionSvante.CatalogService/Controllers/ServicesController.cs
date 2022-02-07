using FreakyFashionSvante.CatalogService.Data;
using FreakyFashionSvante.CatalogService.Models.Domain;
using FreakyFashionSvante.CatalogService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionSvante.CatalogService.Controllers
{

    [Route("api/[controller]")] //URL
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductServiceContext Context { get; }

        public ProductController(ProductServiceContext context)
        {
            Context = context;
        }

        [HttpPost("{articleNumber}")] //Lägger till artikelnummer och hur många som finns i lager.
        public IActionResult UpdateProductLevel(string articleNumber, UpdateProductDTO updateProductDto)
        {

            var productLevel = Context.ProductLevel.FirstOrDefault(x => x.ArticleNumber == updateProductDto.ArticleNumber);

            if (productLevel == null) //Om ProductLevel är null så genereras en insert into
            {
                productLevel = new ProductLevel(
                   updateProductDto.Name,
                   updateProductDto.Description,
                   updateProductDto.ImageUrl,
                   updateProductDto.Price,
                   updateProductDto.ArticleNumber,
                   updateProductDto.UrlSlug
               );
                Context.ProductLevel.Add(productLevel);
            }
            else // om ProductLevel inte är null så kommer nedan kod generera en update istället när vi kör SaveChanges()
            {
                productLevel.Name = updateProductDto.Name;
                productLevel.Description = updateProductDto.Description;
                productLevel.ImageUrl = updateProductDto.ImageUrl;
                productLevel.ArticleNumber = updateProductDto.ArticleNumber;
                productLevel.Price = updateProductDto.Price;
            }
            Context.SaveChanges();

            return NoContent();
        }

        [HttpGet] //Hämtar artikelnummer och antal i lager
        public IEnumerable<ProductLevelDto> GetAll()
        {
            var productLevelDto = Context.ProductLevel.Select(x => new ProductLevelDto
            {
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                ArticleNumber = x.ArticleNumber,
            });
            return productLevelDto;
        }
    }

    public class ProductLevelDto
    {
        public string Name{ get; set; }
        public string Description{ get; set; }
        public string ImageUrl{ get; set; }
        public decimal Price{ get; set; }
        public string ArticleNumber{ get; set; }
        
    }
}
/*int Id { get; set; }
        string Name { get; set; }  
        string Description { get; set; }
        string ImageUrl { get; set; }
        int Price { get; set; }
        string ArticleNumber { get; set; }
        string UrlSlug { get; set; }*/