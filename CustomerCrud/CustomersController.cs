using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCrudApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customers;

        public CustomersController(ICustomersRepository customers)
        {
            _customers = customers ?? throw new ArgumentNullException(nameof(customers));
        }

        [HttpPost]
        public IActionResult Create(CustomersModel model)
        {
            try
            {
                var newCustomer = _customers.Create(model);
                return CreatedAtRoute(nameof(Get), new { id = model.Id}, model);
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
                var result = _customers.Get();
                return result.Count == 0 ? NoContent() : Ok(result);
            }
            catch (Exception e)
            {
                return Problem("Operation not completed");
            }
        }

        [HttpGet("get-specific")]
        public IActionResult GetSpecific(string cpf, string email)
        {
            var result = _customers.GetSpecific(cpf, email);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Customer Not Found with this Email: {email} and Cpf: {cpf}");
        }

        [HttpPut]
        public IActionResult Update(long id, CustomersModel customer)
        {
            try
            {
                _customers.Update(id, customer);
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
        public IActionResult DeleteByUser(string cpf, string email)
        {
            try
            {
                _customers.Delete(cpf, email);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
