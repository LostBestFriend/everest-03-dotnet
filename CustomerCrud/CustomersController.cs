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
            _customers = customers;
        }
        [HttpPost]
        public IActionResult Create([FromBody] CustomersModel model)
        {
            return StatusCode(_customers.Create(model));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customers.Get());

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
        public IActionResult Update(CustomersModel customer)
        {
            var result = _customers.Update(customer);
            if ( result == 404)
            {
                return NotFound($"Customer Not Found with this Email: {customer.Email} and Cpf: {customer.Cpf}");
            }
            return StatusCode(result);
        }
        [HttpDelete]
        public IActionResult DeleteByUser(string cpf, string email)
        {
            var result = _customers.Delete(cpf, email);
            if (result == 404)
            {
                return NotFound($"Customer Not Found with this Email: {email} and Cpf: {cpf}");

            }
            return StatusCode(result);
        }
    }
}
