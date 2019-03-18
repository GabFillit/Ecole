using System;
using System.ComponentModel.DataAnnotations;
using Data.Model.Enums;

namespace Data.BusinessObject.Requests
{
    public class UserRegisterDto
    {
        [Required] public string UserName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }
        
        [Required] public Sexes Sexe { get; set; }
    }
}