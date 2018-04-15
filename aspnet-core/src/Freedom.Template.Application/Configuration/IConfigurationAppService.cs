using System.Threading.Tasks;
using Freedom.Template.Configuration.Dto;

namespace Freedom.Template.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
