using System;
using System.Collections.Generic;
using System.Linq;

namespace CeloTest
{
    public class CustomerFunctions : ICustomerFunctions
    {
        private IFileReader<ICustomer> _fileReader;
        private List<ICustomer> _customerList;

        public CustomerFunctions()
        {
            _fileReader = new CustomerFileReader();
            _customerList = _fileReader.EntityList();
        }

        public ICustomer CustomerById(int id)
        {
            try
            {
                return _customerList.Find(item => item.Id == id);
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public ICustomer CustomerByName(string fullName)
        {
            throw new NotImplementedException();
        }

        public List<ICustomer> DeleteCustomerById(int id)
        {
            try
            {
               return _customerList.Where(item => item.Id == id).ToList();
                
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ICustomer> ReturnTopCustomerSearchBased(string firstOrLastName, int count)
        {
            return _customerList.FindAll(item => item.FirstName == firstOrLastName || item.LastName == firstOrLastName).Take(count).ToList();
        }

        public List<ICustomer> TopCustomers(int count)
        {
            return _customerList.Take(count).ToList();
        }

        public ICustomer UpdateCustomer(ICustomer customer)
        {
            return _customerList.FirstOrDefault(item => item.Id == customer.Id);
            //update all properties to new one
            
        }
    }
}
