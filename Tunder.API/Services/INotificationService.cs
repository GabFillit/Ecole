using CommonCode.Messages;
using System.Threading.Tasks;
using Data.Model;

namespace Tunder.API.Services
{
    public interface INotificationService
    {
        Task<bool> SendWelcomeMessageAsync(User user);
        Task<bool> SendResetPasswordAsync(User user);
    }
}