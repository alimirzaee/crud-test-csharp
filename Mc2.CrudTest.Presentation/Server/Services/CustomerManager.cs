using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.Interfaces;
using Mc2.CrudTest.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Services
{



    public class CustomerManager : ICustomer
    {
        readonly DatabaseContext _dbContext = new();
        public CustomerManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all Customer details
        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                var cs = await _dbContext.Customers.ToListAsync();
                return cs;
            }
            catch
            {
                throw;
            }

            return new List<Customer>();
        }
        //To Add new Customer record
        public void AddCustomer(Customer Customer)
        {
            try
            {
               _dbContext.Customers.Add(Customer);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //To Update the records of a particluar Customer
        public void UpdateCustomerDetails(Customer Customer)
        {
            try
            {
                _dbContext.Entry(Customer).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular Customer
        public Customer GetCustomerData(int id)
        {
            try
            {
                Customer? Customer = _dbContext.Customers.Find(id);
                if (Customer != null)
                {
                    return Customer;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular Customer
        public void DeleteCustomer(int id)
        {
            try
            {
                Customer? Customer = _dbContext.Customers.Find(id);
                if (Customer != null)
                {
                    _dbContext.Customers.Remove(Customer);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }



        public async Task<bool> FindCustomer(Customer customer)
        {
            try
            {
                Customer? Customer = await _dbContext.Customers.SingleOrDefaultAsync(x => x.Name.Equals(customer.Firstname) && x.Lastname.Equals(customer.Lastname) && x.DateOfBirth.Equals(customer.DateOfBirth));

                if (Customer == null)
                {
                    await _dbContext.Customers.SingleOrDefaultAsync(x => x.Email.Equals(customer.Email));
                }
                if (Customer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false; // must be checked later
            }
            return false;
        }
    }
}
