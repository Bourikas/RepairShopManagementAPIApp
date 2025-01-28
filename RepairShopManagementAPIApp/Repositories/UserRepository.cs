using Microsoft.EntityFrameworkCore;
using RepairShopManagementAPIApp.Data;
using RepairShopManagementAPIApp.Security;

namespace RepairShopManagementAPIApp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RepairShopManagementAPIDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllUsersFilteredAsync(int pageNumber, int pageSize, List<Func<User, bool>> predicates)
        {
            int skip = pageNumber * pageSize;
            IQueryable<User> query = _context.Users.Skip(skip).Take(pageSize);

            if (predicates != null && predicates.Any())
            {
                query = query.Where(u => predicates.All(predicate => predicate(u)));
            }

            return await query.ToListAsync();

        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetUserAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == username);
            if (user == null)
            {
                return null;
            }
            if (!EncryptionUtil.IsValidPassword(password, user.Password)) //if NOT password is valid
            {
                return null;
            }
            return user;
        }

        public async Task<User?> UpdateUserAsync(int userId, User user)
        {
            var existingUser = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

            if (existingUser == null) { return  null; }
            if (existingUser.Id != userId) { return null; }

            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;

            return existingUser;
        }
    }
}
