using Lab4_5_6_7.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lab4_5_6_7
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var user = userManager.FindByNameAsync("Admin");
            var role = roleManager.FindByNameAsync("Administrator");
            if (user.IsCompleted && role.IsCompleted)
            {
                if (role.Result == null)
                {
                    var role1 = new IdentityRole { Name = "Administrator" };

                    roleManager.Create(role1);
                }
                if (user.Result == null)
                {
                    var admin = new ApplicationUser { Email = "aquaitstep@gmail.com", UserName = "Admin" };
                    string password = "Admin 11111";
                    var result = userManager.Create(admin, password);
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(admin.Id, "Administrator");
                    }
                }
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
