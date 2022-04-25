using Mc2.CrudTest.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Interfaces
{
    public interface ICustomer
    {
        public Task<List<Customer>> GetCustomers();
        public void AddCustomer(Customer Customer);
        public void UpdateCustomerDetails(Customer Customer);
        public Customer GetCustomerData(int id);
        public void DeleteCustomer(int id);

        public  Task<bool> FindCustomer(Customer customer);
    }
}
