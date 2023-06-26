using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Identity;
using SmartLearn.Authorization.Users;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.PersonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.ParentServices
{
    public class ParentAppService : ApplicationService, IParentAppService
    {
        private readonly IRepository<Parent, Guid> _parentRepository;
        private readonly UserManager _userManager;

        public ParentAppService(IRepository<Parent, Guid> parentRepository, UserManager userManager)
        {
            this._parentRepository = parentRepository;
            this._userManager = userManager;
        }


        public async Task<ParentDto> CreateAsync(ParentDto input)
        {
           
            var user = ObjectMapper.Map<User>(input);
            input.RoleNames = new string[] { "Parent" };
          
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            //CheckErrors(await _userManager.CreateAsync(user, input.Password));

            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }

            var parent = ObjectMapper.Map<Parent>(input);

            parent.User = user;
            await _parentRepository.InsertAsync(parent);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<ParentDto>(parent);
        }

        private void CheckErrors(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                var errorMessage = "User creation failed. Errors: ";

                foreach (var error in identityResult.Errors)
                {
                    errorMessage += $"{error.Description}. ";
                }

                throw new ApplicationException(errorMessage); // or use a more specific exception type
            }
        }

        public async Task<List<ParentDto>> GetAllAsync()
        {
            var parents = await _parentRepository.GetAllListAsync();
            return ObjectMapper.Map<List<ParentDto>>(parents);
        }

        public async Task<ParentDto> GetAsync(Guid id)
        {
            var parent = await _parentRepository.GetAsync(id);
            return ObjectMapper.Map<ParentDto>(parent);
        }

        public async Task UpdateAsync(ParentDto input)
        {
            var parent = await _parentRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, parent);
            await _parentRepository.UpdateAsync(parent);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _parentRepository.DeleteAsync(id);
        }
    }
}
