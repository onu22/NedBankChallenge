using System.Threading.Tasks;
using NedbankTest.Configuration.Dto;

namespace NedbankTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
