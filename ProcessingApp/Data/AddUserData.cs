using ProcessingApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Data
{
    public class AddUserData
    {
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            string role2 = "Applicant";
            string desc2 = "This is the applicant role";

            string role3 = "Owner";
            string desc3 = "This is the owner role";

            string password = "password";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }

            // create admin role
            if (await userManager.FindByNameAsync("admin@test.ca") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@test.ca",
                    Email = "admin@test.ca",
                    FirstName = "Adam",
                    LastName = "Aldridge",
                    Street = "Fake St",
                    City = "Vancouver",
                    Province = "BC",
                    PostalCode = "V5U K8I",
                    Country = "Canada",
                    PhoneNumber = "6902341234"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }


            // create applicant role
            if (await userManager.FindByNameAsync("applicant@test.ca") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "applicant@test.ca",
                    Email = "applicant@test.ca",
                    FirstName = "Mike",
                    LastName = "Myers",
                    Street = "Yew St",
                    City = "Vancouver",
                    Province = "BC",
                    PostalCode = "V3U E2Y",
                    Country = "Canada",
                    PhoneNumber = "6572136821"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }


            // create owner role
            if (await userManager.FindByNameAsync("owner@test.ca") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "owner@test.ca",
                    Email = "owner@test.ca",
                    FirstName = "Kirill",
                    LastName = "Barsukov",
                    Street = "Bell Farm",
                    City = "Toronto",
                    Province = "ON",
                    PostalCode = "V3U E2Y",
                    Country = "Canada",
                    PhoneNumber = "6572136821"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
            }
        }
    }
}