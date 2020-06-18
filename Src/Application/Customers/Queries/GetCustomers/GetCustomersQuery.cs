using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<PaggingData<CustomersDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int PageNumber { get; set; }
        public int RowCount { get; set; }
    }
}
