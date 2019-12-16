using System;
using System.Collections.Generic;

namespace CeloTest
{
    public interface ICustomerFunctions
    {
        List<ICustomer> TopCustomers(int count);

        List<ICustomer> ReturnTopCustomerSearchBased(string firstOrLastName, int count);

        ICustomer CustomerById(int id);

        ICustomer CustomerByName(string fullName);

        ICustomer UpdateCustomer(ICustomer customer);

        List<ICustomer> DeleteCustomerById(int id);
    }
}
