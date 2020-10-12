using BlazorResume.Server.Helpers;
using BlazorResume.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data.Repository
{
    public class Settings
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataEncryptionHelper _encryptHelper;

        public Settings(ApplicationDbContext context, IDataEncryptionHelper encryptHelper)
        {
            _context = context;
            _encryptHelper = encryptHelper;
        }

        public async Task<SettingsModel> GetSettingsAsync()
        {
            var settings = await _context.Settings.FirstOrDefaultAsync();
            var settingsModel = new SettingsModel()
            {
                PhoneNumber = settings.PhoneNumber,
                ShowPhone = settings.ShowPhone,
                NoticeText = settings.NoticeText,
                EnableNoticeMarquee = settings.EnableNoticeMarquee,
                MainThemeColor = settings.MainThemeColor,
                LinkedIn = settings.LinkedIn,
                Twitter = settings.Twitter,
                Facebook = settings.Facebook,
                GitHub = settings.GitHub,
                Twitch = settings.Twitch,
                YouTube = settings.YouTube,
                GoogleAnalyticsID = settings.GoogleAnalyticsID,
                SendGridKey = _encryptHelper.Decrypt(settings.SendGridKey),
                EmailAddress = settings.EmailAddress,
                ReCaptchaKey = _encryptHelper.Decrypt(settings.ReCaptchaKey),
                ReCaptchaSecretKey = _encryptHelper.Decrypt(settings.ReCaptchaSecretKey)
            };

            return settingsModel;
        }

        public async Task<bool> UpdateSettingsAsync(SettingsModel settingsModel)
        {
            var settings = await _context.Settings.FirstOrDefaultAsync();
            if (settings != null)
            {
                try
                {
                    settings.PhoneNumber = settingsModel.PhoneNumber;
                    settings.ShowPhone = settingsModel.ShowPhone;
                    settings.NoticeText = settingsModel.NoticeText;
                    settings.ShowNotice = settingsModel.ShowNotice;
                    settings.EnableNoticeMarquee = settingsModel.EnableNoticeMarquee;
                    settings.MainThemeColor = settingsModel.MainThemeColor;
                    settings.LinkedIn = settingsModel.LinkedIn;
                    settings.Twitter = settingsModel.Twitter;
                    settings.Facebook = settingsModel.Facebook;
                    settings.GitHub = settingsModel.GitHub;
                    settings.Twitch = settingsModel.Twitch;
                    settings.YouTube = settingsModel.YouTube;
                    settings.GoogleAnalyticsID = settingsModel.GoogleAnalyticsID;
                    settings.SendGridKey = _encryptHelper.Encrypt(settingsModel.SendGridKey);
                    settings.EmailAddress = settingsModel.EmailAddress;
                    settings.ReCaptchaKey = _encryptHelper.Encrypt(settingsModel.ReCaptchaKey);
                    settings.ReCaptchaSecretKey = _encryptHelper.Encrypt(settingsModel.ReCaptchaSecretKey);

                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
