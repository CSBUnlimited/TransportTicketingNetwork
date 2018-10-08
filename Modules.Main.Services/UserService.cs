using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Base.Services;
using Common.Configurations.Constants;
using Common.Methods;
using Common.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Services;
using Modules.Main.Models;
using Modules.Main.ViewModels;

namespace Modules.Main.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IMainUnitOfWork _mainUnitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainUnitOfWork">MainUnitOfWork</param>
        public UserService(IMainUnitOfWork mainUnitOfWork, IMapper mapper)
        {
            _mainUnitOfWork = mainUnitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Register User - Async
        /// </summary>
        /// <param name="userExtViewModel">User View Model Ext</param>
        /// <returns>User View Model</returns>
        public async Task<UserViewModel> RegisterUserAsync(UserExtViewModel userExtViewModel)
        {
            UserRole userRole =
                await _mainUnitOfWork.UserRoleRepository.GetUserRoleByDescriptionAsync(userExtViewModel.UserRole);

            if (userRole == null || !(userRole.UserRoleEnum == UserRoleEnum.ForeignCustomer ||
                                      userRole.UserRoleEnum == UserRoleEnum.LocalCustomer))
            {
                throw new ValidationException("Invalid User Role defined.");
            }

            ApplicationUser applicationUser =
                await _mainUnitOfWork.ApplicationUserRepository.GetApplicationUserByUserNameAsync(userExtViewModel.Username);

            if (applicationUser != null)
            {
                throw new ValidationException("Username already used before.");
            }

            UserExt user = _mapper.Map<UserExtViewModel, UserExt>(userExtViewModel);
            user.ApplicationUser = new ApplicationUser()
            {
                Username = userExtViewModel.Username,
                EffectiveDateTime = DateTime.UtcNow,
                ExpireDateTime = DatabaseConstants.ExpireUtcDateTime,
                UserRoleId = userRole.Id
            };

            AuthenticationMethods.CreatePasswordHashAndSalt(AuthenticationMethods.DecodeFrom64(userExtViewModel.Password), out byte[] passwordHash, out byte[] passwordSalt);
            user.ApplicationUser.PasswordHash = passwordHash;
            user.ApplicationUser.PasswordSalt = passwordSalt;

            using (IDbContextTransaction transaction = await _mainUnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await _mainUnitOfWork.UserRepository.AddUserExtAsync(user);
                    await _mainUnitOfWork.CompleteAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            UserViewModel newUserViewModel = _mapper.Map<UserExt, UserViewModel>(user);
            newUserViewModel.Username = userExtViewModel.Username;
            newUserViewModel.UserRole = userRole.Description;

            return newUserViewModel;
        }
    }
}
