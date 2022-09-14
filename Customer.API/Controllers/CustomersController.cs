using Customer.AppServices.Services.Interface;
using Customer.DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomersModel model)
        {
            try
            {
                var newCustomer = _customerAppService.Create(model);
                return CreatedAtRoute(nameof(Get), new { id = model.Id }, model);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(Name = "Get")]
        public IActionResult Get()
        {
            try
            {
                var result = _customerAppService.Get();
                return result.Any() ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                return Problem($"Operation not completed. Error: {ex.Message}");
            }
        }

        [HttpGet("cpf-or-email")]
        public IActionResult GetSpecific(string cpf, string email)
        {
            var result = _customerAppService.GetSpecific(cpf, email);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Customer Not Found with this Email: {email} and Cpf: {cpf}");
        }

        [HttpPut("{id}")]
        public IActionResult Update(CustomersModel customer)
        {
            try
            {
                _customerAppService.Update(customer);
                return Ok("Customer Update Successfully");
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteByUser(long id)
        {
            try
            {
                _customerAppService.Delete(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}