using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace DatingApp.API.Data {
    public class Seed {
        // private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed (UserManager<User> userManager, RoleManager<Role> roleManager) {
            // _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers () {
            if (!_userManager.Users.Any ())
            {
                var userData = System.IO.File.ReadAllText ("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>> (userData);

                var roles = new List<Role> 
                {
                    new Role {Name = "Member"},
                    new Role {Name = "Admin"},
                    new Role {Name = "Moderator"},
                    new Role {Name = "VIP"},
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                foreach (var user in users) {
                    // byte[] passwordHash, passwordSalt;
                    // CreatePasswordHash ("password", out passwordHash, out passwordSalt);
                    // user.PasswordHash = passwordHash;
                    // user.PasswordSalt = passwordSalt;
                    // user.UserName = user.UserName.ToLower ();
                    _userManager.CreateAsync(user, "password").Wait();
                    _userManager.AddToRoleAsync(user, "Member").Wait();
                    user.Photos.SingleOrDefault().IsApproved = true;

                }

                var adminUser = new User 
                {
                    UserName = "Admin",
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "password").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator"}).Wait();
                }
            }

            //_userManager.SaveChanges ();
        }

        // private void CreatePasswordHash (string password, out byte[] passwordHash, out byte[] passwordSalt) {
        //     using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {
        //         passwordSalt = hmac.Key;
        //         passwordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
        //     }
        // }
    }
}