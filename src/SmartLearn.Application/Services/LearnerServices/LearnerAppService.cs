using Abp.Application.Services;
using Abp.Domain.Repositories;
using SmartLearn.Authorization.Users;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using SmartLearn.Services.Dto;
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
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;

        public LearnerAppService(IRepository<Learner, Guid> learnerRepository, IRepository<Parent, Guid> parentRepository,UserManager userManager, IUserAppService userAppService)
        {
            this._learnerRepository = learnerRepository;
            this._parentRepository = parentRepository;
            this._userManager = userManager;
            this._userAppService = userAppService;
        }

        public async Task<LearnerDto> CreateLearnerAsync(LearnerDto input)
        {
 
            var existingLearnerById = await _learnerRepository.FirstOrDefaultAsync(x => x.IDNumber == input.IDNumber);
            if (existingLearnerById != null)
            {
                throw new Exception("A learner with the same ID already exists.");
            }

            var existingLearnerByEmail = await _learnerRepository.FirstOrDefaultAsync(x => x.EmailAddress == input.EmailAddress);
            if (existingLearnerByEmail != null)
            {
                throw new Exception("A learner with the same email address already exists.");
            }
            var learner = ObjectMapper.Map<Learner>(input);
            learner.Parent = _parentRepository.Get(input.Parent_Id);
            var createUserDto = ObjectMapper.Map<CreateUserDto>(input);
            var userDto = await _userAppService.CreateAsync(createUserDto);
            learner.User = ObjectMapper.Map<User>(userDto);
            await _learnerRepository.InsertAsync(learner);
            return ObjectMapper.Map<LearnerDto>(learner);
        }


        public async Task<List<LearnerDto>> GetAllAsync()
        {
            var learners = await _learnerRepository.GetAllListAsync();
            return ObjectMapper.Map<List<LearnerDto>>(learners);
        }

        public async Task<LearnerDto> GetAsync(Guid id)
        {
            var learner = await _learnerRepository.GetAsync(id);
            return ObjectMapper.Map<LearnerDto>(learner);
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

        public async Task<List<LearnerDto>> GetLearnersBySubjectAsync(string subject)
        {
            string subjectUpperCase = subject.ToUpper();

            
            var matchingSubject = Enum.GetValues(typeof(RefListSubject))
                                      .Cast<RefListSubject>()
                                      .FirstOrDefault(s => s.ToString().ToUpper() == subjectUpperCase);

            if (matchingSubject == default(RefListSubject))
            {
                return new List<LearnerDto>();
            }

            var learners = await _learnerRepository.GetAllListAsync(l => l.Learner_Subject == matchingSubject);
            return ObjectMapper.Map<List<LearnerDto>>(learners);
        }



        public async Task<List<LearnerDto>> GetLearnersByGradeAsync(string grade)
        {
            string gradeUpperCase = grade.ToUpper();


            var matchingGrade = Enum.GetValues(typeof(RefListGrade))
                                      .Cast<RefListGrade>()
                                      .FirstOrDefault(s => s.ToString().ToUpper() == gradeUpperCase);

            if (matchingGrade == default(RefListGrade))
            {
                return new List<LearnerDto>();
            }

            var learners = await _learnerRepository.GetAllListAsync(l => l.Learner_Grade == matchingGrade);
            return ObjectMapper.Map<List<LearnerDto>>(learners);
        }

        public async Task<List<LearnerDto>> GetLearnersByParentIdAsync(Guid parentId)
        {
            var learners = await _learnerRepository.GetAllListAsync(l => l.Parent_Id == parentId);
            return ObjectMapper.Map<List<LearnerDto>>(learners);
        }
    }
}
