using BlazorResume.Shared.Models;
using BlazorResume.Server.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Controllers
{
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IManageAbout _manageAbout;

        public AboutController(IManageAbout manageAbout)
        {
            _manageAbout = manageAbout;
        }

        [HttpGet]
        [Route("api/about")]
        public async Task<AboutModel> Get()
        {
            return await _manageAbout.GetAboutDetailsAsync();
        }

        [HttpPost]
        [Route("api/about")]
        [Authorize(Roles = "administrator")]
        public async Task<bool?> Post(AboutModel aboutModel)
        {
            try
            {
                var updated = await _manageAbout.UpdateAboutDetailsAsync(aboutModel);
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
