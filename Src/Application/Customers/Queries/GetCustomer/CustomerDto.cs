using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Queries.GetCustomer
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.DateOfBirth, opt => opt.MapFrom(c => c.DateOfBirth.ToShortDateString()));
        }

    }
}
