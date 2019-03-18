using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.Model.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tunder.API.Services;

namespace Tunder.API.Tests.Services
{
    [TestClass]
    public class AuthServiceTest
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IThrottleService> _throttleService;

        [TestInitialize]
        public void Init()
        {
            _userRepository = new Mock<IUserRepository>();
            _throttleService = new Mock<IThrottleService>();
        }

        public AuthService GetService()
        {
            return new AuthService(_userRepository.Object, _throttleService.Object);
        }




        #region Login

        [TestMethod]
        public async Task LoginMissingEmailWillReturnNull()
        {
            User user = null;

            _userRepository.Setup(u => u.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(user);

            var service = GetService();

            var result = await service.LoginAsync("email", "password");

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public async Task LoginIsThrottled()
        {
            User user = new User();

            _userRepository.Setup(u => u.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(user);

            _throttleService.Setup(t => t.GetFailLoginAttemptAsync(It.IsAny<User>()))
                .ReturnsAsync(5);

            var service = GetService();

            var result = await service.LoginAsync("email", "password");

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public async Task LoginFail_will_LogFail()
        {
            User user = new User();
            user.HashedPassword = new byte[2];
            user.Salt = new byte[3];

            _userRepository.Setup(u => u.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(user);

            _throttleService.Setup(t => t.GetFailLoginAttemptAsync(It.IsAny<User>()))
                .ReturnsAsync(0);

            var service = GetService();

            var result = await service.LoginAsync("email", "password");

            _throttleService.Verify(t => t.LogFailLoginAttemptAsync(It.IsAny<User>()), Times.Once);

            Assert.AreEqual(null, result);
        }

        #endregion

    }
}
