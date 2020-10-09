using BlazorResume.Shared.Models;
using BlazorResume.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Interfaces
{
    public interface IManageAbout
    {
        Task<AboutModel> GetAboutDetailsAsync();
        Task<bool> UpdateAboutDetailsAsync(AboutModel aboutModel);
    }

    public class ManageAbout : IManageAbout
    {
        private readonly ApplicationDbContext _context;

        public ManageAbout(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AboutModel> GetAboutDetailsAsync() =>
            await new Data.Repository.About(_context).GetAboutDetailsAsync();

        public async Task<bool> UpdateAboutDetailsAsync(AboutModel aboutModel) =>
            await new Data.Repository.About(_context).UpdateAboutDetailsAsync(aboutModel);
    }
}
