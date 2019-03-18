using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Data.BusinessObject.Requests;
using Data.Model;
using Data.Model.Enums;

namespace Data.Model
{
    public class User : ModelBase
    {
        public string UserName { get; set; }
        public Sexes Sex { get; set; }
        public string Email { get; set; }
        public DateTime BirthDateTime { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public string AuthToken { get; set; }
        public string ActivationToken { get; set; }
        public string ResetPasswordToken { get; set; }
        
        public ICollection<UserTeam> UserTeams { get; set; }


        public static User From(UserRegisterDto userDto, byte[] hashedPassword, byte[] salt)
        {
            return new User()
            {
                UserName = userDto.UserName,
                Sex = userDto.Sexe,
                Email = userDto.Email.ToLower(),
                HashedPassword = hashedPassword,
                Salt = salt,
                BirthDateTime = userDto.DateOfBirth
            };
        }
    }
}