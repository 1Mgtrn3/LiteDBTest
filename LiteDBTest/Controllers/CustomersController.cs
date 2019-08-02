using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LiteDBTest.Models;

namespace LiteDBTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly LiteDbContext _context;
        public CustomersController(LiteDbContext context)
        {
            _context = context;
        }
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _context.Context.GetCollection<Customer>("customers");
            return customers.FindAll();//new string[] { "value1", "value2" };
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
