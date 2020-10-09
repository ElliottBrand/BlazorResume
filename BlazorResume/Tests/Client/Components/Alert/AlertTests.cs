using System;
using Xunit;
using BlazorResume.Client.Components.Alert;

namespace BlazorResume.Tests.Client.Components.Alert
{
    public class AlertTests
    {
        [Fact]
        public async void Alert_Render_EndsWithHiddenDivTest()
        {
            var alertState = new AlertState();

            await alertState.RenderVanishingAlertStylesAsync("Success", 2500);

            Assert.Equal("d-none", alertState.ResultClass);
            Assert.Equal("", alertState.ResultSpan);
        }

        [Fact]
        public void Alert_Success_SetsCorrectStylesTest()
        {
            var alertState = new AlertState();

            alertState.ApplyStyles("Success");

            Assert.Equal("d-block alert alert-success", alertState.ResultClass);
            Assert.Equal("text-success", alertState.ResultSpan);
        }

        [Fact]
        public void Alert_Warning_SetsCorrectStylesTest()
        {
            var alertState = new AlertState();

            alertState.ApplyStyles("Warning");

            Assert.Equal("d-block alert alert-warning", alertState.ResultClass);
            Assert.Equal("", alertState.ResultSpan);
        }

        [Fact]
        public void Alert_Error_SetsCorrectStylesTest()
        {
            var alertState = new AlertState();

            alertState.ApplyStyles("Error");

            Assert.Equal("d-block alert alert-danger", alertState.ResultClass);
            Assert.Equal("text-danger", alertState.ResultSpan);
        }
    }
}
