using System;
using System.Threading.Tasks;

namespace BlazorResume.Client.Components.Alert
{
    public class AlertState
    {
        public event Action RenderAlert;
        public string ResultClass { get; private set; }
        public string ResultSpan { get; private set; }

        /// <summary>
        /// Applies the proper styles to an Alert based on the provided status, then invokes the RenderAlert event.
        /// </summary>
        /// <param name="status">Should be "Success", "Warning", or "Error".</param>
        /// <returns></returns>
        public void RenderAlertStyles(string status)
        {
            ApplyStyles(status);

            NotifyStateChanged();
        }

        /// <summary>
        /// Render an Alert that vanishes after a set amount of time.
        /// </summary>
        /// <param name="status">Should be "Success", "Warning", or "Error".</param>
        /// <param name="delay">Number of milliseconds to display the alert.</param>
        /// <returns></returns>
        public async Task RenderVanishingAlertStylesAsync(string status, int delay)
        {
            ApplyStyles(status);

            NotifyStateChanged();

            await Task.Delay(delay);

            ResultClass = "d-none";
            ResultSpan = "";

            NotifyStateChanged();
        }

        public void ApplyStyles(string status)
        {
            if (status == "Success")
            {
                ResultClass = "d-block alert alert-success";
                ResultSpan = "text-success";
            }
            else if (status == "Warning")
            {
                ResultClass = "d-block alert alert-warning";
                ResultSpan = "";
            }
            else if (status == "Error")
            {
                ResultClass = "d-block alert alert-danger";
                ResultSpan = "text-danger";
            }
        }

        public void NotifyStateChanged() => RenderAlert?.Invoke();
    }
}
