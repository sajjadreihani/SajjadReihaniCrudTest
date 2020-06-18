using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Command.UpsertCustomer
{
    public class UpsertCustomerCommandHandler : IRequestHandler<UpsertCustomerCommand>
    {
        private readonly IAppDbContext context;

        public UpsertCustomerCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpsertCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer;

            if(request.Id > 0)
            {
                customer = await context.Customers.FirstAsync(c => c.Id == request.Id);
            }
            else
            {
                customer = new Customer();

                context.Customers.Add(customer);
            }

            customer.BankAccountNumber = request.BankAccountNumber;
            customer.DateOfBirth = DateTime.Parse(request.DateOfBirth);
            customer.Email = request.Email;
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.PhoneNumber = request.PhoneNumber;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
