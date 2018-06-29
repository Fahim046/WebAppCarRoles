namespace WebAppCarRoles.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppCarRoles.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppCarRoles.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebAppCarRoles.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Cars.AddOrUpdate(
              p => p.Name,
              new Car { Name = "R8", Brand ="Audi" },
              new Car { Name = "900", Brand ="Saab"},
              new Car { Name = "740", Brand = "Volvo" }
            );


            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            roleManager.Create(new IdentityRole("CreateCar"));
            roleManager.Create(new IdentityRole("ReadCar"));
            roleManager.Create(new IdentityRole("UpdateCar"));
            roleManager.Create(new IdentityRole("DeleteCar"));


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            userManager.Create(new ApplicationUser() { Email = "create@cars.se" , UserName = "create@cars.se" }, "Password!1");
            userManager.Create(new ApplicationUser() { Email = "read@cars.se", UserName = "read@cars.se" },  "Password!1");
            userManager.Create(new ApplicationUser() { Email = "update@cars.se", UserName = "update@cars.se" }, "Password!1");
            userManager.Create(new ApplicationUser() { Email = "delete@cars.se", UserName = "delete@cars.se" }, "Password!1");


            ApplicationUser createUser = userManager.FindByEmail("create@car.se");
            ApplicationUser readUser = userManager.FindByEmail("read@car.se");
            ApplicationUser updateUser = userManager.FindByEmail("updatete@car.se");
            ApplicationUser deleteUser = userManager.FindByEmail("delete@car.se");


            userManager.AddToRole(createUser.Id, "Create");
            userManager.AddToRole(readUser.Id, "Read");
            userManager.AddToRole(updateUser.Id, "Update");
            userManager.AddToRole(deleteUser.Id, "Delete");



        }
    }
}
