using Application.Common.Models;
using Application.Customers.Queries.GetCustomers;
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
    public class GetCustomersQueryTest
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCustomers()
        {
            var sut = new GetCustomersQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomersQuery { PageNumber = 0, RowCount=10 }, CancellationToken.None);

            result.ShouldBeOfType<PaggingData<CustomersDto>>();
            result.ShouldNotBeNull();
        }

    }
}
