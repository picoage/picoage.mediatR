using MediatR;
using Picoage.MediatR.Application.Models.RequestModels;
using Picoage.MediatR.Application.Models.ResposeModels;

namespace Picoage.MediatR.Application.Commands
{
    public class CustomerCommand: IRequest<CustomerResponse>
    {
        public CustomerRequest customerRequest { get; set; }
        
        public CustomerCommand(CustomerRequest customerRequest)
        {
            this.customerRequest = customerRequest;
        }
    }
}
