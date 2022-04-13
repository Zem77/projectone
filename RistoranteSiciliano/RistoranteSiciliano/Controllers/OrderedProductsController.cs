using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RistoranteSiciliano.Models;
using Microsoft.Extensions.Logging;


namespace RistoranteSiciliano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedProductsController : ControllerBase
    {
        OrderedProductsModel model = new OrderedProductsModel();

        private readonly ILogger<OrderedProductsController> _logger;

        public OrderedProductsController(ILogger<OrderedProductsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("addOrderedProducts")]
        public IActionResult addOrderedProducts(int oid, int pid)
        {
            try
            {
                return Created("", model.addAOrderedProduct(oid, pid));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }


        }

    }
}
