using System.Threading.Tasks;
using Abp.Application.Services;
using Freedom.Template.Sessions.Dto;

namespace Freedom.Template.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
