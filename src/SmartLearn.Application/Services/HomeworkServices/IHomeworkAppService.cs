using Abp.Application.Services;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.HomeworkServices
{
    public interface IHomeworkAppService : IApplicationService
    {
        Task<HomeworkRecordDto> CreateAsync(HomeworkRecordDto input);
        Task<List<HomeworkRecordDto>> GetAllAsync();
        Task<HomeworkRecordDto> GetAsync(Guid id);
        Task UpdateAsync(HomeworkRecordDto input);
        Task DeleteAsync(Guid id);
    }
}
