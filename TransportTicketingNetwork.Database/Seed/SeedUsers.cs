using System;
using System.Collections.Generic;
using System.Linq;
using Common.Methods;
using Common.Models;
using Modules.Main.Models;

namespace TransportTicketingNetwork.Database.Seed
{
    internal static class SeedUsers
    {
        internal static void SeedUsersData(this TransportTicketingNetworkDbContext context, IEnumerable<UserRole> currentUserRoles)
        {
            if (context.Users.Any())
                return;

            currentUserRoles = currentUserRoles.ToList();

            UserExt newUser = new UserExt()
            {
                FirstName = "Anonymous",
                LastName = "Anonymous",
                GenderEnum = GenderEnum.Male,
                Email = "anonymous@anonymous.com",
                Mobile = "xxxxxxxxxx",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "Anonymous",
                    EffectiveDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow,
                    IsBlocked = true,
                    UserRoleId = currentUserRoles.Single(cur => cur.UserRoleEnum == UserRoleEnum.Anonymous).Id
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("Anonymous", out byte[] passwordHash, out byte[] passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.UserExts.Add(newUser);

            newUser = new UserExt()
            {
                FirstName = "Chathuranga",
                LastName = "Basnayake",
                GenderEnum = GenderEnum.Male,
                Email = "chathurangabasnayake@outlook.com",
                Mobile = "0778511690",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "CSBUnlimited",
                    UserRoleId = currentUserRoles.Single(cur => cur.UserRoleEnum == UserRoleEnum.Administrator).Id
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("5556", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.UserExts.Add(newUser);

            newUser = new UserExt()
            {
                FirstName = "Transport",
                LastName = "Manager",
                GenderEnum = GenderEnum.Male,
                Email = "transport.manager@yahoo.com",
                Mobile = "077xxxxxxx",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "TransportM",
                    UserRoleId = currentUserRoles.Single(cur => cur.UserRoleEnum == UserRoleEnum.TransportManager).Id
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("user1", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.UserExts.Add(newUser);

            newUser = new UserExt()
            {
                FirstName = "David",
                LastName = "Beckham",
                GenderEnum = GenderEnum.Male,
                Email = "david.beckham@gmail.com",
                Mobile = "1254987454665",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "112233445566778899",
                    UserRoleId = currentUserRoles.Single(cur => cur.UserRoleEnum == UserRoleEnum.ForeignCustomer).Id
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("david", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.UserExts.Add(newUser);

            newUser = new UserExt()
            {
                FirstName = "Kavi",
                LastName = "Suchi",
                GenderEnum = GenderEnum.Female,
                Email = "kavi.suchi@gmail.com",
                Mobile = "071xxxxxxx",
                ApplicationUser = new ApplicationUser()
                {
                    Username = "961120570v",
                    UserRoleId = currentUserRoles.Single(cur => cur.UserRoleEnum == UserRoleEnum.LocalCustomer).Id
                }
            };
            AuthenticationMethods.CreatePasswordHashAndSalt("kavee", out passwordHash, out passwordSalt);
            newUser.ApplicationUser.PasswordHash = passwordHash;
            newUser.ApplicationUser.PasswordSalt = passwordSalt;
            context.UserExts.Add(newUser);
        }
    }
}
