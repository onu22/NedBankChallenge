using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NedbankTest.Roles.Dto;
using NedbankTest.Users.Dto;

namespace NedbankTest.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
