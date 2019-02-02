using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using NedbankTest.Configuration.Dto;

namespace NedbankTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NedbankTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
