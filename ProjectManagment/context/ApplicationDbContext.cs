using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.context.entities;

namespace ProjectManagment.context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                Name = "Lead",
                NormalizedName = "Lead"
            },
                new IdentityRole
                {
                    Id = "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                    Name = "Developer",
                    NormalizedName = "Developer"
                }
            ); 

        }




         public DbSet<User> users { get; set; }
        public DbSet<DeveloperTask> Tasks { get; set; }
        public DbSet<Project> projects { get; set; }



    }
}
