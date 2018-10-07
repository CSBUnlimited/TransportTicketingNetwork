using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TransportTicketingNetwork.Database.Seed;

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
            Console.WriteLine("Please wait. Database seeding in progress...");

            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Seed Multi Purpose Tag Types
                    context.SeedMultiPurposeTagTypesData();

                    // Get All Multi Purpose Tag Types
                    IEnumerable<MultiPurposeTagType> currentMultiPurposeTagTypes = context.MultiPurposeTagTypes.ToList();

                    // Seed Multi Purpose Tags
                    context.SeedMultiPurposeTagsData(currentMultiPurposeTagTypes);

                    // Get All Multi Purpose Tags
                    IEnumerable<MultiPurposeTag> currentMultiPurposeTags = context.MultiPurposeTags.ToList();

                    // Seed User Roles
                    context.SeedUserRolesData();

                    // Get All User Roles
                    IEnumerable<UserRole> currentUserRoles = context.UserRoles.ToList();

                    // Seed Users
                    context.SeedUsersData(currentUserRoles);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    Console.WriteLine("Database seeding failed.");
                    throw;
                }
            }

            Console.WriteLine("Database seeding completed...");
        }
    }
}
