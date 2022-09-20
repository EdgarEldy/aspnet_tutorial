using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace aspnet_tutorial.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    // Define ApplicationRole class which inherits IdentityRole generic type
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            
        }

        public ApplicationRole(string name)
        {
            Name = name;
        }
    }

    // Define ApplicationUserRole class which inherits IdentityUserRole generic type
    public class ApplicationUserRole : IdentityUserRole
    {

    }

    // Define ApplicationUserClaim class which inherits IdentityUserClaim generic type
    public class ApplicationUserClaim : IdentityUserClaim
    {

    }

    // Define ApplicationUserLogin class which inherits IdentityUserLogin generic type
    public class ApplicationUserLogin : IdentityUserLogin
    {

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Renaming identity tables to custom tables
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("ModelBuilder is NULL");
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        }
    }
}