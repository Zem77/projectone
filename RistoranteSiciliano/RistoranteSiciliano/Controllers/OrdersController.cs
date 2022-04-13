using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RistoranteSiciliano.Models;
using Microsoft.Extensions.Logging;



namespace RistoranteSiciliano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        Orders model = new Orders();
        OrderedProductsModel modelOP = new OrderedProductsModel();

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        //Get One Particular Orders Details?
        [HttpGet]
        [Route("getAOrder")]
        public IActionResult getASingleOrder(int id)
        {
            try
            {
                return Ok(modelOP.getOneOrder(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("getOneCustomersOrders")]
        public IActionResult getASingleCustomersOrders(int id)
        {
            try
            {
                return Ok(modelOP.getACustomersOrders(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet] 
        [Route("getAllOrders")]
        public IActionResult getCustomerOrders()
        {
            try
            {
                return Ok(modelOP.getAllCustomerOrders());
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }


        [HttpPost]
        [Route("addAOrder")]
        public IActionResult addOrder(int id)
        {
            try
            {
                return Ok(model.addAOrder(id));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }






    }
}
