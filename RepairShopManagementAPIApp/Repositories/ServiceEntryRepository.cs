using Microsoft.EntityFrameworkCore;
using RepairShopManagementAPIApp.Data;
using System.Linq;

namespace RepairShopManagementAPIApp.Repositories
{
    public class ServiceEntryRepository : BaseRepository<ServiceEntry>, IServiceEntryRepository
    {
        public ServiceEntryRepository(RepairShopManagementAPIDbContext context) : base(context)
        {
        }

        public async Task<List<ServiceEntry>> GetAllServiceEntriesAsync()
        {
            List<ServiceEntry> serviceEntries;
            serviceEntries = await _context.ServiceEntries.ToListAsync();
            return serviceEntries;
        }

        public async Task<List<ServiceEntry>> GetAllServiceEntriesAsync(int pageNumber, int pageSize)
        {
            int skip = pageNumber * pageSize;
            List<ServiceEntry> serviceEntries;
            serviceEntries = await _context.ServiceEntries.Skip(skip).Take(pageSize).ToListAsync();
            return serviceEntries;
        }

        public async Task<List<ServiceEntry>> GetServiceEntryByIsFinishedAsync(bool isFinished)
        {
            List<ServiceEntry> serviceEntries;
            serviceEntries = await _context.ServiceEntries.Where(s => s.IsFinished).ToListAsync();
            return serviceEntries;
        }

        public async Task<List<ServiceEntry>> GetServiceEntryByIsReturnedAsync(bool isReturned)
        {
            List<ServiceEntry> serviceEntries;
            serviceEntries = await _context.ServiceEntries.Where(s => s.IsReturned).ToListAsync();
            return serviceEntries;
        }
    }
}
