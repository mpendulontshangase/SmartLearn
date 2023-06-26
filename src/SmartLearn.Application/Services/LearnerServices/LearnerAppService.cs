using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartLearn.Authorization.Users;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using SmartLearn.Services.Dto;
using SmartLearn.Services.Helper;
using SmartLearn.Services.LearnerServices;
using SmartLearn.Users;
using SmartLearn.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLearn.Services.PersonServices
{
    public class LearnerAppService : ApplicationService, ILearnerAppService
    {
        private readonly IRepository<Learner, Guid> _learnerRepository;
        private readonly IRepository<Parent, Guid> _parentRepository;
        private readonly IRepository<Person, Guid> _personRepository;
        //private readonly IRepository<Subject, Guid> _subjectRepository;
        //private readonly IRepository<Grade, Guid> _gradeRepository;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;

        public LearnerAppService(IRepository<Learner, Guid> learnerRepository, IRepository<Parent, Guid> parentRepository,UserManager userManager, IUserAppService userAppService, IRepository<Person, Guid> personRepository)
        {
            this._learnerRepository = learnerRepository;
            this._parentRepository = parentRepository;
            this._userManager = userManager;
            this._userAppService = userAppService;
            this._personRepository = personRepository;
            
        }



        public async Task<LearnerDto> CreateLearnerAsync(LearnerDto input)
        {
            
            var user = ObjectMapper.Map<User>(input);
            input.RoleNames = new string[] { "Learner" };

            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }
            var learner = ObjectMapper.Map<Learner>(input);
     
            learner.Parent = _parentRepository.Get(input.Parent_Id);
            learner.User = user;
            await _learnerRepository.InsertAsync(learner);
            

            var result = ObjectMapper.Map<LearnerDto>(learner);
            var decomposed = RefListHelper.DecomposeIntoBitFlagComponents((int)learner.Subject);
            var lists = new List<string>();

            foreach (var item in decomposed)
            {
                var name = RefListHelper.GetEnumDescription((RefListSubject)item);
            }

            result.SubjectDisplay = lists;
            result.Subject = decomposed.ToList();

            return result;
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

                throw new ApplicationException(errorMessage); 
            }
        }


        public async Task<List<LearnerDto>> GetAllAsync()
        {
            var learners = await _learnerRepository.GetAllIncluding(x =>x.Parent).ToListAsync();

            var test = ObjectMapper.Map<List<LearnerDto>>(learners);

            return ObjectMapper.Map<List<LearnerDto>>(learners);
        }

        public async Task<LearnerDto> GetAsync(Guid id)
        {
            var learner = await _learnerRepository.GetAsync(id);
            return ObjectMapper.Map<LearnerDto>(learner);
        }

        public async Task<PersonDto> GetPersonInfoAsync(long userId)
        {
            var learner = await _personRepository.GetAll().FirstOrDefaultAsync(x=>x.User.Id==userId);
            return ObjectMapper.Map<PersonDto>(learner);
        }

        public async Task UpdateAsync(LearnerDto input)
        {
          
            var learner = await _learnerRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, learner);
            await _learnerRepository.UpdateAsync(learner);

        }

        public async Task DeleteAsync(Guid id)
        {
            await _learnerRepository.DeleteAsync(id);
        }

        //public async Task<List<LearnerDto>> GetLearnersBySubjectAsync(string subject)
        //{
        //    string subjectUpperCase = subject.ToUpper();

            
        //    var matchingSubject = Enum.GetValues(typeof(RefListSubject))
        //                              .Cast<RefListSubject>()
        //                              .FirstOrDefault(s => s.ToString().ToUpper() == subjectUpperCase);

        //    if (matchingSubject == default(RefListSubject))
        //    {
        //        return new List<LearnerDto>();
        //    }

        //    var learners = await _learnerRepository.GetAllListAsync(l => l.Learner_Subject == matchingSubject);
        //    return ObjectMapper.Map<List<LearnerDto>>(learners);
        //}



        //public async Task<List<LearnerDto>> GetLearnersByGradeAsync(string grade)
        //{
        //    string gradeUpperCase = grade.ToUpper();


        //    var matchingGrade = Enum.GetValues(typeof(RefListGrade))
        //                              .Cast<RefListGrade>()
        //                              .FirstOrDefault(s => s.ToString().ToUpper() == gradeUpperCase);

        //    if (matchingGrade == default(RefListGrade))
        //    {
        //        return new List<LearnerDto>();
        //    }

        //    var learners = await _learnerRepository.GetAllListAsync(l => l.Learner_Grade == matchingGrade);
        //    return ObjectMapper.Map<List<LearnerDto>>(learners);
        //}

        //public async Task<List<LearnerDto>> GetLearnersByParentIdAsync(Guid parentId)
        //{
        //    var learners = await _learnerRepository.GetAllListAsync(l => l.Parent_Id == parentId);
        //    return ObjectMapper.Map<List<LearnerDto>>(learners);
        //}
    }
}
