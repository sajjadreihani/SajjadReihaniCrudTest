using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IPhoneValidation
    {
        bool IsValidateNumber(string number);
        bool IsMobileNumber(string number);
    }
}
