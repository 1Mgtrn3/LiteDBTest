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

        [HttpGet("findAllAsync")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAsync(string fileName)
        {
            
            return Ok(await GetAllCustomersAsync(fileName).ConfigureAwait(false));

            
        }

        private Task<IEnumerable<Customer>> GetAllCustomersAsync(string fileName)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
                return Task.Run(() => {

                    var customers = Context.GetCollection<Customer>("customers");
                    return customers.FindAll();
                });
            };


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


        [HttpGet("findAsync")]
        public async Task<ActionResult<Customer>> GetAsync(string fileName, string name)
        {

            return Ok(await GetAsync(fileName,name).ConfigureAwait(false));

        }

        private Task<Customer> GetCustomerAsync(string fileName, string name)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
                return Task.Run(() => {

                    var customers = Context.GetCollection<Customer>("customers");
                    return Context.GetCollection<Customer>("customers").Find(x => x.Name == name).FirstOrDefault();
                });
            };


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


        [HttpPost("createAsync")]
        public async void PostAsync(string fileName, Customer customer)
        {

            await CreateCustomerAsync(fileName, customer).ConfigureAwait(false);
           
        }


        private Task CreateCustomerAsync(string fileName, Customer customer)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
                return Task.Run(() => {

                    var customers = Context.GetCollection<Customer>("customers");
                    customers.Insert(customer);
                    customers.EnsureIndex(x => x.Name);
                });
            };

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

       

        [HttpPut("editAsync")]
        public async void PutAsync(string fileName, Customer customer)
        {
            
            await EditCustomerAsync(fileName, customer).ConfigureAwait(false);

        }

        private Task EditCustomerAsync(string fileName, Customer customer)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
                return Task.Run(() => {

                    var customers = Context.GetCollection<Customer>("customers");
                    customers.Update(customer);
                });
            };

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

        [HttpDelete("deleteAsync")]
        public async void DeleteAsync(string fileName, int id)
        {

            await DeleteCustomerAsync(fileName, id).ConfigureAwait(false);

        }
        private Task DeleteCustomerAsync(string fileName, int id)
        {
            using (var Context = new LiteDatabase(@fileName))
            {
                return Task.Run(() => {

                    var customers = Context.GetCollection<Customer>("customers");
                    customers.Delete(id);
                });
            };

        }
    }
}
