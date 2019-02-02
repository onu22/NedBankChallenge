using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NedbankTest.MultiTenancy.Dto;

namespace NedbankTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

