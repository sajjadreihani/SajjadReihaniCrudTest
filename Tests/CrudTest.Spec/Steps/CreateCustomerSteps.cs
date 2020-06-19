using Application.Customers.Command.UpsertCustomer;
using Application.Customers.Queries.GetCustomers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using Moq;
using System.Threading;
using Application.Common.Models;

namespace CrudTest.Spec.Steps
{
    [Binding]
    public class CreateCustomerSteps
    {
        private readonly IMediator mediator;
        private UpsertCustomerCommand upsertCustomer { get; set; }
        private Unit result { get; set; }

        public CreateCustomerSteps(IMediator mediator)
        {
            this.mediator = mediator;            
        }

        [Given(@"We have the following entries")]
        public void GivenWeHaveTheFollowingEntries(Table table)
        {
            upsertCustomer = new UpsertCustomerCommand();
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }

            upsertCustomer.BankAccountNumber = dictionary["BankAccountNumber"];
            upsertCustomer.DateOfBirth = dictionary["DateOfBirth"];
            upsertCustomer.Email = dictionary["Email"];
            upsertCustomer.FirstName = dictionary["FirstName"];
            upsertCustomer.LastName = dictionary["LastName"];
            upsertCustomer.PhoneNumber = dictionary["PhoneNumber"];


        }
        
        [When(@"I posted data")]
        public async System.Threading.Tasks.Task WhenIPostedDataAsync()
        {
            await mediator.Send(upsertCustomer);
        }
        
        [Then(@"I get an Unit result")]
        public void ThenIGetAnUnitResult()
        {
            Assert.IsType<Unit>(result);
        }
        
        [Then(@"there is one result with Email test@test\.cc")]
        public async System.Threading.Tasks.Task ThenThereIsOneResultWithEmailAsync()
        {
            var customers = await mediator.Send(new GetCustomersQuery()
            {
                Email = "test@test.cc",
                PageNumber = 0,
                RowCount = 10
            });

            Assert.Equal(1, customers.TotalLength);
        }
    }
}
