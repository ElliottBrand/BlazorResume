using BlazorResume.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data.Repository
{
    public class Resume
    {
        private readonly ApplicationDbContext _context;

        public Resume(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResumeModel> GetResumeDetailsAsync()
        {
            var resume = await _context.Resume.FirstOrDefaultAsync();
            resume.Jobs = await _context.Jobs.OrderByDescending(p => p.StartDate).ToListAsync();
            return resume;
        }

        public async Task<bool> UpdateResumeDetailsAsync(ResumeModel resumeModel)
        {
            var resume = await _context.Resume.Where(p => p.Id == resumeModel.Id).FirstOrDefaultAsync();

            if(resume != null)
            {
                try
                {
                    resume.PageTitle = resumeModel.PageTitle;
                    resume.FullName = resumeModel.FullName;
                    resume.ResumeImage = resumeModel.ResumeImage;
                    resume.JobTitle = resumeModel.JobTitle;
                    resume.Overview = resumeModel.Overview;

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
    }
}
