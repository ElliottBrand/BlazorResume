using BlazorResume.Server.Interfaces;
using BlazorResume.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Controllers
{
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IManageSettings _manageSettings;

        public SettingsController(IManageSettings manageSettings)
        {
            _manageSettings = manageSettings;
        }

        [HttpGet]
        [Route("api/settings")]
        public async Task<SettingsModel> Get()
        {
            var allSettings = await _manageSettings.GetSettingsAsync();

            // Only sending limited settings, so more sensitive Keys aren't revealed.
            // May end up moving those to a ConfigurationModel later.
            var limitedSettings = new SettingsModel()
            {
                MainThemeColor = allSettings.MainThemeColor,
                ShowNotice = allSettings.ShowNotice,
                NoticeText = allSettings.NoticeText,
                EnableNoticeMarquee = allSettings.EnableNoticeMarquee,
                ShowPhone = allSettings.ShowPhone,
                PhoneNumber = allSettings.PhoneNumber,
                Facebook = allSettings.Facebook,
                LinkedIn = allSettings.LinkedIn,
                Twitter = allSettings.Twitter,
                GitHub = allSettings.GitHub,
                Twitch = allSettings.Twitch,
                YouTube = allSettings.YouTube,
                GoogleAnalyticsID = allSettings.GoogleAnalyticsID,
                ReCaptchaKey = allSettings.ReCaptchaKey
            };
            return limitedSettings;
        }

        [HttpGet]
        [Route("api/allsettings")]
        [Authorize(Roles = "administrator")]
        public async Task<SettingsModel> GetAllSettings()
        {
            return await _manageSettings.GetSettingsAsync();
        }

        [HttpPost]
        [Route("api/settings")]
        [Authorize(Roles = "administrator")]
        public async Task<bool?> Post(SettingsModel settingsModel)
        {
            try
            {
                var updated = await _manageSettings.UpdateSettingsAsync(settingsModel);
                if (updated)
                    return true;
                else
                    return false;
            }
            catch
            {
                return null;
            }
        }
    }
}
