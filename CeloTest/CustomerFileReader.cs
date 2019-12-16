using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
//using System.Text.Json;

namespace CeloTest
{
    public class CustomerFileReader : IFileReader<ICustomer>
    {
        private readonly string _pathToFile;
        public CustomerFileReader()
        {
            _pathToFile = Environment.GetEnvironmentVariable("PathToFile");
        }
        public List<ICustomer> EntityList()
        {
            try
            {
                var customerList = new List<ICustomer>();
                using (StreamReader readFile = new StreamReader(_pathToFile))
                {
                    string json = readFile.ReadToEnd();
                    customerList = JsonConvert.DeserializeObject<List<ICustomer>>(json);
                }
                return customerList;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

