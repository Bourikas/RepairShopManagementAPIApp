using RepairShopManagementAPIApp.Data;
using RepairShopManagementAPIApp.Models;

namespace RepairShopManagementAPIApp.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device?> GetDeviceBySerialNumberAsync(string?  serialNumber);
        Task<List<Device>> GetDevicesByDeviceTypeAsync(DeviceType deviceType);
        Task<List<ServiceEntry>> GetDevicesServiceEntriesAsync(int id);
        Task<List<ServiceEntry>> GetAllDevicesServiceEntriesAsync(int pageNumber, int pageSize); //for pagination
    }
}
