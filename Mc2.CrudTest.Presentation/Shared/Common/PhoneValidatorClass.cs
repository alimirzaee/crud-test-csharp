using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Common
{
    public class PhoneNumberValidatorClass
    {
        public static string IsValid(string number)
        {

            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            try
            {
                PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(number, "+92");

                bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber);

                if (number == null || number.Length < 9 || !isValidNumber)
                {
                    return "Phone Number is not valid!";
                }
            }
            catch (Exception ex)
            {
                return "Phone Number is not valid!";

            }
            return null;
        }
    }

}
