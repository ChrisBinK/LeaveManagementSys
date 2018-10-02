using EmployeeLeaveMng.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeLeaveMng.Startup))]
namespace EmployeeLeaveMng
{
    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRole();
        }

        //Method to create user role
        public void createRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // check if the role is existant, otherwise add the role in the db
            if (roleManager.RoleExists(GlobalVariable.ADMINISTRATOR) == false)
            {
                var role = new IdentityRole();
                role.Name = GlobalVariable.ADMINISTRATOR;
                roleManager.Create(role);
            }
            if (roleManager.RoleExists(GlobalVariable.EMPLOYEE) == false)
            {
                var role = new IdentityRole();
                role.Name = GlobalVariable.EMPLOYEE;
                roleManager.Create(role);
            }
        }
    }
}
