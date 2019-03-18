using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Data.Model.DbContext;

namespace Data.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TunderDbContext _dbContext;

        public UserRepository(TunderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<User> GetById(long id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByGuidAsync(Guid guid)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Guid == guid);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<bool> UserEmailExistsAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email == email);
        }

        public async Task<bool> UsernameExistsAsync(string userName)
        {
            return await _dbContext.Users.AnyAsync(user => user.UserName == userName);

        }

        public async Task<User> CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return user;
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 1;
        }
    }
}