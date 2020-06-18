using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Command.UpsertCustomer
{
    public class UpsertCustomerCommandValidator : AbstractValidator<UpsertCustomerCommand>
    {
        private readonly IAppDbContext context;
        private readonly IPhoneValidation phoneValidation;

        public UpsertCustomerCommandValidator(IAppDbContext context, IPhoneValidation phoneValidation)
        {
            this.context = context;
            this.phoneValidation = phoneValidation;

            When(i => i.Id > 0, () =>
            {
                RuleFor(i => i.Id).MustAsync(CustomerExist).WithMessage("Customer With this Id is not Exist");
            });

            RuleFor(i => i.FirstName).NotEmpty().WithMessage("First Name Is Required")
                .MaximumLength(50).WithMessage("First Name Must Be Less than 50 Characters");

            RuleFor(i => i.LastName).NotEmpty().WithMessage("Last Name Is Required")
                .MaximumLength(100).WithMessage("Last Name Must Be Less than 100 Characters");

            RuleFor(i => i.BankAccountNumber).NotEmpty().WithMessage(" Is Required")
                .MaximumLength(50).WithMessage("Bank Account Number Must Be Less than 50 Characters");

            RuleFor(i => i.Email).EmailAddress().WithMessage("Email Is Invalid")
                .MaximumLength(150).WithMessage("Email Must Be Less than 150 Characters");

            RuleFor(i => i.PhoneNumber).NotEmpty().WithMessage("Phone Number Is Required")
                .MaximumLength(15).WithMessage("Phone Number Must Be Less than 15 Characters")
                .Must(ValidPhoneNumber).WithMessage("Phone Number is Invalid");

            RuleFor(i => i.DateOfBirth).NotEmpty().WithMessage("Date of Birth Is Required")
                .Must(ValidDateTime).WithMessage("Date of Birth is Invalid");

            When(i => i.Id <= 0, () =>
            {
                RuleFor(i => i.Email).MustAsync(UniqueEmail).WithMessage("Email is already Exist");
                RuleFor(i => i.DateOfBirth).MustAsync(UniquePersonInfo).WithMessage("This Customer is Already Exist");

            });


        }

        private async Task<bool> UniquePersonInfo(UpsertCustomerCommand model, string arg1,  CancellationToken arg2)
        {
            DateTime dt = DateTime.Parse(arg1);

            return !await context.Customers.AnyAsync(c => c.DateOfBirth == dt && c.FirstName == model.FirstName && c.LastName == model.LastName, arg2);
        }

        private bool ValidDateTime(string arg1)
        {
            return DateTime.TryParse(arg1, out _);
        }

        private bool ValidPhoneNumber(string arg1)
        {
            return phoneValidation.IsMobileNumber(arg1) && phoneValidation.IsValidateNumber(arg1);
        }

        private async Task<bool> UniqueEmail(string arg1, CancellationToken arg2)
        {
            return !await context.Customers.AnyAsync(c => c.Email == arg1, arg2);
        }

        private async Task<bool> CustomerExist(long arg1, CancellationToken arg2)
        {
            return await context.Customers.AnyAsync(c => c.Id == arg1);
        }
    }
}
