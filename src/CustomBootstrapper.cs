using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using SquishIt.Framework;
using System.Collections.Generic;
using Nancy.ViewEngines;
using LuukIt;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;

namespace LuukIt
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        static NancyPathTranslator _path = new NancyPathTranslator();

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            Bundle.ConfigureDefaults().UsePathTranslator(_path);
            Bundle.Css()
                .Add("~/css/bootstrap.css")
                .Add("~/css/grayscale.css")
                .AsCached("styles", "~/assets/css/styles");
            Bundle.JavaScript()
                .Add("~/js/jquery-1.11.0.js")
                .Add("~/js/bootstrap.min.js")
                .Add("~/js/jquery.easing.min.js")
                .Add("~/js/grayscale.js")
                .AsCached("scripts", "~/assets/js/scripts");
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IViewEngine, Nancy.ViewEngines.Razor.RazorViewEngine>();
            container.Register<Nancy.ViewEngines.Razor.IRazorConfiguration, Nancy.ViewEngines.Razor.DefaultRazorConfiguration>();
        }

        protected override IEnumerable<Type> ViewEngines
        {
            get { return new[] { typeof(Nancy.ViewEngines.Razor.RazorViewEngine) }; }
        }
    }

    public class NancyPathTranslator : IPathTranslator, IRootPathProvider
    {
        private string BasePath = PlatformServices.Default.Application.ApplicationBasePath;

        public string BuildAbsolutePath(string siteRelativePath)
        {
            return BasePath;
        }

        public string GetRootPath()
        {
            return BasePath;
        }

        public string ResolveAppRelativePathToFileSystem(string file)
        {
            // Remove query string
            if (file.IndexOf('?') != -1)
            {
                file = file.Substring(0, file.IndexOf('?'));
            }

            return Path.Combine(BasePath, file.TrimStart('~').TrimStart('/'));
        }

        public string ResolveFileSystemPathToAppRelative(string file)
        {
            var root = new Uri(BasePath);
            return root.MakeRelativeUri(new Uri(file, UriKind.RelativeOrAbsolute)).ToString();
        }
    }
}
