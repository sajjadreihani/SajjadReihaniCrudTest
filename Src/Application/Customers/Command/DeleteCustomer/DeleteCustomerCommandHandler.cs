using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IAppDbContext context;

        public DeleteCustomerCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            context.Customers.RemoveRange(context.Customers.Where(c => c.Id == request.Id));

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
