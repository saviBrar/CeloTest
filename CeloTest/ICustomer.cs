using System;
namespace CeloTest
{
    public interface ICustomer : IEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        //DateTime DateOfBirth { get; set; }
        //long PhoneNumber { get; set; }
    }
}
