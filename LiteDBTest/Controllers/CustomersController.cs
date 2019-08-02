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
        // GET: api/Customers/credentials?fileName=testdb
        [HttpGet("credentials")]
        public IEnumerable<Customer> Get(string fileName)
        {

            var customers = _context.Context.GetCollection<Customer>("customers");
            return customers.FindAll();//new string[] { "value1", "value2" };
        }

        // GET: api/Customers/credentials?fileName=testdb&name=TestMan
        [HttpGet("credentials")]
        public Customer Get(string fileName, string name)
        {


            return _context.Context.GetCollection<Customer>("customers").Find(x => x.Name == name).FirstOrDefault();
        }

        // POST: api/Customers/credentials?fileName=testdb
        [HttpPost("credentials")]
        public void Post(string fileName, Customer customer)
        {
            var customers = _context.Context.GetCollection<Customer>("customers");
            customers.Insert(customer);
            customers.EnsureIndex(x => x.Name);

        }

        // PUT: api/Customers/credentials?fileName=testdb
        [HttpPut("credentials")]
        public void Put(string fileName, Customer customer)
        {
            var customers = _context.Context.GetCollection<Customer>("customers");
            customers.Update(customer);
        }

        // DELETE: api/ApiWithActions/credentials?fileName=testdb&id=5
        [HttpDelete("credentials")]
        public void Delete(string fileName, int id)
        {
            var customers = _context.Context.GetCollection<Customer>("customers");
            customers.Delete(id);
        }
    }
}
