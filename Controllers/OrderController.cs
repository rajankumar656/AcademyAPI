using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademyAPI.Data;
using AcademyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
             _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Order/5 
        [HttpGet("{id}")] //Route Parameter
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var detailOrder = await _context.Orders.FindAsync(id);
            if (detailOrder == null) 
            {
                return NotFound(); // Returns a 404 Not Found response if no order is found
            }
            return detailOrder; // Returns the order with a 200 OK response
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create([Bind("Email,Amount")] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // Return a 400 Bad Request if the order is not valid
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderById), new {id = order.OrderId}, order); // Return a 201 Created response with the order
        }

        //[HttpPut]
        //public IActionResult Put()
        //{
        //    return Ok("Hello World via Put");
        //}

        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    return Ok("Hello World via Delete");
        //}

    }
}
