using AppModels.Orders.Mapper;
using AppServices.Orders.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WarrenEverest.API.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
        }

        [HttpGet(Name = "GetByPortfolioId")]
        public IActionResult GetByPortfolioId(long portfolioId)
        {
            try
            {
                var result = _orderAppService.GetByPortfolioId(portfolioId);
                return result.Any() ? Ok(result) : NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderRequest createOrder)
        {
            try
            {
                var newOrder = await _orderAppService.CreateAsync(createOrder).ConfigureAwait(false);
                return CreatedAtRoute(nameof(GetByPortfolioId), new { id = newOrder });
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
            var result = await _orderAppService.GetByIdAsync(id).ConfigureAwait(false);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Order Not Found with this Id: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _orderAppService.Delete(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
