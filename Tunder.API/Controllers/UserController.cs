using System;
using System.Threading.Tasks;
using AutoMapper;
using Data.BusinessObject.DTO;
using Data.Model;
using Data.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tunder.Code.Extensions;

namespace Tunder.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper _mapper)
        {
            _userRepository = userRepository;
            this._mapper = _mapper;
        }

        [AllowAnonymous]
        [HttpGet("isUsernameAvailable/{username}")]
        public async Task<IActionResult> IsUsernameAvailable(string username)
        {
            bool isAvailable = await _userRepository.UsernameExistsAsync(username);

            return Ok(new
            {
                isAvailable
            });
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {

            Guid userId = this.GetUserId();

            User user = await _userRepository.GetByGuidAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<UserResponseDto>(user);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long userId)
        {
            User user = await _userRepository.GetById(userId);

            if (user == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<UserResponseDto>(user);

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("isEmailAvailable/{username}")]
        public async Task<IActionResult> IsEmailAvailable(string email)
        {
            bool isAvailable = await _userRepository.UserEmailExistsAsync(email);

            return Ok(new
            {
                isAvailable
            });
        }
    }
}