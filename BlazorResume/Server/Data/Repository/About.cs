using BlazorResume.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data.Repository
{
    public class About
    {
        private readonly ApplicationDbContext _context;

        public About(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AboutModel> GetAboutDetailsAsync()
        {
            return await _context.About.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAboutDetailsAsync(AboutModel aboutModel)
        {
            var about = await _context.About.FirstOrDefaultAsync();
            if (about != null)
            {
                try
                {
                    about.Title = aboutModel.Title;
                    // about.Image = aboutModel.Image;
                    about.Details = aboutModel.Details;
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
