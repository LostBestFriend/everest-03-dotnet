using Microsoft.AspNetCore.Mvc;

namespace _01_Back_End_Criação_de_Usuário
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
        public virtual ActionResult Create([FromBody] CustomersModel model)
        {
            return StatusCode(_customers.Create(model));
        }

        [HttpGet("Get All Customers")]
        public ActionResult Get()
        {
            return Ok(_customers.Get());

        }

        [HttpGet("Get Specific Customer")]
        public ActionResult GetSpecific(string cpf, string email)
        {
            var result = _customers.GetSpecific(cpf, email);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Customer Not Found with this Email: {email} and Cpf: {cpf}");
        }

        [HttpPut]
        public ActionResult Update(CustomersModel customer)
        {
            var result = _customers.Update(customer);
            if ( result == 404)
            {
                return NotFound($"Customer Not Found with this Email: {customer.Email} and Cpf: {customer.Cpf}");
            }
            return StatusCode(result);
        }

        [HttpDelete("Delete Customer by Email and Cpf")]
        public ActionResult DeleteByUser(string cpf, string email)
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
