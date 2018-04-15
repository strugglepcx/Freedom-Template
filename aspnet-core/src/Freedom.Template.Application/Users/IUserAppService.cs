using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Freedom.Template.Roles.Dto;
using Freedom.Template.Users.Dto;

namespace Freedom.Template.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
