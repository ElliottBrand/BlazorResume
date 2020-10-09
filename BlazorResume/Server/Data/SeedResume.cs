using BlazorResume.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data
{
    public static class SeedResume
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var resume = new ResumeModel()
            {
                PageTitle = "My Resume",
                FullName = "Henry Hacker",
                JobTitle = "Web Developer",
                Overview = "I build the things the world relies on in order to perform their daily tasks. " +
                "When you press your brake pedal, my code tells the rotors to grab. When you make a purchase online, " +
                "my code performs that transaction. However, when you press a button and a spinner just sits there and spins..." +
                "that was someone else's code."
            };

            context.Resume.Add(resume);
            context.SaveChanges();
        }
    }
}
