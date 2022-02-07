using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionSvante.CatalogService.Controllers
{

    [Route("api/[controller]")] //URL
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductServiceContext context)
        {
            Context = context;
        }

        private ProductServiceContext Context { get; }
        [HttpPut("{articleNumber}")] //Lägger till artikelnummer och hur många som finns i lager.
        public IActionResult UpdateProductLevel(string articleNumber, UpdateProductLevelDto updateProductLevelDto)
        {

            var ProductLevel = Context.ProductLevel.FirstOrDefault(x => x.ArticleNumber == updateProductLevelDto.ArticleNumber);

            if (ProductLevel == null) //Om ProductLevel är null så genereras en insert into
            {
                ProductLevel = new ProductLevel(
                   updateProductLevelDto.ArticleNumber,
                   updateProductLevelDto.ProductLevel
               );
                Context.ProductLevel.Add(ProductLevel);
            }
            else // om ProductLevel inte är null så kommer nedan kod generera en update istället när vi kör SaveChanges()
            {
                ProductLevel.Product = updateProductLevelDto.ProductLevel;
            }
            Context.SaveChanges();

            return NoContent();
        }

        [HttpGet] //Hämtar artikelnummer och antal i lager
        public IEnumerable<ProductLevelDto> GetAll()
        {
            var ProductLevelDtos = Context.ProductLevel.Select(x => new ProductLevelDto
            {
                ArticleNumber = x.ArticleNumber,
                Product = x.Product,
            });
            return ProductLevelDtos;
        }
    }

    public class ProductLevelDto
    {
        public string ArticleNumber { get; set; }

        public int Product { get; set; }
    }
}
