using BlazorResume.Shared.Models;
using BlazorResume.Server.Data;
using System.Threading.Tasks;

namespace BlazorResume.Server.Interfaces
{
    public interface IManageResume
    {
        Task<ResumeModel> GetResumeDetailsAsync();
        Task<bool> UpdateResumeDetailsAsync(ResumeModel resumeModel);
    }

    public class ManageResume : IManageResume
    {
        private readonly ApplicationDbContext _context;

        public ManageResume(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResumeModel> GetResumeDetailsAsync() =>
            await new Data.Repository.Resume(_context).GetResumeDetailsAsync();

        public async Task<bool> UpdateResumeDetailsAsync(ResumeModel resumeModel) =>
            await new Data.Repository.Resume(_context).UpdateResumeDetailsAsync(resumeModel);
    }
}
