using BlazorResume.Shared.Models;
using BlazorResume.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace BlazorResume.Server.Controllers
{
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IManageJobs _manageJobs;

        public JobsController(IManageJobs manageJobs)
        {
            _manageJobs = manageJobs;
        }

        [HttpGet]
        [Route("api/jobs")]
        public async Task<List<JobModel>> Get()
        {
            var jobs = await _manageJobs.GetJobsAsync();
            return jobs.OrderByDescending(p => p.StartDate).ToList();
        }

        [HttpPost]
        [Authorize(Roles = "administrator")]
        [Route("api/jobs")]
        public async Task<bool?> Post(JobModel jobModel)
        {
            try
            {
                var added = await _manageJobs.AddJobAsync(jobModel);
                if (added)
                    return true;
                else
                    return false;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/jobs/{JobId:int}")]
        public async Task<JobModel> Get(int JobId)
        {
            return await _manageJobs.GetJobAsync(JobId);
        }

        [HttpPost]
        [Authorize(Roles = "administrator")]
        [Route("api/jobs/update/{JobId:int}")]
        public async Task<bool?> Post(int JobId, JobModel jobModel)
        {
            try
            {
                var updated = await _manageJobs.UpdateJobAsync(jobModel);
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

        [HttpPost]
        [Authorize(Roles = "administrator")]
        [Route("api/jobs/delete/{JobId:int}")]
        public async Task<bool?> Post(int JobId)
        {
            try
            {
                var deleted = await _manageJobs.DeleteJobAsync(JobId);
                if (deleted)
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
