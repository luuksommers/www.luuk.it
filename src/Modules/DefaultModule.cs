using System;
using Nancy;
using LuukIt;

namespace LuukIt.Modules
{
    public class DefaultModule : NancyModule
    {
        public DefaultModule()
        {
            Get["/"] = _ => View["index.cshtml"];
            //Get["/test"] = _ => AppDomain.CurrentDomain.BaseDirectory + "******" + Startup.Environment.ApplicationBasePath;
        }
    }
}