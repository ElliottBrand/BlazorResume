using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorResume.Shared.Helpers;

namespace BlazorResume.Client.Components.Alert
{
    public class AlertHelpers
    {
        public static async Task<AlertModel> BuildMessageAsync(HttpResponseMessage response)
        {
            var alertModel = new AlertModel();

            var updated = await ResponseMessageHelpers.GetBoolFromHttpResponseMessage(response);

            if (updated == true)
            {
                alertModel.Message = "Successfully updated!";
                alertModel.Status = "Success";
            }
            else if (updated == false)
            {
                alertModel.Message = "There was a problem updating the data. Please try again.";
                alertModel.Status = "Warning";
            }
            else
            {
                alertModel.Message = "An error occurred while attempting to update the data.";
                alertModel.Status = "Error";
            }

            return alertModel;
        }
    }
}
