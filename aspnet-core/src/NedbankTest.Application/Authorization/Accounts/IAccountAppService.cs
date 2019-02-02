using System.Threading.Tasks;
using Abp.Application.Services;
using NedbankTest.Authorization.Accounts.Dto;

namespace NedbankTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
