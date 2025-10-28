using Microsoft.AspNetCore.Mvc;
using VegMeatMarket.Domain.Dtos;
using VegMeatMarket.Domain.Features;

namespace VegMeatMarket.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] string? category = null)
        {
            var result = _productService.GetProducts(category);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDto dto)
        {
          
            var result = _productService.CreateProduct(dto, "Admin");
            return Ok(result);
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateProductPartial([FromRoute] int id, [FromBody] ProductUpdateDto dto)
        {
            var result = _productService.UpdateProduct(id, dto, "Admin");

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);       
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id, "Admin");
            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}
