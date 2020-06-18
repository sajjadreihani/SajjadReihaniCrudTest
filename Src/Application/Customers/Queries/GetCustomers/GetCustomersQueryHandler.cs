using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, PaggingData<CustomersDto>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetCustomersQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaggingData<CustomersDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var output = new PaggingData<CustomersDto>();

            output.List = await context.Customers.Where(c => (string.IsNullOrEmpty(request.Name) || (c.FirstName + " " + c.LastName).Contains(request.Name))
            && (string.IsNullOrEmpty(request.Email) || c.Email.Contains(request.Email))
            && (string.IsNullOrEmpty(request.PhoneNumber) || c.PhoneNumber.Contains(request.PhoneNumber)))
                .OrderByDescending(c => c.Id).Skip(request.PageNumber * request.RowCount).Take(request.RowCount)
                .ProjectTo<CustomersDto>(mapper.ConfigurationProvider).AsNoTracking().ToListAsync(cancellationToken);

            output.TotalLength = await context.Customers.Where(c => (string.IsNullOrEmpty(request.Name) || (c.FirstName + " " + c.LastName).Contains(request.Name))
            && (string.IsNullOrEmpty(request.Email) || c.Email.Contains(request.Email))
            && (string.IsNullOrEmpty(request.PhoneNumber) || c.PhoneNumber.Contains(request.PhoneNumber))).CountAsync(cancellationToken);

            return output;
        }
    }
}
