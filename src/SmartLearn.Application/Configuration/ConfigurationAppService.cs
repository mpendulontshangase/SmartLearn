using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SmartLearn.Configuration.Dto;

namespace SmartLearn.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SmartLearnAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
