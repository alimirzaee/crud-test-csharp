using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Common
{
    public class PhoneNumberValidatorClass
    {

        public static string formatPhoneNumber(string phoneNum, string phoneFormat=null)
        {

            if (phoneFormat == "")
            {
                // If phone format is empty, code will use default format (###) ###-####
                phoneFormat = "+(##)###-###-####";
            }

            // First, remove everything except of numbers
            Regex regexObj = new Regex(@"[^\d]");
            phoneNum = regexObj.Replace(phoneNum, "");

            // Second, format numbers to phone string
            if (phoneNum.Length > 0)
            {
                phoneNum = Convert.ToInt64(phoneNum).ToString(phoneFormat);
            }

            return phoneNum;
        }


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
