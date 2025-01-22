using Microsoft.EntityFrameworkCore;
using RepairShopManagementAPIApp.Data;

namespace RepairShopManagementAPIApp.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepairShopManagementAPIDbContext context) : base(context)
        {
        }

        public async Task<List<Device>> GetCustomersDevicesAsync(int id)
        {
            List<Device> devices;
            devices = await _context.Customers.Where(c => c.Id == id)
                .SelectMany(c => c.Devices)
                .ToListAsync();
            return devices;
        }

        public async Task<List<Device>> GetAllCustomersDevicesAsync(int pageNumber, int pageSize)  //needs fix?
        {
            int skip = pageSize*pageNumber;
            List<Device> devices;
            devices = await _context.Customers
                .SelectMany(c => c.Devices).Skip(skip).Take(pageSize)
                .ToListAsync();
            return devices;

        }

        public async Task<List<Customer?>> GetByPhoneNumber(string? phoneNumber)
        {
            return await _context.Customers.Where(s => s.PrimaryPhone == phoneNumber || s.SecondaryPhone == phoneNumber).ToListAsync()!; //find customers by primary or secondary phone
        }

        public async Task<List<Customer?>> GetCustomerByFirstname(string firstname)
        {
            List<Customer> customers;
            customers = await _context.Customers.Where(s => s.Firstname == firstname).ToListAsync();
            return customers;
        }

        public async Task<List<Customer?>> GetCustomerByLastname(string lastname)
        {
            List<Customer> customers;
            customers = await _context.Customers.Where(s => s.Lastname == lastname).ToListAsync();
            return customers;
        }

    }
}
