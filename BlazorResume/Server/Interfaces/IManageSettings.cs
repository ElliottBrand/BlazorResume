using BlazorResume.Server.Data;
using BlazorResume.Server.Helpers;
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
        private readonly IDataEncryptionHelper _encryptHelper;

        public ManageSettings(ApplicationDbContext context, IDataEncryptionHelper encryptHelper)
        {
            _context = context;
            _encryptHelper = encryptHelper;
        }

        public async Task<SettingsModel> GetSettingsAsync() =>
            await new Data.Repository.Settings(_context, _encryptHelper).GetSettingsAsync();

        public async Task<bool> UpdateSettingsAsync(SettingsModel settingsModel) =>
            await new Data.Repository.Settings(_context, _encryptHelper).UpdateSettingsAsync(settingsModel);
    }
}
