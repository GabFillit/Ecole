using System.Reflection.Emit;
using Data.Model;

namespace CommonCode.Messages.ViewModels
{
    public class WelcomeMessage
    {
        public string Name { get; set; }

        public static WelcomeMessage From(User user)
        {
            return new WelcomeMessage
            {
                Name = user.UserName
            };
        } 
    }
}