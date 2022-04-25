using Mc2.CrudTest.Presentation.Shared.CustomValidators;
using Mc2.CrudTest.Shared.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Models
{
	public class Customer
	{

        public int Id { get; set; }

		[Required]
		[StringLength(50,ErrorMessage ="Name lenght is not vailid", MinimumLength =2)]

		public String Name { get; set; }


		[Required]
		[StringLength(50, ErrorMessage = "First Name lenght is not vailid", MinimumLength = 2)]

		public String Firstname { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Last lenght is not vailid", MinimumLength = 2)]

		public String Lastname { get; set; }
		public String DateOfBirth { get; set; }

		///[PhoneNumberValidator]
		public String PhoneNumber { get; set; }

		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
		public String Email { get; set; }

		[AccountNumberValidator]
		public string BankAccountNumber { get; set; }
	}
}
