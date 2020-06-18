using Application.Customers.Command.UpsertCustomer;
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
    public class UpsertCustomerCommandTest : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenExistCustomer_SholudBeWithOutExceptionAsync()
        {
            var command = new UpsertCustomerCommandHandler(_context);

            var existCustomer = new UpsertCustomerCommand() { Id = 1 , FirstName = "saji2", LastName = "Rei", DateOfBirth = "18/06/2000", BankAccountNumber = "sadasd", Email = "saji@cc.cc", PhoneNumber = "+989399158667"  };

            var result = await command.Handle(existCustomer, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async Task Handle_GivenNewCustomer_SholudBeWithOutExceptionAsync()
        {
            var command = new UpsertCustomerCommandHandler(_context);

            var newCustomer = new UpsertCustomerCommand()
            {
                FirstName = "saji2",
                LastName = "rei2",
                DateOfBirth = "20/10/1990",
                Email = "saji2@cc.cc",
                PhoneNumber = "12345678/9",
                BankAccountNumber = "544"
            };

            var result = await command.Handle(newCustomer, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }
    }
}
