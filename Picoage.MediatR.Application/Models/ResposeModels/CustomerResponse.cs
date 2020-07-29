using System;
using System.Collections.Generic;
using System.Text;

namespace Picoage.MediatR.Application.Models.ResposeModels
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
