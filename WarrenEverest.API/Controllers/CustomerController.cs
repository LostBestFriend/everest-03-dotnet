using AppModels.Mapper;
using AppServices.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WarrenEverest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customersAppService)
        {
            _customerAppService = customersAppService ?? throw new ArgumentNullException(nameof(customersAppService));
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerRequest model)
        {
            try
            {
                var newCustomer = _customerAppService.Create(model);
                return CreatedAtRoute(nameof(Get), new { id = newCustomer });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet(Name = "Get")]
        public IActionResult Get()
        {
            try
            {
                var result = _customerAppService.Get();
                return result.Any() ? Ok(result) : NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpGet("cpf-and-email")]
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
        public IActionResult Update(long id, UpdateCustomerRequest customer)
        {
            try
            {
                _customerAppService.Update(id, customer);
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
