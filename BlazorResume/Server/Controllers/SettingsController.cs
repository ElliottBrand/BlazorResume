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
