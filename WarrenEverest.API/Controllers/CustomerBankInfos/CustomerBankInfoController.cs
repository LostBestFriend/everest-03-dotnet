using AppServices.CustomerBankInfos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WarrenEverest.API.Controllers.CustomerBankInfos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBankInfoController : ControllerBase
    {
        private readonly ICustomerBankInfoAppService _customerBankInfoAppService;

        public CustomerBankInfoController(ICustomerBankInfoAppService customerBankInfoAppService)
        {
            _customerBankInfoAppService = customerBankInfoAppService ??
                throw new ArgumentNullException(nameof(customerBankInfoAppService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBalanceByIdAsync(long id)
        {
            var result = await _customerBankInfoAppService
                .GetBalanceByIdAsync(id)
                .ConfigureAwait(false);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound($"Customer Not Found with this Id: {id}");
        }

        [HttpPatch("{id}/deposit")]
        public IActionResult Deposit(long id, decimal amount)
        {
            try
            {
                _customerBankInfoAppService.Deposit(id, amount);
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
                _customerBankInfoAppService.Withdraw(id, amount);
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
    }
}
