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
                return CreatedAtRoute(nameof(Get), new { id = model.Id});
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
            var result = _customers.GetSpecific(cpf, email);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Customer Not Found with this Email: {email} and Cpf: {cpf}");
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, CustomersModel customer)
        {
            try
            {
                _customers.Update(id, customer);
                return Ok();
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

        [HttpDelete("{id}")]
        public IActionResult DeleteByUser(long id)
        {
            try
            {
                _customers.Delete(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
