using LuukitWebsite.Models;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;

namespace Luuk.it
{
    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer<ProjectsContext>(null); //new DropCreateDatabaseAlways<ProjectsContext>()
        }
    }
}