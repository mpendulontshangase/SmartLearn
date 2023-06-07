using Abp.Application.Services;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.MessageService
{
    public interface IMessageAppService:IApplicationService
    {
        Task<MessageDto> CreateAsync(MessageDto input);
        Task<List<MessageDto>> GetAllAsync();
        Task<MessageDto> GetAsync(Guid id);
        Task UpdateAsync(MessageDto input);
        Task DeleteAsync(Guid id);
    }
}
