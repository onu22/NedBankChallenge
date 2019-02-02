using System.Threading.Tasks;
using Abp.Application.Services;
using NedbankTest.Sessions.Dto;

namespace NedbankTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
