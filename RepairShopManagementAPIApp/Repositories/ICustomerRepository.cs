using RepairShopManagementAPIApp.Data;

namespace RepairShopManagementAPIApp.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer?>> GetByPhoneNumber(string? phoneNumber);
        Task<List<Device>> GetCustomersDevicesAsync(int id);
        Task<List<Device>> GetAllCustomersDevicesAsync(int pageNumber, int pageSize); //for pagination
        Task<List<Customer?>> GetCustomerByFirstname(string firstname);
        Task<List<Customer?>> GetCustomerByLastname(string lastname);

    }
}
