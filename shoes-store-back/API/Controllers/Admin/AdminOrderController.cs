using API.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/admin/order")]
    [Authorize(Roles = "Admin")]
    public class AdminOrderController : Controller
    {
        private readonly OrderDAO dao;
        private readonly StatisticsDAO statisticsDAO;
        public AdminOrderController(OrderDAO dao, StatisticsDAO statisticsDAO) { 
            this.dao = dao;
            this.statisticsDAO = statisticsDAO;
        }
        [HttpGet("get-all"),Authorize]
        public IActionResult GetAllOrder()
        {
            var response = dao.GetAllOrder();
            return StatusCode(response.StatusCode,response);
        }

        [HttpPost("update-order"), Authorize]
        public IActionResult UpdateOrderStatus([FromBody] int orderID)
        {
            var response = dao.UpdateOrderStatus(orderID);
            return StatusCode(response.StatusCode,response);
        }
    }
}
