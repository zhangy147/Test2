using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using MVC5.DatabaseContexts;
using MVC5.Models;

namespace MVC5.DAL
{
    public class UserDbInitilializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
        }
    }
}