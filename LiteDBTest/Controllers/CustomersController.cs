using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LiteDBTest.Models;
using LiteDB;

namespace LiteDBTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        // GET: api/Customers/findAll?fileName=testdb
        [HttpGet("findAll")]
        public IEnumerable<Customer> Get(string fileName)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
                var customers = Context.GetCollection<Customer>("customers");
                return customers.FindAll();
            }

                //new string[] { "value1", "value2" };
        }

        // GET: api/Customers/find?fileName=testdb&name=TestMan
        [HttpGet("find")]
        public Customer Get(string fileName, string name)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
                
                return Context.GetCollection<Customer>("customers").Find(x => x.Name == name).FirstOrDefault();
            }
            
        }

        // POST: api/Customers/create?fileName=testdb
        [HttpPost("create")]
        public void Post(string fileName, Customer customer)
        {
            
            using (var Context = new LiteDatabase(@fileName))
            {
                var customers = Context.GetCollection<Customer>("customers");
                customers.Insert(customer);
                customers.EnsureIndex(x => x.Name);

                
            }
        }

        // PUT: api/Customers/edit?fileName=testdb
        [HttpPut("edit")]
        public void Put(string fileName, Customer customer)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
               
                var customers = Context.GetCollection<Customer>("customers");
                customers.Update(customer);
            }

        }

        // DELETE: api/ApiWithActions/delete?fileName=testdb&id=5
        [HttpDelete("delete")]
        public void Delete(string fileName, int id)
        {
            
            using (var Context = new LiteDatabase(@fileName))
            {
                var customers = Context.GetCollection<Customer>("customers");
                customers.Delete(id);
                
            }
        }
    }
}
