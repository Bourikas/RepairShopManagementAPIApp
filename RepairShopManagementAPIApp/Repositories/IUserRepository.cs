using RepairShopManagementAPIApp.Data;

namespace RepairShopManagementAPIApp.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string username, string password);
        Task<User?> UpdateUserAsync(int userId, User user);
        Task<User?> GetByEmailAsync(string username);
        Task<List<User>> GetAllUsersFilteredAsync(int pageNumber, int pageSize, List<Func<User, bool>> predicates);
    }
}
