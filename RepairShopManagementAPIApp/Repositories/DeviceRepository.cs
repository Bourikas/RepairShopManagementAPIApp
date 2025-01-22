using Microsoft.EntityFrameworkCore;
using RepairShopManagementAPIApp.Data;
using RepairShopManagementAPIApp.Models;

namespace RepairShopManagementAPIApp.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(RepairShopManagementAPIDbContext context) : base(context)
        {
        }

        public async Task<List<ServiceEntry>> GetAllDevicesServiceEntriesAsync(int pageNumber, int pageSize)
        {
            int skip = pageSize * pageNumber;
            List<ServiceEntry> serviceEntries;
            serviceEntries = await _context.Devices
                .SelectMany(c => c.ServiceEntries).Skip(skip).Take(pageSize)
                .ToListAsync();
            return serviceEntries;
        }

        public async Task<List<Device>> GetDevicesByDeviceTypeAsync(DeviceType deviceType)
        {
            return await _context.Devices.Where(s => s.DeviceType == deviceType).ToListAsync();
        }

        public async Task<Device?> GetDeviceBySerialNumberAsync(string? serialNumber)
        {
            return await _context.Devices.Where(s => s.SerialNumber == serialNumber).FirstOrDefaultAsync(); 
        }

        public async Task<List<ServiceEntry>> GetDevicesServiceEntriesAsync(int id)
        {
            List<ServiceEntry> serviceEntries;
            serviceEntries = await _context.Devices.Where(c => c.Id == id)
                .SelectMany(c => c.ServiceEntries)
                .ToListAsync();
            return serviceEntries;
        }
    }
}
