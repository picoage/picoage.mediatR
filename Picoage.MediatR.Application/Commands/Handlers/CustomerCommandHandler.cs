using MediatR;
using Picoage.MediatR.Application.Interfaces.Repositories;
using Picoage.MediatR.Application.Models.ResposeModels;
using Picoage.MediatR.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Picoage.MediatR.Application.Commands.Handlers
{
    public class CustomerCommandHandler : IRequestHandler<CustomerCommand, CustomerResponse>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerResponse> Handle(CustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await customerRepository.Insert(MapToDomain(request));
            return MapToResponse(customer); 
        }

        private Customer MapToDomain(CustomerCommand request)
        {
            return new Customer { Id=request.customerRequest.Id, FirstName = request.customerRequest.FirstName, LastName = request.customerRequest.LastName };
        }

        private CustomerResponse MapToResponse(Customer customer)
        {
            return new CustomerResponse { Id =customer.Id, FirstName = customer.FirstName, LastName = customer.LastName };
        }
    }
}
