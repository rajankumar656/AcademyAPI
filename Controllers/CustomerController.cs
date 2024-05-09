using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademyAPI.Data;
using AcademyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
             _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Order/5 
        [HttpGet("{id}")] //Route Parameter
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var detailCustomer = await _context.Customers.FindAsync(id);
            if (detailCustomer == null)
            {
                return NotFound("Customer doesn't exist"); // Returns a 404 Not Found response if no order is found
            }
            return detailCustomer; // Returns the order with a 200 OK response
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create([Bind("Name,Phone")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Customer Details not valid"); // Return a 400 Bad Request if the order is not valid
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Cust_Id }, customer); // Return a 201 Created response with the order
        }

        ////PUT: api/Order/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Edit(int id, Order updatedOrder)
        //{
        //    var existingOrder = await _context.Orders.FindAsync(id);
        //    if (existingOrder == null) 
        //    {
        //        return NotFound();
        //    }

        //    if(!Util.Util.isAmtEmailValid(updatedOrder.Email, updatedOrder.Amount)) 
        //        return BadRequest("Invalid email or Amount");

        //    // step 2 -- validate request body
        //    existingOrder.Email = updatedOrder.Email;
        //    existingOrder.Amount = updatedOrder.Amount;

        //    _context.Orders.Update(existingOrder);

        //    _context.SaveChanges();
        //    return Ok(existingOrder);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var existingOrder = await _context.Orders.FindAsync(id);
        //    if (existingOrder == null)
        //    {
        //        return NotFound("Order doesn't exist");
        //    }

        //    if (id == existingOrder.OrderId)
        //    {
        //        _context.Orders.Remove(existingOrder);
        //        _context.SaveChanges();
        //    }


        //    return Ok("order deleted");
        //}
    }
}
