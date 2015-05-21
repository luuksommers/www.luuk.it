using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Nancy.Owin;
using Microsoft.Framework.Runtime;
using Microsoft.AspNet.StaticFiles;

namespace LuukIt_vNext
{
    public class Startup
    {
        internal static IApplicationEnvironment Environment { get; private set; }

        public Startup(IApplicationEnvironment env)
        {
            Environment = env;
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseOwin(a => a.UseNancy());
        }
    }
}
