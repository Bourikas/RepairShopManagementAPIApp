using AutoMapper;
using RepairShopManagementAPIApp.Data;
using RepairShopManagementAPIApp.DTO;
using RepairShopManagementAPIApp.Models;

namespace RepairShopManagementAPIApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork
        private readonly ILogger<UserService> _logger;
        private readonly IMapper? mapper;
        public string CreateUserToken(int userId, string? email, UserRole? userRole, string? appSequrityKey)
        {
            throw new NotImplementedException();
        }

        public Task<User?> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> SignupUserAsync(UserSignupDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUserAsync(int userId, UserDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUserPatchAsync(int userId, UserPatchDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials)
        {
            throw new NotImplementedException();
        }
    }
}
