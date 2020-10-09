using BlazorResume.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data
{
    public static class SeedSettings
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var settings = new SettingsModel()
            {
                MainThemeColor = "Blue",
                EnableNoticeMarquee = false,
                NoticeText = "",
                ShowNotice = false,
                PhoneNumber = "",
                ShowPhone = false
            };

            context.Settings.Add(settings);
            context.SaveChanges();
        }
    }
}
