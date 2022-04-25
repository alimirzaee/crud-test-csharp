using Mc2.CrudTest.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Mc2.CrudTest.Domain.Generators;
using Mc2.CrudTest.Presentation.Server.Services;
using Mc2.CrudTest.Presentation.Server.Interfaces;
using System.Threading.Tasks;
using Mc2.CrudTest.Shared.Models;
using System;
using Microsoft.AspNetCore.Http;
using Mc2.CrudTest.Presentation.Shared.CustomValidators;
using Mc2.CrudTest.Shared.Common;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _ICustomer;
        public CustomersController(ICustomer iCustomer)
        {
            _ICustomer = iCustomer;
        }
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await _ICustomer.GetCustomers();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer Customer = _ICustomer.GetCustomerData(id);
            if (Customer != null)
            {
                return Ok(Customer);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Customer Customer)
        {

            if (Customer == null)
            {
                return BadRequest();
            }

            string phoneNoCheckResult = PhoneNumberValidatorClass.IsValid(Customer.PhoneNumber.ToString());
            if (phoneNoCheckResult != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error: Phone Number is not valid!");
            }

             
            if ( await _ICustomer.FindCustomer(Customer))
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error: Customer or Email Exists!");
            }
            try
            {
              
                
                _ICustomer.AddCustomer(Customer);


                return Ok("Customer Added...");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Adding data to the database");
            }
           
        }



        [HttpPut]
        public void Put(Customer Customer)
        {
            _ICustomer.UpdateCustomerDetails(Customer);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ICustomer.DeleteCustomer(id);
            return Ok();
        }
    }
}
