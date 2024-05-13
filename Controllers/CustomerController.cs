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
            // var detailCustomer = await _context.Customers.FindAsync(id);
            List<Customer> customers = await _context.Customers.ToListAsync();

            Customer customer = null;
            for (int i = 0; i < customers.Count; i++)
            {
                customer = customers[i];

                if (customer.Cust_Id == id)
                    break;
           

                customer = null;
            }

            if (customer == null)
            {
                return NotFound("Customer doesn't exist"); // Returns a 404 Not Found response if no order is found
            }
            return customer; // Returns the order with a 200 OK response
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

        //PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, Customer customer)
        {
            //Get specific customer in db
            Customer dbcustomer = await _context.Customers.FindAsync(id);

            //
            if (dbcustomer == null)
            {
                return BadRequest("Customer doesn't exist");
            }

            //Validate Name and Phone
            if (!Util.Util.isNamePhoneValid(customer.Name, customer.Phone))
            {
                return BadRequest("Invalid Name or Phone");
            }

            dbcustomer.Name = customer.Name;
            dbcustomer.Phone = customer.Phone;

            _context.Customers.Update(dbcustomer);
            _context.SaveChanges();
          
            
            return Ok(dbcustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            //Get specific customer in db
            Customer dbcustomer = await _context.Customers.FindAsync(id);

            //check customer exist in db
            if (dbcustomer == null)
            {
                return BadRequest("Customer doesn't exist");
            }

            //Remove
            _context.Customers.Remove(dbcustomer);
            _context.SaveChanges();
            return Ok("customer deleted");
        }
    }
}
