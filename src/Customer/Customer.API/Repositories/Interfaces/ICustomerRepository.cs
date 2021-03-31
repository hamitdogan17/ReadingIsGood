using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Entities.Customer>> GetCustomers();
        Task<Entities.Customer> GetCustomerByMail(string mail);
        Task<bool> CreateCustomer(Entities.Customer customer);
        Task<bool> UpdateCustomer(Entities.Customer customer);
        Task<bool> DeleteCustomer(int id);
    }
}
