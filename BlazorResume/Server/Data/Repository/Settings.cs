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

        public Settings(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SettingsModel> GetSettingsAsync()
        {
            return await _context.Settings.FirstOrDefaultAsync();
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
