using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.IdentityDtos;
using Entities.Models.IdentityUser;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<AppRole> Roles { get; }
        IEnumerable<AppUser>  GetAllUsers();
        Task<IdentityResult> CreateUserAsync(UserDtoForCreation userDto);
        Task<AppUser> GetOneUserAsync(string userName);
        Task<UserDtoForUpdate> GetOneUserForUpdateAsync(string userName);
        Task UpdateUserAsyc(UserDtoForUpdate userDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto resetPassword);
        Task<IdentityResult> DeleteOneUserAsync(string userName);
    }
}