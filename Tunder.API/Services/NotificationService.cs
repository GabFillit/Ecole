using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonCode.Code.Builders;
using CommonCode.Messages;
using CommonCode.Messages.ViewModels;
using Data.Model;
using Tunder.API.Services;

namespace Tunder.API.Services
{
    public class NotificationService : INotificationService
    {
        public async Task<bool> SendWelcomeMessageAsync(User user)
        {
            var confirmEmail = new MessageBuilder<WelcomeMessage>(user, WelcomeMessage.From(user))
                .SendAsEmail("title")
                .GetInstance();

            return await Task.Run(() => true);
        }

        public async Task<bool> SendResetPasswordAsync(User user)
        {
            var confirmEmail = new MessageBuilder<WelcomeMessage>(user, WelcomeMessage.From(user))
                .SendAsEmail("title")
                .GetInstance();
            
            return await Task.Run(() => true);
        }
    }
}
