using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CeloTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private IFileWriter<ICustomer> _fileWriter;
        //private ICustomerFunctions _customerFunctions;

        public CustomerController()
        {
            _fileWriter = new FileWriter();
            //_customerFunctions = new CustomerFunctions();
            
        }
        // GET: api/values
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Customer> Get(int id)
        {
            try
            {
                var customerFunctions = new CustomerFunctions();
                var customer = customerFunctions.CustomerById(id);
                return Ok(customer);
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        // GET api/values/5
        [HttpGet("{count}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ICustomer>> GetTop(int count)
        {
            try
            {
                var customerFunctions = new CustomerFunctions();
                var customerList = customerFunctions.TopCustomers(count);
                return Ok(customerList);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // GET api/values/5
        [HttpGet("{firstOrLastName}, {count}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ICustomer>> GetTop(string firstOrLastName, int count)
        {
            try
            {
                var customerFunctions = new CustomerFunctions();
                var customerList = customerFunctions.ReturnTopCustomerSearchBased(firstOrLastName, count);
                return Ok(customerList);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post(Customer customer)
        {
            try
            {
                _fileWriter.WriteJson(customer);
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Success")};
                
            }
            catch (ArgumentNullException ex)
            {
                return new HttpResponseMessage { Content = new StringContent(ex.Message) };

            }
            catch (JsonException ex)
            {
                return new HttpResponseMessage { Content = new StringContent(ex.Message) };
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage { Content = new StringContent(ex.Message) };
            }
         

        }

        [HttpPut]
        public ActionResult<Customer> Put(Customer customer)
        {
            try
            {
                var customerFunctions = new CustomerFunctions();
                var result = customerFunctions.CustomerById(customer.Id);
                result.FirstName = customer.FirstName;
                result.LastName = customer.LastName;
                result.Email = customer.Email;
                var deletedCustomerList = customerFunctions.DeleteCustomerById(customer.Id);
                _fileWriter.WriteJson(result);
                return Ok(result);

            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE api/values/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var customerFunctions = new CustomerFunctions();
                var deletedCustomerList = customerFunctions.DeleteCustomerById(id);
                _fileWriter.WriteJson(deletedCustomerList);
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Success") };

            }
            catch (ArgumentNullException ex)
            {
                return new HttpResponseMessage { Content = new StringContent(ex.Message) };
            }
        }
    }
}
