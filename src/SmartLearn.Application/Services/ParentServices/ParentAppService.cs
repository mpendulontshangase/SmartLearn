using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
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

        public ParentAppService(IRepository<Parent, Guid> parentRepository)
        {
            _parentRepository = parentRepository;
        }

        public async Task<ParentDto> CreateAsync(ParentDto input)
        {
            var existingLearnerById = await _parentRepository.FirstOrDefaultAsync(x => x.IDNumber == input.IDNumber);
            if (existingLearnerById != null)
            {
                throw new Exception("A teacher with the same ID already exists.");
            }

            var existingLearnerByEmail = await _parentRepository.FirstOrDefaultAsync(x => x.EmailAddress == input.EmailAddress);
            if (existingLearnerByEmail != null)
            {
                throw new Exception("A teacher with the same email address already exists.");
            }
            var parent = ObjectMapper.Map<Parent>(input);
            await _parentRepository.InsertAsync(parent);
            return ObjectMapper.Map<ParentDto>(parent);
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
