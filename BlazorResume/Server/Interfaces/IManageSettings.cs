using BlazorResume.Server.Data;
using BlazorResume.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Interfaces
{
    public interface IManageSettings
    {
        Task<SettingsModel> GetSettingsAsync();
        Task<bool> UpdateSettingsAsync(SettingsModel settingsModel);
    }

    public class ManageSettings : IManageSettings
    {
        private readonly ApplicationDbContext _context;

        public ManageSettings(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SettingsModel> GetSettingsAsync() =>
            await new Data.Repository.Settings(_context).GetSettingsAsync();

        public async Task<bool> UpdateSettingsAsync(SettingsModel settingsModel) =>
            await new Data.Repository.Settings(_context).UpdateSettingsAsync(settingsModel);
    }
}
