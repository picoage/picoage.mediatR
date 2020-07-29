using MediatR;
using Picoage.MediatR.Application.Interfaces.Repositories;
using Picoage.MediatR.Application.Models.ResposeModels;
using Picoage.MediatR.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Picoage.MediatR.Application.Queries.Handlers
{
    public class CustomerQueryHandler : IRequestHandler<CustomerQuery, CustomerResponse>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<CustomerResponse> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await customerRepository.GetById(request.Id);
            return MapToResponse(customer);
        }

        private CustomerResponse MapToResponse(Customer customer)
        {
            return new CustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName };
        }

    }
}
