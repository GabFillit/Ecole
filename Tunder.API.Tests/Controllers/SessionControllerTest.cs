using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Data.BusinessObject.DTO.Session;
using Data.BusinessObject.Requests;
using Data.Model.Repository;
using Tunder.API.Controllers;
using Tunder.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SQLitePCL;
using Tunder.API.Tests.TestHelpers;

namespace Tunder.API.Tests.Controllers
{
    [TestClass]
    public class SessionControllerTest
    {
        private Mock<IAuthService> _authServiceMock;
        private Mock<IUserRepository> _userRepoMock;
        private Mock<IConfiguration> _config;
        private Mock<INotificationService> _notificationServiceMock;

        [TestInitialize]
        public void Init()
        {
            _authServiceMock = new Mock<IAuthService>();
            _userRepoMock = new Mock<IUserRepository>();
            _config = new Mock<IConfiguration>();
            _notificationServiceMock = new Mock<INotificationService>();
        }

        #region LOGIN

        [TestMethod]
        public async Task MissingUserReturns401Async()
        {
            User user = null;

            _authServiceMock.Setup(authS => authS.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(user);

            var controller = GetController();


            var loginResult = await controller.Login(new LoginDto());

            Assert.IsInstanceOfType(loginResult, typeof(UnauthorizedResult));
        }

        [TestMethod]
        public async Task LoginOk()
        {
            User user = new User();
            _authServiceMock.Setup(authS => authS.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(user);

            var controller = GetController();
            controller.SetUserClaimId(Guid.NewGuid());

            var loginResult = await controller.Login(new LoginDto());

            Assert.IsInstanceOfType(loginResult, typeof(OkObjectResult));
        }

        #endregion

        #region REGISTER!

        [TestMethod]
        public async Task UserAlreadyExists()
        {
            _userRepoMock.Setup(userRepo => userRepo.UserEmailExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            var controller = GetController();

            var registerResult = await controller.Register(new UserRegisterDto() {Email = "bonjourMadame"});
            Assert.IsInstanceOfType(registerResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task UserSendUpperCaseEmail()
        {
            var lowEmail = "yolo@lol.com";
            var upperEmail = "YoLo@lol.com";

            _userRepoMock.Setup(userRepo => userRepo.UserEmailExistsAsync(lowEmail))
                .ReturnsAsync(true);

            _userRepoMock.Setup(userRepo => userRepo.UserEmailExistsAsync(upperEmail))
                .ReturnsAsync(false);

            var controller = GetController();

            var userDto = new UserRegisterDto
            {
                Email = upperEmail
            };

            var registerResult = await controller.Register(userDto);
            Assert.IsInstanceOfType(registerResult, typeof(BadRequestResult));
        }

        #endregion

        #region RESET_PASSWORD

        [TestMethod]
        public async Task MissingUser_404()
        {
            User nullUser = null;

            _userRepoMock.Setup(repo => repo.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(nullUser);

            var controller = GetController();

            var req = new ResetPasswordRequest();

            var result = await controller.ResetPassword(req);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task BadResetToken_BadRequest()
        {
            User user = new User();

            _userRepoMock.Setup(repo => repo.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(user);

            _authServiceMock.Setup(repo => repo.ResetPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(false);

            var controller = GetController();

            var req = new ResetPasswordRequest();

            var result = await controller.ResetPassword(req);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task GoodResetPassword_Ok()
        {
            User user = new User();

            _userRepoMock.Setup(repo => repo.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(user);

            _authServiceMock.Setup(repo => repo.ResetPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            var controller = GetController();

            var req = new ResetPasswordRequest();

            var result = await controller.ResetPassword(req);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        #endregion


        private SessionController GetController()
        {
            return new SessionController(_authServiceMock.Object, _userRepoMock.Object, _config.Object,
                _notificationServiceMock.Object);
        }
    }
}