using BlazorResume.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data
{
    public static class SeedHireinator
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var hireinator = new HireinatorModel()
            {
                MinSalary = 60000,
                GrayAreaSalary = 80000,
                TargetSalary = 100000,
                MaxSalary = 200000,
                ShowHireinator = true
            };

            context.Hireinator.Add(hireinator);
            context.SaveChanges();
        }
    }
}
