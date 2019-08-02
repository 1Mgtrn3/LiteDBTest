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
        public Customer Get(string name)
        {


            return _context.Context.GetCollection<Customer>("customers").Find(x => x.Name == name).FirstOrDefault();
        }

        // POST: api/Customers
        [HttpPost]
        public void Post(Customer customer)
        {
            var customers = _context.Context.GetCollection<Customer>("customers");
            customers.Insert(customer);
            customers.EnsureIndex(x => x.Name);

        }

        // PUT: api/Customers/5
        [HttpPut]
        public void Put(Customer customer)
        {
            var customers = _context.Context.GetCollection<Customer>("customers");
            customers.Update(customer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customers = _context.Context.GetCollection<Customer>("customers");
            customers.Delete(id);
        }
    }
}
