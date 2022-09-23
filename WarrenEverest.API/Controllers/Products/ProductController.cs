using AppModels.Products.Mapper;
using AppServices.Products.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WarrenEverest.API.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
        }

        [HttpGet(Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var result = _productAppService.GetAllProducts();
                return result.Any() ? Ok(result) : NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductRequest createProduct)
        {
            try
            {
                var newProduct = await _productAppService.CreateAsync(createProduct).ConfigureAwait(false);
                return CreatedAtRoute(nameof(GetAllProducts), new { id = newProduct });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _productAppService.GetByIdAsync(id).ConfigureAwait(false);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Product Not Found with this Id: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _productAppService.Delete(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
