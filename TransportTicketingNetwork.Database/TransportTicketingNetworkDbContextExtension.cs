using System.Collections.Generic;
using System.Linq;
using Common.Methods;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace TransportTicketingNetwork.Database
{
    public static class TransportTicketingNetworkDbContextExtension
    {
        /// <summary>
        /// Do migrations and seed data
        /// </summary>
        /// <param name="context"></param>
        public static void InitializeDatabase(this TransportTicketingNetworkDbContext context)
        {
            // Perform database delete and create
            context.Database.Migrate();

            // Perform seed operations
            SeedData(context);

            // Save changes and release resources
            context.SaveChanges();
        }

        /// <summary>
        /// Seed data to database
        /// </summary>
        /// <param name="context"></param>
        private static void SeedData(TransportTicketingNetworkDbContext context)
        {
            if (context.Users.Any())
                return;

            List<User> users = new List<User>();

            User newUser = new User()
            {
                FirstName = "Chathuranga",
                LastName = "Basnayake",
                Gender = Gender.Male,
                Email = "chathurangabasnayake@outlook.com",
                Mobile = "0778511690",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "CSBUnlimited",
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("5556", out byte[] passwordHash, out byte[] passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);

            newUser = new User()
            {
                FirstName = "Harin",
                LastName = "Wijesekara",
                Gender = Gender.Male,
                Email = "harin.w@gmail.com",
                Mobile = "077xxxxxxx",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "user1",
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("user1", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);

            newUser = new User()
            {
                FirstName = "Pathmika",
                LastName = "Rajapakshe",
                Gender = Gender.Male,
                Email = "pathmika.r@outlook.com",
                Mobile = "076yyyyyyy",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "user2",
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("user2", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);
        }
    }
}
