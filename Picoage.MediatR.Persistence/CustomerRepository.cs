using Picoage.MediatR.Application.Interfaces.Repositories;
using Picoage.MediatR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Picoage.MediatR.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        static List<Customer> customers = new List<Customer>();

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Task.FromResult(new List<Customer> { new Customer { FirstName = "*****", LastName = "******", UserName = "*******", Password = "******" } });
        }

        public async Task<Customer> GetById(int id)
        {
            return await Task.Run(() => customers.SingleOrDefault(c => c.Id == id));
        }

        public async Task<Customer> Insert(Customer entity)
        {
            await Task.Run(() => customers.Add(entity));
            return entity; 
        }

        public Task Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
