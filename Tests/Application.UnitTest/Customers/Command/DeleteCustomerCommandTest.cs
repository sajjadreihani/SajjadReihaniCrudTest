using Application.Customers.Command.DeleteCustomer;
using Application.UnitTest.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Customers.Command
{
    public class DeleteCustomerCommandTest : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenExistCustomer_SholudBeWithOutExceptionAsync()
        {
            var command = new DeleteCustomerCommandHandler(_context);

            var existCustomer = new DeleteCustomerCommand() { Id = 1};

            var result = await command.Handle(existCustomer, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }


    }
}
