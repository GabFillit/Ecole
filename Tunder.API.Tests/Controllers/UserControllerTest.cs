using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data.BusinessObject.DTO;
using Data.Model;
using Data.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tunder.API.Controllers;
using Tunder.API.Tests.TestHelpers;

namespace Tunder.API.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<IUserRepository> _userRepoMock;
        private Mock<IMapper> _mapper;

        [TestInitialize]
        public void Init()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();
        }

        private UsersController GetController()
        {
            var controller = new UsersController(_userRepoMock.Object, _mapper.Object);
            controller.SetUserClaimId(Guid.NewGuid());
            return controller;
        }


        [TestMethod]
        public async Task GetMe_NotFound()
        {
            User nullUser = null;

            _userRepoMock.Setup(repo => repo.GetByGuidAsync(It.IsAny<Guid>()))
                .ReturnsAsync(nullUser);

            var controller = GetController();

            var actionResult = await controller.GetMe();

            _mapper.Verify(m => m.Map<UserResponseDto>(nullUser), Times.Never);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetMe_NotFound2()
        {
            User nullUser = null;

            _userRepoMock.Setup(repo => repo.GetByGuidAsync(It.IsAny<Guid>()))
                .ReturnsAsync(nullUser);

            var controller = GetController();

            var actionResult = await controller.GetMe();

            _mapper.Verify(m => m.Map<UserResponseDto>(nullUser), Times.Never);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetMe_Ok()
        {
            User user = new User();

            _userRepoMock.Setup(repo => repo.GetByGuidAsync(It.IsAny<Guid>()))
                .ReturnsAsync(user);

            var controller = GetController();

            var actionResult = await controller.GetMe();

            _mapper.Verify(m => m.Map<UserResponseDto>(user), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }
    }
}