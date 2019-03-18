using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public interface IUserRepository : IModelBaseEntityRepository
    {
        Task<User> GetByEmail(string email);
        Task<bool> UserEmailExistsAsync(string email);
        Task<bool> UsernameExistsAsync(string userName);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
    }
}