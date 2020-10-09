using System.Threading.Tasks;
using BlazorResume.Shared.Models;
using BlazorResume.Server.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorResume.Server.Controllers
{
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IManageResume _manageResume;

        public ResumeController(IManageResume manageResume)
        {
            _manageResume = manageResume;
        }

        [HttpGet]
        [Route("api/resume")]
        public async Task<ResumeModel> Get()
        {
            return await _manageResume.GetResumeDetailsAsync();
        }

        [HttpPost]
        [Route("api/resume")]
        [Authorize(Roles = "administrator")]
        public async Task<bool?> Post(ResumeModel resumeModel)
        {
            try
            {
                var updated = await _manageResume.UpdateResumeDetailsAsync(resumeModel);
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
