using Abp.Application.Services;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLearn.Services.PersonServices
{
    public interface ILearnerAppService : IApplicationService
    {
        Task<LearnerDto> CreateAsync(LearnerDto input);
        Task<List<LearnerDto>> GetAllAsync();
        Task<LearnerDto> GetAsync(Guid id);
        Task UpdateAsync(LearnerDto input);
        Task DeleteAsync(Guid id);
        //Task<List<LearnerDto>> GetLearnersBySubjectAsync(string subject);
        //Task<List<LearnerDto>> GetLearnersByGradeAsync(string grade);
        //Task<List<LearnerDto>> GetLearnersByParentIdAsync(Guid parentId);
        
    }
}
