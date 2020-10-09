using BlazorResume.Shared.Models;
using BlazorResume.Server.Controllers;
using BlazorResume.Server.Interfaces;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BlazorResume.Tests.Server.Controllers
{
    public class ResumeControllerTests
    {
        [Fact]
        public async void ResumeController_ReturnsTrueOnSuccessTest()
        {
            var mockManageResume = new Mock<IManageResume>();
            mockManageResume.Setup(p => p.UpdateResumeDetailsAsync(It.IsAny<ResumeModel>()))
                .Returns(Task.FromResult(true));

            var mockResumeController = new ResumeController(mockManageResume.Object);

            var result = await mockResumeController.Post(It.IsAny<ResumeModel>());

            var response = Assert.IsType<bool>(result);
            Assert.True(response);
        }

        [Fact]
        public async void ResumeController_ReturnsFalseOnFailureTest()
        {
            var mockManageResume = new Mock<IManageResume>();
            mockManageResume.Setup(p => p.UpdateResumeDetailsAsync(It.IsAny<ResumeModel>()))
                .Returns(Task.FromResult(false));

            var mockResumeController = new ResumeController(mockManageResume.Object);

            var result = await mockResumeController.Post(It.IsAny<ResumeModel>());

            var response = Assert.IsType<bool>(result);
            Assert.False(response);
        }

        [Fact]
        public async void ResumeController_ReturnsNullOnErrorTest()
        {
            var mockManageResume = new Mock<IManageResume>();
            mockManageResume.Setup(p => p.UpdateResumeDetailsAsync(It.IsAny<ResumeModel>()))
                .Throws<Exception>();

            var mockResumeController = new ResumeController(mockManageResume.Object);

            var result = await mockResumeController.Post(It.IsAny<ResumeModel>());

            Assert.Null(result);
        }
    }
}
