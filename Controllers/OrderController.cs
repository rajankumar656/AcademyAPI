using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademyAPI.Data;
using AcademyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Controllers
{
    [Route("api/order")]
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

        //PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Order updatedOrder)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null) 
            {
                return NotFound();
            }

            if(!Util.Util.isAmtEmailValid(updatedOrder.Email, updatedOrder.Amount)) 
                return BadRequest("Invalid email or Amount");

            // step 2 -- validate request body
            existingOrder.Email = updatedOrder.Email;
            existingOrder.Amount = updatedOrder.Amount;

            _context.Orders.Update(existingOrder);

            _context.SaveChanges();
            return Ok(existingOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound("Order doesn't exist");
            }

            if (id == existingOrder.OrderId)
            {
                _context.Orders.Remove(existingOrder);
                _context.SaveChanges();
            }
                

            return Ok("order deleted");
        }
    }
}
