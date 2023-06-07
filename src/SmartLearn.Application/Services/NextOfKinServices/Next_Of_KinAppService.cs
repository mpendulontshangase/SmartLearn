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

namespace SmartLearn.Services.NextOfKinServices
{
    public class Next_Of_KinAppService : ApplicationService, INext_Of_KinAppService
    {
        private readonly IRepository<Next_Of_Kin, Guid> _nextofkinRepository;

        public Next_Of_KinAppService(IRepository<Next_Of_Kin, Guid> nextofkinRepository)
        {
            _nextofkinRepository = nextofkinRepository;
        }

        public async Task<Next_Of_KinDto> CreateAsync(Next_Of_KinDto input)
        {
            var existingLearnerById = await _nextofkinRepository.FirstOrDefaultAsync(x => x.IDNumber == input.IDNumber);
            if (existingLearnerById != null)
            {
                throw new Exception("A teacher with the same ID already exists.");
            }

            var existingLearnerByEmail = await _nextofkinRepository.FirstOrDefaultAsync(x => x.EmailAddress == input.EmailAddress);
            if (existingLearnerByEmail != null)
            {
                throw new Exception("A teacher with the same email address already exists.");
            }
            var nextofkin = ObjectMapper.Map<Next_Of_Kin>(input);
            await _nextofkinRepository.InsertAsync(nextofkin);
            return ObjectMapper.Map<Next_Of_KinDto>(nextofkin);
        }

        public async Task<List<Next_Of_KinDto>> GetAllAsync()
        {
            var nextofkin = await _nextofkinRepository.GetAllListAsync();
            return ObjectMapper.Map<List<Next_Of_KinDto>>(nextofkin);
        }

        public async Task<Next_Of_KinDto> GetAsync(Guid id)
        {
            var nextofkin = await _nextofkinRepository.GetAsync(id);
            return ObjectMapper.Map<Next_Of_KinDto>(nextofkin);
        }

        public async Task UpdateAsync(Next_Of_KinDto input)
        {
            var nextofkin = await _nextofkinRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, nextofkin);
            await _nextofkinRepository.UpdateAsync(nextofkin);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _nextofkinRepository.DeleteAsync(id);
        }
    }
}
