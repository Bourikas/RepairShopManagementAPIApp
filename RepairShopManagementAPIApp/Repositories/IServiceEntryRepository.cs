using RepairShopManagementAPIApp.Data;

namespace RepairShopManagementAPIApp.Repositories
{
    public interface IServiceEntryRepository
    {
        Task<List<ServiceEntry>> GetServiceEntryByIsReturnedAsync(bool isReturned);
        Task<List<ServiceEntry>> GetServiceEntryByIsFinishedAsync(bool isFinished);
        Task<List<ServiceEntry>> GetAllServiceEntriesAsync();
        Task<List<ServiceEntry>> GetAllServiceEntriesAsync(int pageNumber, int PageSize);

    }
}
