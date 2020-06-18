using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Command.UpsertCustomer
{
    public class UpsertCustomerCommand : IRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }
}
