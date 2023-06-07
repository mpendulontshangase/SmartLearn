using Abp.Application.Services;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.TestRecordServices
{
    public interface ITestRecordAppService : IApplicationService
    {
        Task<TestRecordDto> CreateAsync(TestRecordDto input);
        Task<List<TestRecordDto>> GetAllAsync();
        Task<TestRecordDto> GetAsync(Guid id);
        Task UpdateAsync(TestRecordDto input);
        Task DeleteAsync(Guid id);
    }
}
