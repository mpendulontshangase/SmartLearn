using Abp.Application.Services;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.ParentServices
{
    public interface IParentAppService : IApplicationService
    {
        //Task<ParentDto> CreateAsync(ParentDto input);
        Task<List<ParentDto>> GetAllAsync();
        Task<ParentDto> GetAsync(Guid id);
        Task UpdateAsync(ParentDto input);
        Task DeleteAsync(Guid id);
    }
}
