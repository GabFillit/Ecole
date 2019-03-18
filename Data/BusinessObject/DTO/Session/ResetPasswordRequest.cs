namespace Data.BusinessObject.DTO.Session
{
    public class ResetPasswordRequest
    {
        public string email { get; set; }
        public string resetToken { get; set; }
        public string password { get; set; }
    }
}