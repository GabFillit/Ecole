using Data.BusinessObject.DTO;
using Data.Model;

namespace Data.BusinessObject.Profile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();
        }
        
    }
}