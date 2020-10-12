using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorResume.Shared.Models
{
    public class SettingsModel
    {
        public int Id { get; set; }
        public string MainThemeColor { get; set; }
        public bool ShowNotice { get; set; }
        public string NoticeText { get; set; }
        public bool EnableNoticeMarquee { get; set; }
        public bool ShowPhone { get; set; }
        public string PhoneNumber { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string GitHub { get; set; }
        public string Twitch { get; set; }
        public string YouTube { get; set; }
        public string GoogleAnalyticsID { get; set; }
        public string SendGridKey { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        public string ReCaptchaKey { get; set; }
        public string ReCaptchaSecretKey { get; set; }
    }
}
