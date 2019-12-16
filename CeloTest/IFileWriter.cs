using System;
using System.Collections.Generic;

namespace CeloTest
{
    public interface IFileWriter<T> where T: IEntity
    {
        bool IsFileExists();
        void WriteJson(T jsonData);
        void WriteJson(List<ICustomer> deletedCustomerList);
    }
}
