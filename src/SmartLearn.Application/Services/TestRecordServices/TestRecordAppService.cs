//using Abp.Application.Services;
//using Abp.Domain.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using SmartLearn.Domain;
//using SmartLearn.Services.Dto;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SmartLearn.Services.TestRecordServices
//{
//    public class TestRecordAppService : ApplicationService,ITestRecordAppService
//    {
//        private readonly IRepository<TestRecord, Guid> _testrecordRepository;
//        private readonly IRepository<Teacher, Guid> _teacherRepository;

//        public TestRecordAppService(IRepository<TestRecord, Guid> testrecordRepository, IRepository<Teacher, Guid> teacherRepository)
//        {
//            _testrecordRepository = testrecordRepository;
//            _teacherRepository = teacherRepository;
            
//        }
//        [Consumes("multipart/form-data")]

//        public async Task<TestRecordDto> CreateAsync(TestRecordDto input)
//        {
//            var test = ObjectMapper.Map<TestRecord>(input);
//            test.Teacher = _teacherRepository.Get(input.Teacher_Id);
//            await _testrecordRepository.InsertAsync(test);
//            return ObjectMapper.Map<TestRecordDto>(test);
//        }

//        public async Task<List<TestRecordDto>> GetAllAsync()
//        {
//            var test = await _testrecordRepository.GetAllListAsync();
//            return ObjectMapper.Map<List<TestRecordDto>>(test);
//        }

//        public async Task<TestRecordDto> GetAsync(Guid id)
//        {
//            var test = await _testrecordRepository.GetAsync(id);
//            return ObjectMapper.Map<TestRecordDto>(test);
//        }

//        public async Task UpdateAsync(TestRecordDto input)
//        {
//            var test = await _testrecordRepository.GetAsync(input.Id);
//            ObjectMapper.Map(input, test);
//            await _testrecordRepository.UpdateAsync(test);
//        }

//        public async Task DeleteAsync(Guid id)
//        {
//            await _testrecordRepository.DeleteAsync(id);
//        }
//    }
//}
