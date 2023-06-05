using Abp.Application.Services;
using Abp.Domain.Repositories;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.LearnerServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLearn.Services.PersonServices
{
    public class LearnerAppService : ApplicationService, ILearnerAppService
    {
        private readonly IRepository<Learner, Guid> _learnerRepository;

        public LearnerAppService(IRepository<Learner, Guid> learnerRepository)
        {
            _learnerRepository = learnerRepository;
        }

        public async Task<LearnerDto> CreateAsync(LearnerDto input)
        {
            var learner = ObjectMapper.Map<Learner>(input);
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

        //public async Task<List<LearnerDto>> GetLearnersBySubjectAsync(string subject)
        //{
        //    var learners = await _learnerRepository.GetAllListAsync(l => l.Learner_Subject == subject);
        //    return ObjectMapper.Map<List<LearnerDto>>(learners);
        //}

        //public async Task<List<LearnerDto>> GetLearnersByGradeAsync(string grade)
        //{
        //    var learners = await _learnerRepository.GetAllListAsync(l => l.Learner_Grade == grade);
        //    return ObjectMapper.Map<List<LearnerDto>>(learners);
        //}

        //public async Task<List<LearnerDto>> GetLearnersByParentIdAsync(Guid parentId)
        //{
        //    var learners = await _learnerRepository.GetAllListAsync(l => l.Parent_Id == parentId);
        //    return ObjectMapper.Map<List<LearnerDto>>(learners);
        //}
    }
}
