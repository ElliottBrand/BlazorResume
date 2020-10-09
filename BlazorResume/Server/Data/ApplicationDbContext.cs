using BlazorResume.Server.Models;
using BlazorResume.Shared.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorResume.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<ResumeModel> Resume { get; set; }
        public DbSet<HireinatorModel> Hireinator { get; set; }
        public DbSet<SettingsModel> Settings { get; set; }
        public DbSet<AboutModel> About { get; set; }
    }
}
