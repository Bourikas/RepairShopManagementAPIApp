using RepairShopManagementAPIApp.Data;
using RepairShopManagementAPIApp.DTO;
using RepairShopManagementAPIApp.Models;

namespace RepairShopManagementAPIApp.Services
{
    public interface IUserService
    {
        Task<User?> SignupUserAsync(UserSignupDTO request);
        Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials);
        Task<User?> UpdateUserAsync(int userId, UserDTO request);
        Task<User?> UpdateUserPatchAsync(int userId, UserPatchDTO request);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO);
        string CreateUserToken(int userId, string? email, UserRole? userRole, string? appSequrityKey);
        Task<User?> DeleteUserAsync(int userId);
    }
}
