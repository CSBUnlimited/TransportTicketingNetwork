using System.Collections.Generic;
using System.Linq;
using Common.Models;

namespace TransportTicketingNetwork.Database.Seed
{
    internal static class SeedMultiPurposeTagTypes
    {
        /// <summary>
        /// Seed Multi Purpose Tag Types data to database
        /// </summary>
        /// <param name="context"></param>
        internal static void SeedMultiPurposeTagTypesData(this TransportTicketingNetworkDbContext context)
        {
            #region MultiPurposeTagTypes need to insert

            // Data that need to insert
            IEnumerable<MultiPurposeTagType> multiPurposeTagTypes = new List<MultiPurposeTagType>()
            {
                new MultiPurposeTagType()
                {
                    EnumName = nameof(GenderEnum),
                    Description = "User GenderEnum"
                },
                new MultiPurposeTagType()
                {
                    EnumName = nameof(UserRoleEnum),
                    Description = "Application User Role"
                },
                new MultiPurposeTagType()
                {
                    EnumName = nameof(ModuleEnum),
                    Description = "Solution Modules"
                }
            };

            #endregion

            // Check that need to check with current records
            bool isNeedCheck = true;

            // Get All Multi Purpose Tag Types
            IEnumerable<MultiPurposeTagType> currentMultiPurposeTagTypes = context.MultiPurposeTagTypes.ToList();

            if (!currentMultiPurposeTagTypes.Any())
            {
                isNeedCheck = false;
            }

            // Check that tag type need to add or not
            foreach (MultiPurposeTagType tagType in multiPurposeTagTypes)
            {
                if (!isNeedCheck || currentMultiPurposeTagTypes.FirstOrDefault(cmptt => cmptt.EnumName == tagType.EnumName) == null)
                {
                    context.MultiPurposeTagTypes.Add(tagType);
                }
            }

            context.SaveChanges();
        }
    }
}
