using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Freedom.Template.Roles.Dto;

namespace Freedom.Template.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
