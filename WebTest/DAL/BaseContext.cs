using System.Data.Entity;

namespace WebTest.DAL
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        public BaseContext()
            : base("SiteDbConn")
        {

        }
    }
}