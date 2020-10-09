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
    public class HireinatorController : ControllerBase
    {
        private readonly IManageHireinator _manageHireinator;

        public HireinatorController(IManageHireinator manageHireinator)
        {
            _manageHireinator = manageHireinator;
        }

        [HttpGet]
        [Route("api/hireinator")]
        public async Task<HireinatorModel> Get()
        {
            return await _manageHireinator.GetHireinatorDetailsAsync();
        }

        [HttpPost]
        [Authorize(Roles = "administrator")]
        [Route("api/hireinator")]
        public async Task<bool?> Post(HireinatorModel hireinatorModel)
        {
            try
            {
                var updated = await _manageHireinator.UpdateHireinatorAsync(hireinatorModel);
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
