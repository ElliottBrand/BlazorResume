using BlazorResume.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data.Repository
{
    public class Hireinator
    {
        private readonly ApplicationDbContext _context;

        public Hireinator(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HireinatorModel> GetHireinatorDetailsAsync()
        {
            return await _context.Hireinator.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateHireinatorAsync(HireinatorModel hireinatorModel)
        {
            var hireinator = await _context.Hireinator.FirstOrDefaultAsync();
            if(hireinator != null)
            {
                try
                {
                    hireinator.ShowHireinator = hireinatorModel.ShowHireinator;
                    hireinator.MinSalary = hireinatorModel.MinSalary;
                    hireinator.GrayAreaSalary = hireinatorModel.GrayAreaSalary;
                    hireinator.TargetSalary = hireinatorModel.TargetSalary;
                    hireinator.MaxSalary = hireinatorModel.MaxSalary;

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
