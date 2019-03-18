using Data.Model;

namespace CommonCode.Messages.ViewModels
{
    public class ResetPassword
    {
        public string Name { get; set; }

        public static ResetPassword From(User user)
        {
            return new ResetPassword
            {
                Name = user.UserName
            };
        }
    }
}