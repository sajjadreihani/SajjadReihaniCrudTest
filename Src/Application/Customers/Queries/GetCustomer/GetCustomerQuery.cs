using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerDto>
    {
        public long Id { get; set; }
    }
}
