using System.Collections.Generic;
using System.Linq;
using Common.Models;

namespace TransportTicketingNetwork.Database.Seed
{
    internal static class SeedMultiPurposeTags
    {
        internal static void SeedMultiPurposeTagsData(this TransportTicketingNetworkDbContext context, IEnumerable<MultiPurposeTagType> currentMultiPurposeTagTypes)
        {
            #region MultiPurposeTagTypes need to insert

            currentMultiPurposeTagTypes = currentMultiPurposeTagTypes.ToList();

            // Data that need to insert
            IEnumerable<MultiPurposeTag> multiPurposeTags = new List<MultiPurposeTag>()
            {
                // GenderEnum
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(GenderEnum)).Id,
                    EnumValue = (int)GenderEnum.Male,
                    EnumValueName = nameof(GenderEnum.Male),
                    Description = $"{nameof(GenderEnum)}-{nameof(GenderEnum.Male)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(GenderEnum)).Id,
                    EnumValue = (int)GenderEnum.Female,
                    EnumValueName = nameof(GenderEnum.Female),
                    Description = $"{nameof(GenderEnum)}-{nameof(GenderEnum.Female)}"
                },

                // User Roles
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(UserRoleEnum)).Id,
                    EnumValue = (int)UserRoleEnum.Anonymous,
                    EnumValueName = nameof(UserRoleEnum.Anonymous),
                    Description = $"{nameof(UserRoleEnum)}-{nameof(UserRoleEnum.Anonymous)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(UserRoleEnum)).Id,
                    EnumValue = (int)UserRoleEnum.ForeignCustomer,
                    EnumValueName = nameof(UserRoleEnum.ForeignCustomer),
                    Description = $"{nameof(UserRoleEnum)}-{nameof(UserRoleEnum.ForeignCustomer)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(UserRoleEnum)).Id,
                    EnumValue = (int)UserRoleEnum.LocalCustomer,
                    EnumValueName = nameof(UserRoleEnum.LocalCustomer),
                    Description = $"{nameof(UserRoleEnum)}-{nameof(UserRoleEnum.LocalCustomer)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(UserRoleEnum)).Id,
                    EnumValue = (int)UserRoleEnum.TransportManager,
                    EnumValueName = nameof(UserRoleEnum.TransportManager),
                    Description = $"{nameof(UserRoleEnum)}-{nameof(UserRoleEnum.TransportManager)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(UserRoleEnum)).Id,
                    EnumValue = (int)UserRoleEnum.BankNetwork,
                    EnumValueName = nameof(UserRoleEnum.BankNetwork),
                    Description = $"{nameof(UserRoleEnum)}-{nameof(UserRoleEnum.BankNetwork)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(UserRoleEnum)).Id,
                    EnumValue = (int)UserRoleEnum.MobileNetwork,
                    EnumValueName = nameof(UserRoleEnum.MobileNetwork),
                    Description = $"{nameof(UserRoleEnum)}-{nameof(UserRoleEnum.MobileNetwork)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(UserRoleEnum)).Id,
                    EnumValue = (int)UserRoleEnum.Administrator,
                    EnumValueName = nameof(UserRoleEnum.Administrator),
                    Description = $"{nameof(UserRoleEnum)}-{nameof(UserRoleEnum.Administrator)}"
                },

                // Solution Modules
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(ModuleEnum)).Id,
                    EnumValue = (int)ModuleEnum.Common,
                    EnumValueName = nameof(ModuleEnum.Common),
                    Description = $"{nameof(ModuleEnum)}-{nameof(ModuleEnum.Common)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(ModuleEnum)).Id,
                    EnumValue = (int)ModuleEnum.Authorization,
                    EnumValueName = nameof(ModuleEnum.Authorization),
                    Description = $"{nameof(ModuleEnum)}-{nameof(ModuleEnum.Authorization)}"
                },
                new MultiPurposeTag()
                {
                    MultiPurposeTagTypeId = currentMultiPurposeTagTypes.Single(cmptt => cmptt.EnumName == nameof(ModuleEnum)).Id,
                    EnumValue = (int)ModuleEnum.Main,
                    EnumValueName = nameof(ModuleEnum.Main),
                    Description = $"{nameof(ModuleEnum)}-{nameof(ModuleEnum.Main)}"
                }
            };

            #endregion

            // Check that need to check with current records
            bool isNeedCheck = true;

            // Get All Multi Purpose Tags
            IEnumerable<MultiPurposeTag> currentMultiPurposeTags = context.MultiPurposeTags.ToList();

            if (!currentMultiPurposeTagTypes.Any())
            {
                isNeedCheck = false;
            }

            // Check that tag type need to add or not
            foreach (MultiPurposeTag tag in multiPurposeTags)
            {
                if (!isNeedCheck || currentMultiPurposeTags.FirstOrDefault(cmpt => cmpt.MultiPurposeTagTypeId == tag.MultiPurposeTagTypeId && cmpt.EnumValue == tag.EnumValue) == null)
                {
                    context.MultiPurposeTags.Add(tag);
                }
            }

            context.SaveChanges();
        }
    }
}
