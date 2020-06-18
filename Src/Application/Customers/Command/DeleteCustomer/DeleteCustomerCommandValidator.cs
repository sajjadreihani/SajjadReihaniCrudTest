using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        private readonly IAppDbContext context;

        public DeleteCustomerCommandValidator(IAppDbContext context)
        {
            this.context = context;
            RuleFor(i => i.Id).MustAsync(CustomerExist).WithMessage("Customer With this Id is not Exist");

        }

        private async Task<bool> CustomerExist(long arg1, CancellationToken arg2)
        {
            return await context.Customers.AnyAsync(c => c.Id == arg1);
        }
    }
}
