using Microsoft.EntityFrameworkCore;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Infrastructure.Domain.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserAccessContext _userAccessContext;

        public UserRepository(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }

        public async Task AddAsync(User user)
        {
            await _userAccessContext.AddAsync(user);    
        }

        public async Task<int> Commit()
        {
            return await _userAccessContext.SaveChangesAsync();
        }

        public void DeleteUser(User user)
        {
            _userAccessContext.Users.Remove(user);
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _userAccessContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

      

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userAccessContext.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
      
        public void UpdateUser(User user)
        {
            _userAccessContext.Users.Update(user);
        }
    }
}
