using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.TeacherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SmartLearn.Services.TestRecordServices
{
    public class TestAppService : ApplicationService, ITestRecordAppService
    {
        private readonly IRepository<TestRecord, Guid> _testRecordRepository;
        private readonly IRepository<Teacher, Guid> _teacherRepository;

        public TestAppService(IRepository<TestRecord, Guid> testRecordRepository, IRepository<Teacher, Guid> teacherRepository)
        {
            _testRecordRepository = testRecordRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<TestRecordDto> CreateAsync(TestRecordDto input)
        {
           
            var test = ObjectMapper.Map<TestRecord>(input);
            test.Teacher = _teacherRepository.Get(input.Teacher_Id);
            await _testRecordRepository.InsertAsync(test);
            return ObjectMapper.Map<TestRecordDto>(test);
        }

        public async Task<List<TestRecordDto>> GetAllAsync()
        {
            var tests = await _testRecordRepository.GetAllListAsync();
            return ObjectMapper.Map<List<TestRecordDto>>(tests);
        }

        public async Task<TestRecordDto> GetAsync(Guid id)
        {
            var test = await _testRecordRepository.GetAsync(id);
            return ObjectMapper.Map<TestRecordDto>(test);
        }

        public async Task UpdateAsync(TestRecordDto input)
        {
            var test = await _testRecordRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, test);
            await _testRecordRepository.UpdateAsync(test);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _testRecordRepository.DeleteAsync(id);
        }
    }
}
