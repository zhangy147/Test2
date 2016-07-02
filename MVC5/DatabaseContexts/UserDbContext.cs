using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MVC5.Models;

namespace MVC5.DatabaseContexts
{
    //public class UserDbContext : IdentityDbContext<ApplicationUser>
    //{
        //public UserDbContext()
        //    : base("UserDbConn")
        //{
        //}

        //public virtual IDbSet<ApplicationUser> Users { get; set; }
        //public virtual IDbSet<IdentityRole> Roles { get; set; }
        //public virtual IDbSet<IdentityUserClaim> Claims { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    if (modelBuilder == null)
        //        throw new ArgumentNullException("modelBuilder");
        //    modelBuilder.Configurations.AddFromAssembly(typeof(Generic_Repo_Template.Models.Configurations.ApplicationUserConfiguration).Assembly);
        //}
    //}
}