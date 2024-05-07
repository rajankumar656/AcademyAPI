using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademyAPI.Data;
using AcademyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WebController(AppDbContext context)
        {
             _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var allOrders = await _context.Orders.ToListAsync();

            return Ok(allOrders);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{

        //    _context.SaveChanges();

        //    var detailOrder = _context.Orders.ToList();

        //    return Ok(detailOrder);
        //}

        //[HttpPost]
        //public IActionResult Post()
        //{
        //    return Ok("Hello World via Post");
        //}

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
