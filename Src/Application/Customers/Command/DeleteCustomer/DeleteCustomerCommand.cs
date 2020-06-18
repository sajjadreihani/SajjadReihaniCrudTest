using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public long Id { get; set; }
    }
}
