using System.Threading.Tasks;
using Abp.Application.Services;
using SmartLearn.Authorization.Accounts.Dto;

namespace SmartLearn.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
