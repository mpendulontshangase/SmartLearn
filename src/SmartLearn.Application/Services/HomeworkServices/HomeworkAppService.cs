using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.TestRecordServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.HomeworkServices
{
    public class HomeworkAppService : ApplicationService, IHomeworkAppService
    {
        private readonly IRepository<HomeworkRecord, Guid> _homeworkRepository;
        private readonly IRepository<Teacher, Guid> _teacherRepository;

        public HomeworkAppService(IRepository<HomeworkRecord, Guid> homeworkRepository, IRepository<Teacher, Guid> teacherRepository)
        {
            _homeworkRepository = homeworkRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<HomeworkRecordDto> CreateAsync(HomeworkRecordDto input)
        {

            var homework = ObjectMapper.Map<HomeworkRecord>(input);
            homework.Teacher = _teacherRepository.Get(input.Teacher_Id);
            await _homeworkRepository.InsertAsync(homework);
            return ObjectMapper.Map<HomeworkRecordDto>(homework);
        }

        public async Task<List<HomeworkRecordDto>> GetAllAsync()
        {
            var homeworks = await _homeworkRepository.GetAllListAsync();
            return ObjectMapper.Map<List<HomeworkRecordDto>>(homeworks);
        }

        public async Task<HomeworkRecordDto> GetAsync(Guid id)
        {
            var homework = await _homeworkRepository.GetAsync(id);
            return ObjectMapper.Map<HomeworkRecordDto>(homework);
        }

        public async Task UpdateAsync(HomeworkRecordDto input)
        {
            var homework = await _homeworkRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, homework);
            await _homeworkRepository.UpdateAsync(homework);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _homeworkRepository.DeleteAsync(id);
        }
    }
}
