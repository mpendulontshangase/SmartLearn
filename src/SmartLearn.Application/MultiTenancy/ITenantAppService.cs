using Abp.Application.Services;
using SmartLearn.MultiTenancy.Dto;

namespace SmartLearn.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

