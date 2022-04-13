using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RistoranteSiciliano.Models;

using Microsoft.Extensions.Logging;



namespace RistoranteSiciliano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomersModel model = new CustomersModel();

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("customer")]
        public IActionResult getCustomer(int id)
        {
            try
            {
                return Ok(model.getACustomersDetail(id));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }


        [HttpGet]
        [Route("clist")]
        public IActionResult customerList()
        {
            return Ok(model.getAllCustomers());
        }


        [HttpGet]
        [Route("customerInvoice")]
        public IActionResult getCustomerInvioce(int id)
        {
            try
            {
                return Ok(model.getACustomerInvoice(id));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }

        [HttpPost]
        [Route("addcustomer")]
        public IActionResult Addproduct(CustomersModel newCustomer)
        {
            try
            {
                return Created("", model.addACustomer(newCustomer));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }

        }



    }
}