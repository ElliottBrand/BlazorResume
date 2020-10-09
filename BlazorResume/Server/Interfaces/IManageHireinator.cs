using BlazorResume.Server.Data;
using BlazorResume.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Interfaces
{
    public interface IManageHireinator
    {
        Task<HireinatorModel> GetHireinatorDetailsAsync();
        Task<bool> UpdateHireinatorAsync(HireinatorModel hireinatorModel);
    }

    public class ManageHireinator : IManageHireinator
    {
        private readonly ApplicationDbContext _context;

        public ManageHireinator(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HireinatorModel> GetHireinatorDetailsAsync() =>
            await new Data.Repository.Hireinator(_context).GetHireinatorDetailsAsync();

        public async Task<bool> UpdateHireinatorAsync(HireinatorModel hireinatorModel) =>
            await new Data.Repository.Hireinator(_context).UpdateHireinatorAsync(hireinatorModel);
    }
}
