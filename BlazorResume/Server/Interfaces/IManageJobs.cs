using BlazorResume.Shared.Models;
using BlazorResume.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Interfaces
{
    public interface IManageJobs
    {
        Task<List<JobModel>> GetJobsAsync();
        Task<bool> AddJobAsync(JobModel jobModel);
        Task<JobModel> GetJobAsync(int jobId);
        Task<bool> UpdateJobAsync(JobModel jobModel);
        Task<bool> DeleteJobAsync(int jobId);
    }
    public class ManageJobs : IManageJobs
    {
        private readonly ApplicationDbContext _context;

        public ManageJobs(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobModel>> GetJobsAsync() =>
            await new Data.Repository.Jobs(_context).GetJobsAsync();

        public async Task<bool> AddJobAsync(JobModel jobModel) =>
            await new Data.Repository.Jobs(_context).AddJobAsync(jobModel);

        public async Task<JobModel> GetJobAsync(int jobId) =>
            await new Data.Repository.Jobs(_context).GetJobAsync(jobId);

        public async Task<bool> UpdateJobAsync(JobModel jobModel) =>
            await new Data.Repository.Jobs(_context).UpdateJobAsync(jobModel);

        public async Task<bool> DeleteJobAsync(int jobId) =>
            await new Data.Repository.Jobs(_context).DeleteJobAsync(jobId);
    }
}
