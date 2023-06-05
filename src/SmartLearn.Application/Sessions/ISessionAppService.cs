using System.Threading.Tasks;
using Abp.Application.Services;
using SmartLearn.Sessions.Dto;

namespace SmartLearn.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
