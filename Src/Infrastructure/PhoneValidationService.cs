using Application.Common.Interfaces;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class PhoneValidationService : IPhoneValidation
    {
        private readonly PhoneNumberUtil phoneNumberUtil;

        public PhoneValidationService()
        {
            phoneNumberUtil = PhoneNumberUtil.GetInstance();
        }

        public bool IsValidateNumber(string number)
        {
            return phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(number, null));
        }

        public bool IsMobileNumber(string number)
        {
            return phoneNumberUtil.GetNumberType(phoneNumberUtil.Parse(number, null)) == PhoneNumberType.MOBILE;
        }
    }
}
