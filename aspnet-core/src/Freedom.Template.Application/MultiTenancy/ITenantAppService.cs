using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Freedom.Template.MultiTenancy.Dto;

namespace Freedom.Template.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
