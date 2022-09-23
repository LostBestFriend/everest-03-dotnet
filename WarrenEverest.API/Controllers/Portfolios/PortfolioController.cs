using AppModels.Portfolios.Mapper;
using AppServices.Portfolios.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WarrenEverest.API.Controllers.Portfolios
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioAppService _portfolioAppService;

        public PortfolioController(IPortfolioAppService portfolioAppService)
        {
            _portfolioAppService = portfolioAppService ?? throw new ArgumentNullException(nameof(portfolioAppService));
        }

        [HttpGet(Name = "GetByCustomerId")]
        public IActionResult GetByCustomerId(long customerId)
        {
            try
            {
                var result = _portfolioAppService.GetByCustomerId(customerId);
                return result.Any() ? Ok(result) : NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePortfolioRequest createPortfolio)
        {
            try
            {
                var newPortfolio = await _portfolioAppService.CreateAsync(createPortfolio).ConfigureAwait(false);
                return CreatedAtRoute(nameof(GetByCustomerId), new { id = newPortfolio });
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

        [HttpPatch("{id}/invest")]
        public IActionResult Invest(long id, decimal amount)
        {
            try
            {
                _portfolioAppService.Invest(id, amount);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/withdraw")]
        public IActionResult Withdraw(long id, decimal amount)
        {
            try
            {
                _portfolioAppService.Withdraw(id, amount);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _portfolioAppService.Delete(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }


    }
}
