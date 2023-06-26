using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using AutoMapper;
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

namespace SmartLearn.Services.TeacherServices
{
    public class TeacherAppService : ApplicationService, ITeacherAppService
    {
        private readonly IRepository<Teacher,   Guid> _teacherRepository;
      
        private readonly UserManager _userManager;

        public TeacherAppService(IRepository<Teacher, Guid> teacherRepository, UserManager userManager)
        {
            _teacherRepository = teacherRepository;
            _userManager = userManager;
           
        }

     
        public async Task<TeacherDto> CreateAsync(TeacherDto input)
        {
           
            var user = ObjectMapper.Map<User>(input);
            input.RoleNames = new string[] { "Teacher" };

            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }

            var teacher = ObjectMapper.Map<Teacher>(input);
          


            teacher.User = user;
            await _teacherRepository.InsertAsync(teacher);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<TeacherDto>(teacher);
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

        public async Task<List<TeacherDto>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllListAsync();
            return ObjectMapper.Map<List<TeacherDto>>(teachers);
        }

        //public async Task<TeacherDto> GetAsync(Guid id)
        //{
        //    var teacher = await _teacherRepository.GetAsync(id);
        //    return ObjectMapper.Map<TeacherDto>(teacher);
        //}
       

        public async Task UpdateAsync(TeacherDto input)
        {
            input.RoleNames = new string[] { "Teacher" };
            var teacher = await _teacherRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, teacher);
            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _teacherRepository.DeleteAsync(id);
        }

        public async Task<TeacherDto>GetByUserIdAsync(long userId)
        {
            var teacher =  _teacherRepository.GetAllIncluding(m => m.User).FirstOrDefault(x => x.User.Id == userId);
            return ObjectMapper.Map<TeacherDto>(teacher);
        }
    }
}