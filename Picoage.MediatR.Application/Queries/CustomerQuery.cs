using MediatR;
using Picoage.MediatR.Application.Models.ResposeModels;

namespace Picoage.MediatR.Application.Queries
{
    public class CustomerQuery:IRequest<CustomerResponse>
    {
        public int Id { get; }

        public CustomerQuery(int Id)
        {
            this.Id = Id; 
        }
    }
}
