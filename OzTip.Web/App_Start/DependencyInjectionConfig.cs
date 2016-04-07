using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace OzTip.Web
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // OzTip data layer stuff.
            container.Register<DbContext, OzTipContext>(Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(RepositoryBase<>));


            // Provide registrations for ASP.NET Identity stuff.
            container.Register<IUserStore<User, int>, ApplicationUserStore>(Lifestyle.Scoped);
            container.Register<IRoleStore<Role, int>, ApplicationRoleStore>(Lifestyle.Scoped);
            container.RegisterPerWebRequest(() =>
                container.IsVerifying()
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            
            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            
            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}