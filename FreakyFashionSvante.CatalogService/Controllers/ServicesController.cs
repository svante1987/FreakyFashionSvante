using FreakyFashionSvante.CatalogService.Data;
using FreakyFashionSvante.CatalogService.Models.Domain;
using FreakyFashionSvante.CatalogService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FreakyFashionSvante.CatalogService.Controllers
{

    [Route("api/[controller]")] //URL
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductServiceContext Context { get; set; }

        public ProductController(ProductServiceContext context)
        {
            Context = context;
        }

        [HttpPost] //Lägger till ny produkt
        public IActionResult NewProduct(ProductDto productDto)
        {
            var name = productDto.Name;
            name = name.Replace("-", "");
            name = name.Replace(" ", "-");
            
            var product = new Product(
                id: productDto.Id,
                name: productDto.Name,
                description: productDto.Description,
                imageUrl: productDto.ImageUrl,
                price: productDto.Price,
                articleNumber: productDto.ArticleNumber,
                urlSlug: name.ToLower()
            );

            Context.Product.Add(product);

            Context.SaveChanges();

            if (product == null)
            {
                return NotFound();
            }
            else
            {
            return Created("", productDto);
            }
        }

        [HttpGet] //Hämtar artikelnummer och antal i lager
        public ActionResult<IEnumerable<Product>>Get()
        {
            var products = Context.Product.ToList();
            return products;
        }
    }
}