using Application.Customers.Queries.GetCustomer;
using Application.UnitTest.Common;
using AutoMapper;
using Persistences;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerQueryTest
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCustomerByExistCustomerId()
        {
            var sut = new GetCustomerQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomerQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<CustomerDto>();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetCustomerByNotExistCustomerId()
        {
            var sut = new GetCustomerQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomerQuery { Id = 2 }, CancellationToken.None);

            result.ShouldBeNull();
        }


    }
}
