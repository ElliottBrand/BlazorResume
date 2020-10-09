using BlazorResume.Client.Components.Alert;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace BlazorResume.Tests.Client.Components.Alert
{
    public class AlertHelpersTests
    {
        [Fact]
        public async void BuildMessage_OkStatusCodeReturnsAlertModelTest()
        {
            var responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent("true");

            AlertModel alertModel = await AlertHelpers.BuildMessageAsync(responseMessage);

            Assert.Equal("Success", alertModel.Status);
            Assert.True(!string.IsNullOrEmpty(alertModel.Message));
        }

        [Fact]
        public async void BuildMessage_BadRequestStatusCodeReturnsAlertModelTest()
        {
            var responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent("false");

            AlertModel alertModel = await AlertHelpers.BuildMessageAsync(responseMessage);

            Assert.Equal("Warning", alertModel.Status);
            Assert.True(!string.IsNullOrEmpty(alertModel.Message));
        }

        [Fact]
        public async void BuildMessage_AnyOtherStatusCodeReturnsAlertModelTest()
        {
            var responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent("");

            AlertModel alertModel = await AlertHelpers.BuildMessageAsync(responseMessage);

            Assert.Equal("Error", alertModel.Status);
            Assert.True(!string.IsNullOrEmpty(alertModel.Message));
        }
    }
}
