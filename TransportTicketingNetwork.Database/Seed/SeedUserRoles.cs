using System.Collections.Generic;
using System.Linq;
using Common.Models;

namespace TransportTicketingNetwork.Database.Seed
{
    internal static class SeedUserRoles
    {
        internal static void SeedUserRolesData(this TransportTicketingNetworkDbContext context)
        {
            // Get All User Roles
            IEnumerable<UserRole> currentUserRoles = context.UserRoles.ToList();

            #region MultiPurposeTagTypes need to insert

            // Data that need to insert
            IEnumerable<UserRole> userRoles = new List<UserRole>()
            {
                new UserRole()
                {
                    UserRoleEnum = UserRoleEnum.Anonymous,
                    Description = nameof(UserRoleEnum.Anonymous)
                },
                new UserRole()
                {
                    UserRoleEnum = UserRoleEnum.ForeignCustomer,
                    Description = nameof(UserRoleEnum.ForeignCustomer)
                },
                new UserRole()
                {
                    UserRoleEnum = UserRoleEnum.LocalCustomer,
                    Description = nameof(UserRoleEnum.LocalCustomer)
                },
                new UserRole()
                {
                    UserRoleEnum = UserRoleEnum.TransportManager,
                    Description = nameof(UserRoleEnum.TransportManager)
                },
                new UserRole()
                {
                    UserRoleEnum = UserRoleEnum.BankNetwork,
                    Description = nameof(UserRoleEnum.BankNetwork)
                },
                new UserRole()
                {
                    UserRoleEnum = UserRoleEnum.MobileNetwork,
                    Description = nameof(UserRoleEnum.MobileNetwork)
                },
                new UserRole()
                {
                    UserRoleEnum = UserRoleEnum.Administrator,
                    Description = nameof(UserRoleEnum.Administrator)
                }
            };

            #endregion

            // Check that need to check with current records
            bool isNeedCheck = currentUserRoles.Any();

            // Check that tag type need to add or not
            foreach (UserRole userRole in userRoles)
            {
                if (!isNeedCheck || currentUserRoles.FirstOrDefault(ur => ur.UserRoleEnum == userRole.UserRoleEnum) == null)
                {
                    context.UserRoles.Add(userRole);
                }
            }

            context.SaveChanges();
        }
    }
}
