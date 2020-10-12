using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Helpers.Google
{
    public class ReCaptcha
    {
        public string Success { get; set; }
        public string Score { get; set; }
        public string ChallengeTs { get; set; } //challenge_ts
        public string HostName { get; set; }

        public bool Validate(string gResponse, string privateKey)
        {
            //var gResponse = Request.Form["g-recaptcha-response"];
            using (var client = new System.Net.WebClient())
            {
                try
                {
                    var gReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", privateKey, gResponse));

                    var jsonReturned = JsonConvert.DeserializeObject<ReCaptcha>(gReply);
                    return (jsonReturned.Success.ToLower() == "true");
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
        }
    }
}
