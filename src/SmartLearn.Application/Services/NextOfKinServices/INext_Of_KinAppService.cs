using Abp.Application.Services;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.NextOfKinServices
{
    public interface INext_Of_KinAppService : IApplicationService
    {
        //Task<Next_Of_KinDto> CreateAsync(Next_Of_KinDto input);
        Task<List<Next_Of_KinDto>> GetAllAsync();
        Task<Next_Of_KinDto> GetAsync(Guid id);
        Task UpdateAsync(Next_Of_KinDto input);
        Task DeleteAsync(Guid id);
    }
}
