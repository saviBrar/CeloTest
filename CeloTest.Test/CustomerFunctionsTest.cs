using System;
using System.Net.Http;
using CeloTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CeloTest.Test
{
    [TestFixture]
    public class CustomerFunctionsTest
    {
        [Test]
        public void create_customer()
        {
            var controller = new CustomerController();
            var customer = GetDemoCustomer();
            var response = controller.Post(customer);
            Assert.AreEqual(response.Content, "Success");
        }

        [TestCase(1)]
        public void get_customer_by_id(int id)
        {
            var controller = new CustomerController();
            var customer = GetDemoCustomer();
            controller.Post(customer);
            var response = controller.Get(id);
            Assert.AreEqual(customer.Id, response.Value.Id);
                
        }

        [TestCase(10)]
        public void top_customers(int count)
        {
            var controller = new CustomerController();
          
            var response = controller.GetTop(count);
           
            Assert.AreEqual(response.Value.Count, count);
        }


        [TestCase("savi", 10)]
        public void top_customers(string firstOrLastName, int count)
        {
            CustomerController controller = new CustomerController();

            var response = controller.GetTop(count);

            Assert.AreEqual(response.Value.Count, count);
        }


        Customer GetDemoCustomer()
        {
            return new Customer() { Id = 1, Email = "savjotsingh@live.com", FirstName = "Savi", LastName = "Singh" };
        }
    }
}
