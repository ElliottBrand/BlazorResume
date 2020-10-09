using BlazorResume.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data.Repository
{
    public class Jobs
    {
        private readonly ApplicationDbContext _context;

        public Jobs(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobModel>> GetJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<bool> AddJobAsync(JobModel jobModel)
        {
            try
            {
                await _context.Jobs.AddAsync(jobModel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<JobModel> GetJobAsync(int jobId)
        {
            return await _context.Jobs.Where(p => p.JobId == jobId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateJobAsync(JobModel jobModel)
        {
            var job = await _context.Jobs.Where(p => p.JobId == jobModel.JobId).FirstOrDefaultAsync();
            if(job != null)
            {
                try
                {
                    job.JobTitle = jobModel.JobTitle;
                    job.CompanyName = jobModel.CompanyName;
                    job.Details = jobModel.Details;
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

        public async Task<bool> DeleteJobAsync(int jobId)
        {
            try
            {
                var job = await _context.Jobs.Where(p => p.JobId == jobId).FirstOrDefaultAsync();
                if(job != null)
                {
                    _context.Jobs.Remove(job);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
