using System.Data.Entity;

namespace MVC5.DatabaseContexts
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