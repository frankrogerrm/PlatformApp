using Microsoft.EntityFrameworkCore;
using PlatformApp.Service.DBContext;
using PlatformApp.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformApp.Service.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers( bool onlyActives = false );
    }
    public class CustomerService:ICustomerService
    {
        private readonly PlatformAppDBContext dbContext;
        public CustomerService( PlatformAppDBContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomers( bool onlyActives = false )
        {
            if (onlyActives)
            {
                return await dbContext.Customers.Where( x => x.Status ).ToListAsync();
            }
            else
            {
                return await dbContext.Customers.ToListAsync();
            }
        }
    }
}
