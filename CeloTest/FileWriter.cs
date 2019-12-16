using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CeloTest
{
    public class FileWriter : IFileWriter<ICustomer>
    {
        private readonly string _pathToFile;
        public FileWriter()
        {
            _pathToFile = Environment.GetEnvironmentVariable("PathToFile");
        }

        public bool IsFileExists()
        {
            return !File.Exists(_pathToFile);
        }

        public void WriteJson(ICustomer customer)
        {
            try
            {
                if (IsFileExists())
                {
                    List<ICustomer> customerList = new List<ICustomer>();
                    customerList.Add(customer);
                    var jsonObject = JsonSerializer.Serialize(customerList);
                    // Create a file to write to.
                    File.WriteAllText(_pathToFile, jsonObject);
                }
                else
                {
                    CustomerFileReader reader = new CustomerFileReader();
                    var customerList = reader.EntityList();
                    customerList.Add(customer);
                    var jsonObject = JsonSerializer.Serialize(customerList);
                    //if the file already exists append to existing data
                    File.WriteAllText(_pathToFile, jsonObject);
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }

        }

        public void WriteJson(List<ICustomer> deletedCustomerList)
        {
            try
            {
                var jsonObject = JsonSerializer.Serialize(deletedCustomerList);
                File.WriteAllText(_pathToFile, jsonObject);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }

        }
    }
}
