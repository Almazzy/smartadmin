#region Using

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.Seed.Data.Entity;
using SmartAdmin.Seed.Models;
using SmartAdmin.Seed.Models.ManageViewModels;

#endregion

namespace SmartAdmin.Seed.Data
{
    /// <summary>
    ///     Defines the Entity Framework database context instance used by the application.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        /// <summary>
        ///     Configures the schema needed for the application identity framework.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this application context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Articles>()
            .Property("_Tags");

            builder.Entity<Sources>()
           .Property("_SourceConfiguration");

            builder.Entity<Articles>().ToTable("Articles");
            builder.Entity<Sources>().ToTable("Sources");

        }

        /// <summary>
        ///     Configures the schema needed for the application identity framework.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this application context.</param>
        //public DbSet<SmartAdmin.Seed.Models.ManageViewModels.IndexViewModel> IndexViewModel { get; set; }
        public DbSet<Sources> Sources { get; set; }
        public DbSet<Posts> Posts { get; set; }
    }

}
