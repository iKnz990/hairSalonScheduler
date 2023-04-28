using hairSalonScheduler.Models;
using System.Linq;
using System.Collections.Generic;
using hairSalonScheduler.Models.Enum;
using System;

namespace hairSalonScheduler.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SalonDbContext _context;

        public CustomerService(SalonDbContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == customerId);
        }
    }
}