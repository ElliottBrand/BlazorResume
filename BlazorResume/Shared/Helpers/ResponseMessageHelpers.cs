using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorResume.Shared.Helpers
{
    public class ResponseMessageHelpers
    {
        public static async Task<bool?> GetBoolFromHttpResponseMessage(HttpResponseMessage response)
        {
            var updated = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(updated))
                return Convert.ToBoolean(updated);
            else
                return null;
        }
    }
}
