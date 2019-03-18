using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Model;
using Data.Model.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Tunder.API.Controllers
{
    public abstract class BaseAuthController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;

        public BaseAuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetCurrentUser()
        {
            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return await _userRepository.GetById(currentUserId);
        }
    }
} 