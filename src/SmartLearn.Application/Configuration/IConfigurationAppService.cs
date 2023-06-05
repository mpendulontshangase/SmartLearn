using System.Threading.Tasks;
using SmartLearn.Configuration.Dto;

namespace SmartLearn.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
