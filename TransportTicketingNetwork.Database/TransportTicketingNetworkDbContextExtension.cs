using System;
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

            User newUser = new User()
            {
                FirstName = "Anonymous",
                LastName = "Anonymous",
                Gender = Gender.Male,
                Email = "anonymous@anonymous.com",
                Mobile = "xxxxxxxxxx",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "Anonymous",
                    EffectiveDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow,
                    IsBlocked = true,
                    UserType = UserType.Unknown
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("Anonymous", out byte[] passwordHash, out byte[] passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);

            newUser = new User()
            {
                FirstName = "Chathuranga",
                LastName = "Basnayake",
                Gender = Gender.Male,
                Email = "chathurangabasnayake@outlook.com",
                Mobile = "0778511690",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "CSBUnlimited",
                    UserType = UserType.Administrator
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("5556", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);

            newUser = new User()
            {
                FirstName = "Transport",
                LastName = "Manager",
                Gender = Gender.Male,
                Email = "transport.manager@yahoo.com",
                Mobile = "077xxxxxxx",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "TransportM",
                    UserType = UserType.TransportManager
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("user1", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);

            newUser = new User()
            {
                FirstName = "David",
                LastName = "Beckham",
                Gender = Gender.Male,
                Email = "david.beckham@gmail.com",
                Mobile = "1254987454665",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "112233445566778899",
                    UserType = UserType.ForeignCustomer
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("david", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);

            newUser = new User()
            {
                FirstName = "Kavi",
                LastName = "Suchi",
                Gender = Gender.Female,
                Email = "kavi.suchi@gmail.com",
                Mobile = "071xxxxxxx",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "961120570v",
                    UserType = UserType.LocalCustomer
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("kavee", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.Users.Add(newUser);
        }
    }
}
