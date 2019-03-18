using Data.Model.Enums;

namespace Data.BusinessObject.DTO
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public Sexes Sex { get; set; }
        
    }
}